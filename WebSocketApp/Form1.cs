using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using WebSocketSharp;
using System.Net;

namespace WebSocketApp
{
    public partial class Form1 : Form
    {
        public List<Led> ledList = new List<Led>();
        public WebSocket ws;
        public TextWriter _writer = null;
        public Boolean trasmetti = true;
        Object lockObj = new object();
        Queue<Led> queue;
        String wemosIp = "";
        Thread t1;

        Consumer c1;



        public Form1()
        {
            InitializeComponent();
            InitializeLeds();
            InitializeConsole();
            InizializeConnection();
            
        }

        private void InitializeConsole()
        {
            // Instantiate the writer
            _writer = new TextBoxStreamWriter(txtConsole);
            // Redirect the out Console stream
            Console.SetOut(_writer);
            Console.WriteLine("Booting ....");


        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            this.ringPanel.SendToBack();

            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();

            double Cx = ringPanel.Location.X;
            double Cy = ringPanel.Location.Y;

            double X = 0;
            double Y = 0;

            double ledDiameter = 25;

            double r = 100;

            double delta = (2 * Math.PI) / 12;

            double angle = 0;

            int shift = (int)r + (int)ledDiameter / 2;

            Rectangle rect = new Rectangle((int)Cx - shift, (int)Cy - shift, 250, 250);


            myBrush.Color = Color.Black;
            formGraphics.DrawEllipse(new Pen(myBrush, 4), rect);
            myBrush.Color = Color.DarkGray;
            formGraphics.FillEllipse(myBrush, rect);

            for (int i = 0; i < 12; i++)
            {
                //origine del led lungo la circonferenza 
                X = Cx + (r * Math.Cos(angle));
                Y = Cy + (r * Math.Sin(angle));



                foreach (Led l in ledList.Where(w => w.Number == i))
                {
                    l.X = (int)X + ((int)ledDiameter / 2);
                    l.Y = (int)Y + ((int)ledDiameter / 2);
                    l.Radius = (int)ledDiameter / 2;

                    rect = new Rectangle((int)X, (int)Y, l.Radius * 2, l.Radius * 2);

                    myBrush.Color = Color.Black;
                    formGraphics.DrawEllipse(new Pen(myBrush, 4), rect);

                    myBrush.Color = l.GetColor();
                    formGraphics.FillEllipse(myBrush, rect);

                    if (trasmetti)
                    {
                        queue.Enqueue(l);
                    }

                }

                angle += delta;
            }


            myBrush.Dispose();
            formGraphics.Dispose();
        }

        private void Form1_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Led selected = null;

            foreach (Led l in ledList)
            {
                selected = l.IsPointInside(e.Location.X, e.Location.Y);

                if (selected != null)
                {

                    if (colorDialog1.ShowDialog() == DialogResult.OK)
                    {
                        selected.Color = colorDialog1.Color;
                    }

                    if (selected.IsOn)
                    {
                        selected.TurnOff();
                        this.Invalidate();
                    }
                    else
                    {
                        selected.TurnOn();
                        this.Invalidate();
                    }
                }
            }

        }

        public void InitializeLeds()
        {
            Random rnd = new Random();


            for (int i = 0; i < 12; i++)
            {
                // Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

                Color ledColor = Color.FromArgb(0, 0, 0);

                ledList.Add(new Led(0, 0, 0, (int)i, ledColor, 100));

            }

        }
        public void InizializeConnection()
        {

            wemosIp = DoGetHostAddresses("ESP8266");

            using (ws = new WebSocket("ws://" + wemosIp + ":81"))
            {

                Console.WriteLine("Connessione a " + wemosIp);
                ws.Connect();

                ws.OnMessage += (sender, e) => {
                    MessageBox.Show(e.Data);
                };

            }
        }



        public string DoGetHostAddresses(string hostname)
        {
            IPAddress[] ips;

            do
            {
                Console.WriteLine("Ricerca IP ESP");
                ips = Dns.GetHostAddresses(hostname);
            }
            while (ips.Count() == 0);


            if (ips.Count() > 0)
            {
                Console.WriteLine("IP trovato: " + ips[0].ToString());
                string IPV4Address = ips[0].ToString();
                return IPV4Address;
            }
            else
            {
                return null;
            }

        }



        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (trasmetti)
            {
                ws.Connect();
                ws.Send("C");
            }

            t1.Abort();


        }

        private void btnTrasmetti_Click(object sender, EventArgs e)
        {
            if (trasmetti)
            {
                btnTrasmetti.BackColor = Color.LightCoral;
                trasmetti = false;
                Console.WriteLine("Trasmissione disattiva");
            }
            else
            {
                btnTrasmetti.BackColor = Color.LightGreen;
                trasmetti = true;
                Console.WriteLine("Trasmissione attiva");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            queue = new Queue<Led>();
            c1 = new Consumer(queue, lockObj, ws);
            t1 = new Thread(c1.consume);
            t1.Start();
        }

        private void Form1_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            Led selected = null;

            switch (e.Button)
            {

                case MouseButtons.Left:

                    selected = null;
                    foreach (Led l in ledList)
                    {
                        selected = l.IsPointInside(e.Location.X, e.Location.Y);

                        if (selected != null)
                        {

                            if (colorDialog1.ShowDialog() == DialogResult.OK)
                            {
                                selected.Color = colorDialog1.Color;
                                this.Invalidate();
                            }

                        }
                    }
                    // Left click
                    break;

                case MouseButtons.Right:
                    selected = null;

                    foreach (Led l in ledList)
                    {
                        selected = l.IsPointInside(e.Location.X, e.Location.Y);

                        if (selected != null)
                        {

                            contextMenuStrip1.Show();

                        }
                    }
                    // Left click
                    break;

            }
        }


        private void EffectA()
        {
            for(int i = 0; i < 6; i++) {

                foreach (Led l in ledList)
                {
               
                    l.Color = Color.Red;
                    Thread.Sleep(100);
                    queue.Enqueue(l);
                }

                foreach (Led l in ledList)
                {
                    l.Color = Color.Black;
                    Thread.Sleep(100);
                    queue.Enqueue(l);
                }
            }
        }


        private void EffectB()
        {
            int selected = 0;
            for (double i = 0; i < 1; i += 0.001)
            {

                ledList[(selected + 1) % 12].Color = ColorFromHSL(i, 0.5, 0.5,10);
                ledList[(selected + 2) % 12].Color   =  ColorFromHSL(i, 0.5, 0.5,10);
                ledList[(selected + 3) % 12].Color = ColorFromHSL(i, 0.5, 0.5,10);
                queue.Enqueue(ledList[(selected + 3) % 12]);
                Thread.Sleep(2);
                queue.Enqueue(ledList[(selected + 2) % 12]);
                Thread.Sleep(2);
                queue.Enqueue(ledList[(selected + 1) % 12]);
                Thread.Sleep(2);
                selected++;
            }
        }

        public static Color ColorFromHSL(double h, double s, double l, int minFactor)
        {
            double r = 0, g = 0, b = 0;
            if (l != 0)
            {
                if (s == 0)
                    r = g = b = l;
                else
                {
                    double temp2;
                    if (l < 0.5)
                        temp2 = l * (1.0 + s);
                    else
                        temp2 = l + s - (l * s);

                    double temp1 = 2.0 * l - temp2;

                    r = GetColorComponent(temp1, temp2, h + 1.0 / 3.0);
                    g = GetColorComponent(temp1, temp2, h);
                    b = GetColorComponent(temp1, temp2, h - 1.0 / 3.0);
                }
            }
            return Color.FromArgb((int)(255 * r)- minFactor, (int)(255 * g) - minFactor, (int)(255 * b) - minFactor);

        }

        private static double GetColorComponent(double temp1, double temp2, double temp3)
        {
            if (temp3 < 0.0)
                temp3 += 1.0;
            else if (temp3 > 1.0)
                temp3 -= 1.0;

            if (temp3 < 1.0 / 6.0)
                return temp1 + (temp2 - temp1) * 6.0 * temp3;
            else if (temp3 < 0.5)
                return temp2;
            else if (temp3 < 2.0 / 3.0)
                return temp1 + ((temp2 - temp1) * ((2.0 / 3.0) - temp3) * 6.0);
            else
                return temp1;
        }






        private void BtnAmbiente_Click(object sender, EventArgs e)
        {
            ws.Connect();
            Thread t2 = new Thread(EffectB);
            t2.Start();
        }
    }

    public class Led
    {
        private int _x;
        public int X
        {
            get => _x;
            set => _x = value;
        }

        private int _y;
        public int Y
        {
            get => _y;
            set => _y = value;
        }

        private int _lumos;
        public int Lumos {
            get => _lumos;
            set => _lumos = value;
        }


        private int _radius;
        public int Radius
        {
            get => _radius;
            set => _radius = value;
        }

        private int _number;
        public int Number
        {
            get => _number;
            set => _number = value;
        }

        private Color _color;
        public Color Color
        {
            get => _color;
            set => _color = value;
        }

        private bool _IsOn;
        public bool IsOn
        {
            get => _IsOn;
            set => _IsOn = value;
        }
        

        public Led(int x, int y, int radius, int n, Color c, int lumos)
        {
            this.X = x;
            this.Y = y;
            this.Radius = radius;
            this.Number = n;
            this.Color = c;
            this.IsOn = true;
            this.Lumos = lumos;
        }


        public Color GetColor()
        {
            if (this.IsOn)
            {
                return this.Color;
            }
            else
            {
                return System.Drawing.Color.Black;
            }
        }


        public void TurnOn()
        {
            this.IsOn = true;
        }

        public void TurnOff()
        {
            this.IsOn = false;
        }


        public Led IsPointInside(int x, int y)
        {
            Led selectedLed = null;

            if (Math.Pow(this.X - x, 2) + Math.Pow(this.Y - y, 2) <= this.Radius * this.Radius)
            {
                selectedLed = this;
            }

            return selectedLed;
        }

    }


}