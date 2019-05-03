using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class ConsoleTextViewer : ITextViewer
    {
        public void displayText(TextViewModel viewModel)
        {
            for(int i = 0; i < viewModel.Count; ++i)
            {
                Console.WriteLine(viewModel[i]);
            }
        }
    }
}
