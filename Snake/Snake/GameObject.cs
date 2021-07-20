using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; 

namespace Snake
{
    abstract class GameObject
    {
        public int x;
        public int y;
        public int width;
        public int height;
        public Color colour; 

        public Rectangle HitBox { get { return new Rectangle(x, y, width, height);  } }


        public GameObject(int x, int y, int width, int height, Color coloir)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.colour = coloir; 
        }

        public abstract void Draw(Graphics gfx, Size ClientSize); 
    }
}
