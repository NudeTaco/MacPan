using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MacPan
{
    class Ghost : MovingBody
    {
        public enum ghostNames { Pinky, Blinky, Inky, Clyde, Frank }
        public ghostNames ghostName;

        public Ghost(ghostNames name, Canvas c) : base(c, new Uri("pack://application:,,,/Images/MacPan.png"))
        {
            ghostName = name;
        }
        public override void update()
        {
            //add update method
        }

        //add pathfind method

    }
}
