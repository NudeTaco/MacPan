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
        public ghostNames ghostName;

        //todo add constructor
        public Ghost(ghostNames name) : base()
        {
            this.ghostName = name;
        }
        public override void update()
        {
            //add update method
        }

        //add pathfind method

    }
}
