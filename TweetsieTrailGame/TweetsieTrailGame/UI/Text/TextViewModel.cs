using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class TextViewModel
    {
        private List<string> textLines;

        public TextViewModel()
        {
            textLines = new List<string>();
        }

        public List<string> Lines
        {
            get
            {
                return textLines;
            }
            set
            {
                textLines = value;
            }
        }

        public string this[int index]
        {
            get
            {
                return textLines[index];
            }
            set
            {
                textLines[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return textLines.Count;
            }
        }
    }
}
