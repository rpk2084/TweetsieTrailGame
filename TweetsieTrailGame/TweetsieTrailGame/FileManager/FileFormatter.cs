using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame.FileManager
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
                fileContent += entry + "\t";
            }
            fileContent += "\n";
            foreach(List<string> obj in objectList.ObjectRows)
            {
                foreach (string entry in obj)
                {
                    fileContent += entry + "\t";

                    fileContent += "\n";
                }
            }
            writer.writeFile(filePath, fileContent);
        }
    }
}
