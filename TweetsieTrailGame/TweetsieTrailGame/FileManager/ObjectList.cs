using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class ObjectList
    {
        public List<string> HeaderRow;
        public List<List<string>> ObjectRows;

        public ObjectList()
        {
            HeaderRow = new List<string>();
            ObjectRows = new List<List<string>>();
        }

    }
}
