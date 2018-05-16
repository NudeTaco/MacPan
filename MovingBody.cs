using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MacPan
{
    class MovingBody
    {
        //enum for direction
        public enum direction { up, right, down, left};
        private int speed = 10;
        private direction bodyOrient;
        private Point bodyPos;
        private Rectangle sprite;
        public Point BodyPos { get => bodyPos;  }
        public direction BodyOrient { get => bodyOrient; }
        public Rectangle Sprite { get => sprite; }

        public MovingBody(Canvas c)
        {
            sprite = new Rectangle();
            sprite.Fill = Brushes.Black;
            sprite.Height = 128;
            sprite.Width = 128;
            c.Children.Add(sprite);
        }

        public void drawBody(Canvas c)
        {
            Canvas.SetTop(sprite, bodyPos.Y);
            Canvas.SetTop(sprite, bodyPos.X);

        }

        public bool checkCollision()
        {
            //todo add collision logic
            return false;
        }

        public virtual void update()
        {
            //todo add update logic
            switch(bodyOrient)
            {
                case direction.up:
                    this.bodyPos.Y -= speed;
                    break;
                case direction.down:
                    this.bodyPos.Y += speed;
                    break;
                case direction.left:
                    this.bodyPos.X -= speed;
                    break;
                case direction.right:
                    this.bodyPos.X += speed;
                    break;
                default:
                    break;
            }
        }
    }
}
