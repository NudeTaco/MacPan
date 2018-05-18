using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MacPan
{
    class MovingBody
    {
        //enum for direction
        public enum direction { up, right, down, left, none };
        protected int speed;
        protected direction bodyOrient;
        private Point bodyPos;
        protected Rectangle sprite;
        public Point BodyPos { get => bodyPos; }
        public direction BodyOrient { get => bodyOrient; }
        public Rectangle Sprite { get => sprite; }

        public MovingBody(Canvas c, string name)
        {
            sprite = new Rectangle();
            this.sprite.Fill = new ImageBrush(new BitmapImage(new Uri(string.Format("pack://application:,,,/Images/{0}.png", name))));
            sprite.Height = 128;
            sprite.Width = 128;
            c.Children.Add(sprite);
        }

        public void drawBody()
        {
            Canvas.SetTop(sprite, bodyPos.Y);
            Canvas.SetLeft(sprite, bodyPos.X);

        }

        public bool checkCollision(MovingBody other)
        {
            return !(this.bodyPos.X  > other.bodyPos.X + other.sprite.Width
    || this.bodyPos.X + this.sprite.Width < other.bodyPos.X
    || this.bodyPos.Y > other.bodyPos.Y + other.sprite.Width
    || this.bodyPos.Y + this.sprite.Width < other.bodyPos.Y);
        }

        public virtual void update()
        {
            //todo add update logic
            switch (bodyOrient)
            {
                case direction.up:
                    this.bodyPos.Y -= speed;
                    sprite.RenderTransform = new RotateTransform(270, sprite.Width / 2, sprite.Height / 2);
                    break;
                case direction.down:
                    this.bodyPos.Y += speed;
                    sprite.RenderTransform = new RotateTransform(90, sprite.Width / 2, sprite.Height / 2);
                    break;
                case direction.left:
                    this.bodyPos.X -= speed;
                    sprite.RenderTransform = new ScaleTransform(-1, 1, sprite.Width / 2, sprite.Height / 2);
                    break;
                case direction.right:
                    this.bodyPos.X += speed;
                    sprite.RenderTransform = new RotateTransform(0, sprite.Width / 2, sprite.Height / 2);
                    break;
                default:
                    Console.WriteLine("no move");
                    break;
            }
        }
    }
}
