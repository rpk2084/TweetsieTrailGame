using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class TextUIModel
    {
        private List<string> header;
        private List<string> options;
        private string inputPrompt;

        public TextUIModel()
        {
            header = new List<string>();
            options = new List<string>();
        }

        public List<string> Header
        {
           get
            {
                return header;
            }
            set
            {
                header = value;
            }
        }

        public List<string> Options
        {
            get
            {
                return options;
            }
            set
            {
                options = value;
            }
        }

        public string InputPrompt
        {
            get
            {
                return inputPrompt;
            }
            set
            {
                inputPrompt = value;
            }
        }
    }
}
