using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;


namespace shiddypong
{
    public partial class Form1 : Form
    {

        public Bitmap canvas;
        public float PIf = (float)Math.PI;

        public float lefty = 125;
        public float righty = 125;
        public float dr = 0.0174533f;

        public Graphics g;

        public Random rnd;

        ball b;
        public Form1()
        {
            InitializeComponent();
            canvas = new Bitmap(500, 500);
            g = Graphics.FromImage(canvas);
            b = new ball(25, 125, 1, 0, 2 * PIf);
            rnd = new Random();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GAMELOOP.Start();
            MOVLOOP.Start();
            b.dx = (float)Math.Cos(b.a);
            b.dy = (float)Math.Sin(b.a);
        }

        private void MOVLOOP_Tick(object sender, EventArgs e)
        {
            //left paddel

            if (Keyboard.IsKeyDown(Key.W))
            {
                if(lefty > 20)
                {
                    lefty -= 5f;
                }
            }
            if (Keyboard.IsKeyDown(Key.S))
            {
                if (lefty < 225)
                {
                    lefty += 5f;
                }
            }

            //right paddel
            if (Keyboard.IsKeyDown(Key.I))
            {
                if (righty > 20)
                {
                    righty -= 5f;
                }
            }
            if (Keyboard.IsKeyDown(Key.K))
            {
                if (righty < 225)
                {
                    righty += 5f;
                }
            }
        }

        bool hl = false;
        bool hr = false;
        bool ht = false;
        bool hb = false;
        int death = 0;
        private void GAMELOOP_Tick(object sender, EventArgs e)
        {
            b.dx = (float)Math.Cos(b.a);
            b.dy = (float)Math.Sin(b.a);
            b.x += b.dx * 8;
            b.y += b.dy * 8;

            //Console.WriteLine(b.y + " " + (lefty + 50) + " " + lefty);

            if((b.y >= lefty - 25 && b.y <= lefty + 25) && b.x <= 10 && !hl)
            {
                //hit
                float isc = lefty - b.y;
                b.a = b.a + PIf - -((float)Math.Sin(isc) / 2);
                Console.WriteLine(isc);
                hl = true;
            }
            if ((b.y >= righty - 25 && b.y <= righty + 25) && b.x >= 485 && !hr)
            {
                //hit
                float isc = righty - b.y;
                b.a = b.a + PIf - -((float)Math.Sin(isc) / 2);
                Console.WriteLine(isc);
                hr = true;
            }
            if(b.y <= 0 && !ht)
            {
                Console.WriteLine("hit roof");
                //hit roof
                b.a = -b.a;
                ht = true;
            }
            if (b.y >= 250 && !hb)
            {
                //hit floor
                Console.WriteLine("hit floor");
                b.a = -b.a;
                hb = true;
            }

            if(b.y > 0 && b.y < 250 && b.x > 10 && b.x < 485)
            {
                hl = false;
                hr = false;
                ht = false;
                hb = false;
            }

            if (b.x < 0 || b.x > 500)
            {
                b = new ball(25, 125, 1, 0, 2 * PIf);
                death = 5;
            }

            drawGame();
        }

        public void drawGame()
        {
            if (death > 0)
            {
                g.FillRectangle(Brushes.Red, 0, 0, 500, 250);
                death--;
            }
            else
            {
                g.FillRectangle(Brushes.White, 0, 0, 500, 250);
            }

            g.DrawRectangle(Pens.Black, 10, lefty - 25, 5, 50);
            g.DrawRectangle(Pens.Black, 485, righty - 25, 5, 50);
            g.FillEllipse(Brushes.Black, b.x - 5, b.y - 5, 10, 10);
            g.DrawLine(Pens.Red, b.x, b.y, b.x+ b.dx * 10, b.y + b.dy * 10);
            PBMAIN.Image = canvas;
        }

        private void KEYPRESS(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.R)
            {
                b = new ball(25, 125, 1, 0, 2 * PIf);
            }
        }
    }

    public class ball
    {
        public ball(float x, float y, float dx, float dy, float a)
        {
            this.x = x;
            this.y = y;
            this.dx = dx;
            this.dy = dy;
            this.a = a;
        }

        public float x;
        public float y;
        public float dx;
        public float dy;
        public float a;
    }
}


