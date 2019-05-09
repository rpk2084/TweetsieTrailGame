using System;
using System.IO;

namespace TweetsieTrailGame
{

	class fileReader : IFileReader
    {
		public string readFile(string nFile)
        {
            try
            {
                string text = File.ReadAllText(nFile);

                return text; 

            }
            catch
            {
                throw "failed to load file" + nFile;
            }
        }

    }





}