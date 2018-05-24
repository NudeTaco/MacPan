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
    class Pill
    {
        private double radius;
        private Point location;
        private Rectangle sprite;
        public bool powerPill;
        public double Radius { get => radius; }
        public Point Location { get => location; }
        public Rectangle Sprite { get => sprite; }
        public Pill(bool isSuperPill, Point loc, Canvas c)
        {
            //They may try to deter us, but they will never quench our thirst to code.
            this.location = loc;
            this.powerPill = isSuperPill;
            sprite = new Rectangle();
            sprite.Height = Tile.tileSize;
            sprite.Width = Tile.tileSize;
            this.sprite.Fill = new ImageBrush(new BitmapImage(new Uri(String.Format("pack://application:,,,/Images/{0}.png", powerPill ? "SuperPill" : "Pill"))));
            //this.sprite.Fill = Brushes.Red;
            Canvas.SetTop(sprite, location.Y);
            Canvas.SetLeft(sprite, location.X);
            c.Children.Add(sprite);
        }
        public void eat()
        {
            this.sprite.Fill = Brushes.Transparent;
        }
    }
}
