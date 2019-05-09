using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class TextFileParser : IFileParser
    {
        private IFileReader reader;
        public TextFileParser(IFileReader reader)
        {
            this.reader = reader;
        }

        public ObjectList parseFile(string path)
        {
            string filePath = path + ".txt";
            string content = reader.readFile(filePath);

            string[] lines = content.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            ObjectList objList = new ObjectList();

            string[] headerRow = lines[0].Split(new[] { ',' }, StringSplitOptions.None);
            foreach (string entry in headerRow)
            {
                objList.HeaderRow.Add(entry);
            }

            for(int i = 1; i < lines.Length; ++i)
            {
                string[] objRow = lines[i].Split(new[] { ',' }, StringSplitOptions.None);
                objList.ObjectRows.Add(new List<string>());
                foreach (string entry in objRow)
                {
                    objList.ObjectRows[i - 1].Add(entry);
                }
            }

            return objList;
        }
    }
}
