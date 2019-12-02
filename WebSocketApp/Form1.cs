using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace WebSocketApp
{
    public partial class Form1 : Form
    {
        public List<Led> ledList = new List<Led>();
        public int lumos = 200;



        public Form1()
        {
            InitializeComponent();

            Random rnd = new Random();

            
            for (int i = 0; i < 11; i++)
            {
                Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
               
                ledList.Add(new Led(0, 0, 0, (int)i,randomColor));

            }

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

            for (int i = 0; i < 11; i++)
            {
                //origine del led lungo la circonferenza 
                X = Cx + (r * Math.Cos(angle));
                Y = Cy + (r * Math.Sin(angle));


  
                foreach (Led l  in ledList.Where(w => w.Number == i))
                {
                    l.X = (int)X +( (int)ledDiameter/2);
                    l.Y = (int)Y + ((int)ledDiameter/2);
                    l.Radius = (int)ledDiameter / 2;

                    Rectangle rect = new Rectangle((int)X,(int)Y, l.Radius*2, l.Radius*2);

                    myBrush.Color = l.Color;

                    formGraphics.FillEllipse(myBrush, rect);

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
                    MessageBox.Show(selected.Number.ToString());
                }
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




        public Led(int x, int y, int radius, int n, Color c)
        {
            this.X = x;
            this.Y = y;
            this.Radius = radius;
            this.Number = n;
            this.Color = c;
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
