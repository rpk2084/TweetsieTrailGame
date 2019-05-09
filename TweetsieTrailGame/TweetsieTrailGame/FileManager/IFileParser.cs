using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    interface IFileParser
    {
        ObjectList parseFile(string path);
    }
}
