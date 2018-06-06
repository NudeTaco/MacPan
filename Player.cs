using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MacPan
{
    class Player : MovingBody
    {
        ImageBrush[] animation;
        //ResourceManager rm = new ResourceManager()
        //todo test powerup logic
        private bool canEat = false;
        private double powerUpLength = 10;
        private Timer powerUpTimer = new Timer();
        private int animationCounter = 0;

        public Player(Canvas c) : base(c, "MacPan")
        {

            ImageBrush ib1, ib2, ib3;
            ib1 = new ImageBrush(getImage("MacPan"));
            ib2 = new ImageBrush(getImage("MacPan1"));
            ib3 = new ImageBrush(getImage("MacPan2"));
            animation = new ImageBrush[] {ib1,ib2,ib3,ib2 };

            this.speed = 10;
            powerUpTimer.Elapsed += (sender, args) => { canEat = false; powerUpTimer.Stop();};
            this.bodyOrient = direction.none;
            this.nextOrient = direction.none;
            this.bodyPos = new Point(Tile.tileSize,Tile.tileSize);
            //todo fine tune speed
            this.speed =2;
        }
        public void update(Ghost[] ghosts,Tile[,] tiles)
        {
            this.sprite.Fill = animation[(animationCounter % 8) / 2];
            //todo add update logic
            if (Keyboard.IsKeyDown(Key.W)) this.nextOrient = direction.up;
            if (Keyboard.IsKeyDown(Key.D)) this.nextOrient = direction.right;
            if (Keyboard.IsKeyDown(Key.S)) this.nextOrient = direction.down;
            if (Keyboard.IsKeyDown(Key.A)) this.nextOrient = direction.left;
            base.update(true,true,tiles);
            checkCollision(ghosts);
            drawBody();
            animationCounter++;
        }

        private void checkCollision(Ghost[] ghosts)
        {
            foreach(Ghost g in ghosts)
            {
                this.checkCollision(g);
            }
        }
        public void powerUp()
        {

            this.canEat = true;
            powerUpTimer.Interval = powerUpLength * 1000;
            //this.sprite.OpacityMask = new SolidColorBrush(Colors.Salmon);
            powerUpTimer.Start();
        }
        public BitmapImage getImage(string file)
        {
            return new BitmapImage(new Uri(string.Format("pack://application:,,,/Images/{0}.png", file)));
        }

        public bool checkCollision(Pill p)
        {
            if (!(this.bodyPos.X > p.Location.X + p.Sprite.Width / 4
    || this.bodyPos.X + this.sprite.Width / 4 < p.Location.X
    || this.bodyPos.Y > p.Location.Y + p.Sprite.Width / 4
    || this.bodyPos.Y + this.sprite.Width / 4 < p.Location.Y))
            {
                if(p.powerPill)this.powerUp();
                return true;
            }
            else return false;
        }

    }
}