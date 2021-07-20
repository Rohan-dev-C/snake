using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; 

namespace Snake
{
    class SnakeChunk : GameObject
    {
        public int xSpeed;
        public int ySpeed; 

        public SnakeChunk(int x, int y, int width, int height, Color coloir, int xSpeed, int ySpeed) : base(x, y, width, height, coloir)
        {
            this.xSpeed = xSpeed;
            this.ySpeed = ySpeed; 
        }

        public override void Draw(Graphics gfx, Size ClientSize)
        {
            gfx.FillRectangle(new SolidBrush(colour), x, y, width, height);
            gfx.DrawRectangle(Pens.Black, x, y, width, height);
        }
        public void move(bool wasRightPressed, bool wasUpPressed, bool wasLeftPressed, bool wasDownPressed)
        {
            if(wasRightPressed)
            {
                xSpeed = Math.Abs(xSpeed);
                this.x+= xSpeed; 
            }
            if(wasLeftPressed)
            {
                xSpeed = -Math.Abs(xSpeed);
                this.x+= xSpeed; 
            }
            if(wasDownPressed)
            {
                ySpeed = Math.Abs(ySpeed);
                this.y+= ySpeed; 
            }
            if(wasUpPressed)
            {
                ySpeed = -Math.Abs(ySpeed); 
                this.y+= ySpeed; 
            }
        }
    }
}
