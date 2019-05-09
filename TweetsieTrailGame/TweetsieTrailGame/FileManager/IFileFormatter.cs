using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    interface IFileFormatter
    {
        void saveFile(ObjectList objectList, string path);
    }
}
