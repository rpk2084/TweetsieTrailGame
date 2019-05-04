using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{

    class TweetsieTrailGame
    {
        private GolfCart cart;
        private Days day;

        public TweetsieTrailGame()
        {
            cart = new GolfCart();
            day = new Days();
        }

        public GolfCart Cart
        {
            get
            {
                return cart;
            }
            set
            {
                cart = value;
            }
        }

        public Days Day
        {
            get
            {
                return day;
            }
            set
            {
                day = value;
            }
        }
    }
}
