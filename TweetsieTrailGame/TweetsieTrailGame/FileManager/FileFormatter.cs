using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class FileFormatter : IFileFormatter
    {
        private IFileWriter writer;
        public FileFormatter(IFileWriter fileWriter)
        {
            writer = fileWriter;
        }
        
        public void saveFile(ObjectList objectList, string path)
        {
            string filePath = path + ".txt";
            string fileContent = "";
            foreach(string entry in objectList.HeaderRow)
            {
                fileContent += entry + ",";
            }
            fileContent += "\n";
            foreach(List<string> obj in objectList.ObjectRows)
            {
                foreach (string entry in obj)
                {
                    fileContent += entry + ",";

                    fileContent += "\n";
                }
            }
            writer.writeFile(filePath, fileContent);
        }
    }
}
