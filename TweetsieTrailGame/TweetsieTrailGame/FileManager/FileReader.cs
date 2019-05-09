using System;
using System.IO;

namespace TweetsieTrailGame
{

	class fileReader : IFileReader
    {
		public string readFile(string nFile)
        {
           string text = File.ReadAllText(nFile);

           return text; 

        }

    }





}