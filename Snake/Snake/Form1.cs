using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        public bool wasRightPressed = false;
        public bool wasLeftPressed = false;
        public bool wasUpPressed = false;
        public bool wasDownPressed = false;


        List<SnakeChunk> snack = new List<SnakeChunk>();

        Graphics gfx;
        Bitmap canvas;
        Random random = new Random();
        List<Food> foods = new List<Food>();



        void reset()
        {
            snack.Clear();
            foods.Clear();
            snack.Add(new SnakeChunk(400, 400, 50, 50, Color.FromArgb(50, Color.LightSteelBlue), 50, 50));
        }

        void eat()
        {
            for (int i = 0; i < foods.Count; i++)
            {
                if (snack[0].HitBox.IntersectsWith(foods[i].HitBox))
                {
                    for (int j = 0; j < foods[i].Amount; j++)
                    {
                        if (wasRightPressed || wasLeftPressed)
                        {
                            snack.Add(new SnakeChunk(-100/*5 * (j + 1) + snack[0].x*/, -100/*snack[0].y*/, 50, 50, Color.FromArgb(50, Color.DarkOrchid), snack[0].xSpeed, snack[0].ySpeed));
                        }
                        if (wasDownPressed || wasUpPressed)
                        {
                            snack.Add(new SnakeChunk(/*snack[0].x, 50 * (j + 1) + snack[0].y*/-100,-100, 50, 50, Color.FromArgb(50, Color.DarkOrchid), snack[0].xSpeed, snack[0].ySpeed));
                        }
                        foods.Remove(foods[i]); 

                    }
                }
            }
            foods.Add(new Food(random.Next(0, ClientSize.Width) - 100, random.Next(0, ClientSize.Height) - 100, 50, 50, Color.DarkOrchid, random.Next(1, 5) + 1));
        }

        public Form1()
        {
            InitializeComponent();

            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gfx = Graphics.FromImage(canvas);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            reset();
            foods.Add(new Food(random.Next(0, ClientSize.Width) - 100, random.Next(0, ClientSize.Height) - 100, 50, 50, Color.DarkOrchid, random.Next(1, 5) + 1));


        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Right)
            //{
            //    wasRightPressed = false;
            //}
            //if (e.KeyCode == Keys.Left)
            //{
            //    wasLeftPressed = false;
            //}
            //if (e.KeyCode == Keys.Up)
            //{
            //    wasUpPressed = false;
            //}
            //if (e.KeyCode == Keys.Down)
            //{
            //    wasDownPressed = false;
            //}
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right && wasLeftPressed == false)
            {
                wasRightPressed = true;
                wasLeftPressed = false;
                wasUpPressed = false;
                wasDownPressed = false;
            }
            if (e.KeyCode == Keys.Left && wasRightPressed == false)
            {
                wasLeftPressed = true;
                wasRightPressed = false;
                wasUpPressed = false;
                wasDownPressed = false;
            }
            if (e.KeyCode == Keys.Up && wasDownPressed == false)
            {
                wasUpPressed = true;
                wasRightPressed = false;
                wasLeftPressed = false;
                wasDownPressed = false;
            }
            if (e.KeyCode == Keys.Down && wasDownPressed == false)
            {
                wasDownPressed = true;
                wasRightPressed = false;
                wasLeftPressed = false;
                wasUpPressed = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gfx.Clear(Color.DarkSlateGray);
            eat();

            //for (int i = 1; i < snack.Count; i++)
            //{
            //    //if (wasLeftPressed || wasRightPressed)
            //    //{
            //    //    snack[i].x = snack[i - 1].x + snack[i - 1].xSpeed; 
            //    //}
            //    //else if (wasDownPressed || wasUpPressed)
            //    //{
            //    //    snack[i].y = snack[i - 1].y + snack[i - 1].ySpeed;
            //    //}
            //    snack[i].x = snack[i - 1].x;
            //    snack[i].y = snack[i - 1].y;
            //}
            
            for (int i = 0; i < foods.Count; i++)
            {
                foods[i].Draw(gfx, ClientSize);
            }
            for (int i = 0; i < snack.Count; i++)
            {
                snack[i].Draw(gfx, ClientSize);
                //snack[i].move(wasRightPressed, wasUpPressed, wasLeftPressed, wasDownPressed);
            }
            for (int i = snack.Count - 1; i > 0; i--)
            {
                snack[i].x = snack[i - 1].x;
                snack[i].y = snack[i - 1].y;
            }
            snack[0].move(wasRightPressed, wasUpPressed, wasLeftPressed, wasDownPressed);


            pictureBox1.Image = canvas;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
