using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class TweetsieInputException: Exception
    {
        public TweetsieInputException(string message) : base(message) { }
    }
}
