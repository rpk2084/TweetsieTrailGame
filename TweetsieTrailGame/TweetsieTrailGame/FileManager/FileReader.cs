using System;
using System.IO;

namespace TweetsieTrailGame
{

	class FileReader : IFileReader
    {
		public string readFile(string nFile)
        {
           string text = File.ReadAllText(nFile);
           return text; 

        }

    }





}