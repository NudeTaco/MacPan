using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace MacPan
{
    class Pill
    {
        private double radius;
        private Point location;
        private Rectangle sprite;
        //todo add public variables with get methods
        public bool powerPill;
        public double Radius { get => radius; }
        public Point Location { get => location; }
        public Rectangle Sprite { get => sprite;  }
        private Canvas canvas;
        //todo add constructor method
        public Pill(bool isSuperPill, Point loc, Canvas c)
        {
            //They may try to deter us, but they will never quench our thirst to code.
            this.powerPill = isSuperPill;
            this.location = loc;
            canvas = c;
            c.Children.Add(sprite);
        }
        public void destroy()
        {
            //todo add destroy logic
            this.sprite = null;
            canvas.Children.Remove(sprite);
        }
    }
}
