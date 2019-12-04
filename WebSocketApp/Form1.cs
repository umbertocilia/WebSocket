﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using WebSocketSharp;

namespace WebSocketApp
{
    public partial class Form1 : Form
    {
        public List<Led> ledList = new List<Led>();
        public int lumos = 200;
        public WebSocket ws;
        public TextWriter _writer = null;
        public Boolean trasmetti = false;


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

            double Cx =  ringPanel.Location.X;
            double Cy =  ringPanel.Location.Y;

            double X = 0;
            double Y = 0;

            double ledDiameter = 25;

            double r = 100;

            double delta = (2 * Math.PI) / 11;

            double angle = 0;

            


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

                        Rectangle rect = new Rectangle((int)X, (int)Y, l.Radius * 2, l.Radius * 2);

                        myBrush.Color = l.GetColor();

                        formGraphics.FillEllipse(myBrush, rect);

                        if (trasmetti) { SetColor(l, ws); }
                       

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

                if (selected != null){

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

                Color ledColor = Color.FromArgb(201, 91, 0);

                ledList.Add(new Led(0, 0, 0, (int)i, ledColor));

            }

        }
        public void InizializeConnection()
        {
            using (ws = new WebSocket("ws://192.168.137.240:81"))
            {

                    Console.WriteLine("Connessione a 192.168.137.240");
                    ws.Connect();
                   
            }
        }

        

        public void SetColor(Led l ,WebSocket ws)
        {
            ws.Connect();

            byte[] bytes = BitConverter.GetBytes(l.GetColor().ToArgb());
            byte bVal = bytes[0];
            byte gVal = bytes[1];
            byte rVal = bytes[2];
            byte aVal = bytes[3];


            string led = "";
            if (l.Number <= 9) { led = "0" + l.Number.ToString(); } 
            else { led = l.Number.ToString(); }
            string r = rVal.ToString().PadLeft(3, '0'); 
            string g = gVal.ToString().PadLeft(3, '0'); 
            string b = bVal.ToString().PadLeft(3, '0'); 
            string lum = lumos.ToString().PadLeft(3, '0'); 


            string result = "#" + led + r + g + b + lum;

            Console.WriteLine("Send: " + result);
            ws.Send(result);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (trasmetti)
            {
                ws.Connect();
                ws.Send("C");
            }
        }

        private void btnTrasmetti_Click(object sender, EventArgs e)
        {
            if (trasmetti)
            {
                btnTrasmetti.BackColor = Color.LightCoral;
                trasmetti = false;
            }
            else
            {
                btnTrasmetti.BackColor = Color.LightGreen;
                trasmetti = true;
            }
        }
    }


    public class Led
    {
        private int _x;
        public int X { get => _x; set => _x = value; }

        private int _y;
        public int Y { get => _y; set => _y = value; }

        private int _radius;
        public int Radius { get => _radius; set => _radius = value; }

        private int _number;
        public int Number { get => _number; set => _number = value; }
        
        private Color _color;
        public Color Color { get => _color; set => _color = value; }
       
        private bool _IsOn;
        public bool IsOn { get => _IsOn; set => _IsOn = value; }





        public Led(int x, int y, int radius, int n, Color c)
        {
            this.X = x;
            this.Y = y;
            this.Radius = radius;
            this.Number = n;
            this.Color = c;
            this.IsOn = false;
        }


        public Color GetColor()
        {
            if (this.IsOn)
            {
                return this.Color;
            }
            else { return System.Drawing.Color.Black; }
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

            if ( Math.Pow(this.X - x, 2) + Math.Pow(this.Y - y, 2)  <= this.Radius * this.Radius )
            {
                selectedLed = this;
            }

            return selectedLed;
        }
       
    }

    
}
