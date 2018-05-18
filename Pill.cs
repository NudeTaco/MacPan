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
    class Pill
    {
        private double radius;
        private Point location;
        private Rectangle sprite;
        public bool powerPill;
        public double Radius { get => radius; }
        public Point Location { get => location; }
        public Rectangle Sprite { get => sprite; }
        public Pill(Canvas c)
        {
            sprite = new Rectangle();
            sprite.Height = 10;
            sprite.Width = 10;
            sprite.Fill = Brushes.Black;
            Canvas.SetTop(sprite, location.Y);
            Canvas.SetTop(sprite, location.X);
            c.Children.Add(sprite);
        }
        public Pill(bool isSuperPill, Point loc)
        {
            //They may try to deter us, but they will never quench our thirst to code.
            this.powerPill = isSuperPill;
            this.location = loc;
        }
        public void destroy()
        {
            //todo add destroy logic
        }
    }
}
