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
        int tileSize = 100;

        public Tile(Canvas c, tiles type, Point loc)
        {

            //todo change brush based on tile type
            location = loc;
                        sprite.Fill = Brushes.Blue;
                        sprite.Height = tileSize;
                        sprite.Width = tileSize;
                        Canvas.SetTop(sprite, loc.Y);
                        Canvas.SetLeft(sprite, loc.X);
                        c.Children.Add(sprite);
        }

    }
}
