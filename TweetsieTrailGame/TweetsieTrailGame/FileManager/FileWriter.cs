using System;
using System.IO;

namespace TweetsieTrailGame
{
    class fileWriter : IFileWriter
    {
        public void writeFile(string sFile, string sContent)
        {
            File.WriteAllText(sFile, sContent);
        }

    }
}
