using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Food : GameObject
    {
        public int Amount; 
        public Food(int x, int y, int width, int height, Color coloir, int amount) : base(x, y, width, height, coloir)
        {
            this.Amount = amount; 
        }


        public override void Draw(Graphics gfx, Size ClientSize)
        {
            gfx.FillEllipse(new SolidBrush(colour), x, y, width, height);
            gfx.DrawEllipse(Pens.White, x, y, width, height);
        }
    }
}
