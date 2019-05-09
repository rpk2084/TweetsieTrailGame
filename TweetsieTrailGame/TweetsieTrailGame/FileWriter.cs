using System;
using System.IO;

namespace TweetsieTrailGame
{

    class fileWriter : IFileWriter
    {
        public string writeFile(string sFile, string sContent)
        {
            try
            {
                string contents = File.WriteAllText(sFile, sContent);

                return void;

            }
            catch
            {
                throw "failed to write file" + nFile;
            }
        }

    }
