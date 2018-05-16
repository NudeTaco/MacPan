using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Controls;

namespace MacPan
{
    class Player : MovingBody
    {
        private bool canEat = false;
        private double powerUpLength = 0;
        private Timer powerUpTimer;
        //todo add constructor method
        public Player(Canvas c) : base(c)
        {

        }
        public override void update()
        {
            //todo add update logic
        }
        public void powerUp()
        {
            //add powerup logic
        }
    }
}