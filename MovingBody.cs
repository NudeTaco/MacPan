using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace MacPan
{
    class MovingBody
    {
        //enum for direction
        public enum direction { up, right, down, left};
        private direction bodyOrient;
        private Point bodyPos;
        private Rectangle sprite;
        public Point BodyPos { get => bodyPos;  }
        public direction BodyOrient { get => bodyOrient; }
        public Rectangle Sprite { get => sprite; }


        public void drawBody()
        {

        }

        public bool checkCollision()
        {
            return false;
        }

        public virtual void update()
        {

        }
    }
}
