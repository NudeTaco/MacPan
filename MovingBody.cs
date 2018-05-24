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
        protected direction nextOrient;

        public MovingBody(Canvas c, string name)
        {
            sprite = new Rectangle();
            this.sprite.Fill = new ImageBrush(new BitmapImage(new Uri(string.Format("pack://application:,,,/Images/{0}.png", name))));
            sprite.Height = Tile.tileSize;
            sprite.Width = Tile.tileSize;
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
        public bool checkCollision(Tile[,] tiles, direction d)
        {
            int x = (int)((this.bodyPos.X) / this.sprite.Width);
            int y = (int)((this.bodyPos.Y) / this.sprite.Height);
            switch (d)
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
            if (x < 0 || y < 0 || x >= tiles.GetLength(1) || y >= tiles.GetLength(0)) return true;
            Console.WriteLine(tiles[y, x].ToString());
            Console.WriteLine(string.Format("player at: {0}, {1}, moving {2}", this.bodyPos.X, this.bodyPos.Y, bodyOrient));
            Tile t = tiles[y, x];
            return (this.intersectsWith(t) && tiles[y, x].Type.Equals(Tile.tiles.wall));
        }

        public virtual void update(bool checkForWalls, bool rotate, Tile[,] tiles)
        {
            canMove = true;

            if ((this.bodyPos.X % Tile.tileSize == 0 && this.bodyPos.Y % Tile.tileSize == 0) || Math.Abs(this.nextOrient-this.bodyOrient) == 2)
            {
                if (checkForWalls && !this.checkCollision(tiles, nextOrient))
                {
                    bodyOrient = nextOrient;
                }
            }
            if (checkForWalls && this.checkCollision(tiles, bodyOrient))
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

        public bool intersectsWith(Tile t)
        {
            return !(this.bodyPos.X > t.Location.X + t.Sprite.Width
        || this.bodyPos.X + this.sprite.Width < t.Location.X
        || this.bodyPos.Y > t.Location.Y + t.Sprite.Width
        || this.bodyPos.Y + this.sprite.Width < t.Location.Y);
        }

    }
}
