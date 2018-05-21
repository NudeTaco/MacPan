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
    class Tile
    {
        public enum tiles { blank, wall, ghostGate, superPill }
        private Rectangle sprite = new Rectangle();
        private Point location;
        public Point Location { get => location; }
        public Rectangle Sprite { get => sprite; }
        private tiles type;
        public tiles Type { get => type; }
        int tileSize = 100;

        public Tile(Canvas c, tiles type, Point loc)
        {

            //todo change brush based on tile type
            location = loc;
            this.type = type;
            switch(type)
            {
                case tiles.blank:
                    sprite.Fill = Brushes.Transparent;
                    break;
                case tiles.wall:
                    sprite.Fill = Brushes.Blue;
                    break;
                case tiles.ghostGate:
                    //todo replace brush
                    sprite.Fill = Brushes.Transparent;
                    break;
                case tiles.superPill:
                    //todo replace brush
                    sprite.Fill = Brushes.Transparent;
                    break;
            }
                        sprite.Height = tileSize;
                        sprite.Width = tileSize;
                        Canvas.SetTop(sprite, loc.Y);
                        Canvas.SetLeft(sprite, loc.X);
                        c.Children.Add(sprite);
        }

        public override string ToString()
        {
            return this.type.ToString() + " at: " + String.Format("{0}, {1}", location.X, location.Y);
        }


    }
}
