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
        protected Point bodyPos;
        protected Rectangle sprite;
        public Point BodyPos { get => bodyPos; }
        public direction BodyOrient { get => bodyOrient; }
        public Rectangle Sprite { get => sprite; }
        private bool canMove = false;

        public MovingBody(Canvas c, string name)
        {
            sprite = new Rectangle();
            this.sprite.Fill = new ImageBrush(new BitmapImage(new Uri(string.Format("pack://application:,,,/Images/{0}.png", name))));
            sprite.Height = 100;
            sprite.Width = 100;
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
        public bool checkCollision(Tile[,] tiles)
        {
            int x = (int) (this.bodyPos.X / this.sprite.Width);
            int y = (int)(this.bodyPos.Y / this.sprite.Height);
            if (!((this.bodyPos.X / this.sprite.Width) - x>0.95 || (this.bodyPos.X / this.sprite.Width) - x < 0.05)&& (bodyOrient == direction.left || bodyOrient == direction.right) ) return false;
            if (!((this.bodyPos.Y / this.sprite.Height) - y > 0.95 || (this.bodyPos.Y / this.sprite.Height) - y < 0.05) && (bodyOrient == direction.up || bodyOrient == direction.down)) return false;
            switch (BodyOrient)
            {
                case direction.up:
                    y--;
                    break;
                case direction.right:
                    x++;
                    break;
                case direction.down:
                    y++;
                    break;
                case direction.left:
                    x--;
                    break;
                default:
                    return false;
            }
            if (x < 0 || y < 0 || x >= tiles.GetLength(1) || y >= tiles.GetLength(0)) return false;
            Console.WriteLine(tiles[x, y].ToString());
            if (tiles[y, x].Type.Equals(Tile.tiles.wall)) return true;
            else return false;
        }

        public virtual void update(bool checkForWalls, bool rotate, Tile[,] tiles)
        {
            canMove = true;
            if(checkForWalls && this.checkCollision(tiles))
            {
                canMove = false;
            }
            switch (bodyOrient)
            {
                case direction.up:
                    if(canMove) this.bodyPos.Y -= speed;
                    if(rotate) sprite.RenderTransform = new RotateTransform(270, sprite.Width / 2, sprite.Height / 2);
                    break;
                case direction.down:
                    if (canMove) this.bodyPos.Y += speed;
                    if (rotate) sprite.RenderTransform = new RotateTransform(90, sprite.Width / 2, sprite.Height / 2);
                    break;
                case direction.left:
                    if (canMove) this.bodyPos.X -= speed;
                    if (rotate) sprite.RenderTransform = new ScaleTransform(-1, 1, sprite.Width / 2, sprite.Height / 2);
                    break;
                case direction.right:
                    if (canMove) this.bodyPos.X += speed;
                    if (rotate) sprite.RenderTransform = new RotateTransform(0, sprite.Width / 2, sprite.Height / 2);
                    break;
                default:
                    //Console.WriteLine("no move");
                    break;
            }
        }
        public virtual void update()
        {
            update(false, false, null);
        }
    }
}
