using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacPan
{
    class Ghost:MovingBody
    {
        public enum ghostNames{Pinky, Blinky, Inky, Clyde, Frank}
        public ghostNames ghostName { get => ghostName; set => ghostName = value; }

        //todo add constructor

        public override void update()
        {
            //add update method
        }

        //add pathfind method

    }
}
