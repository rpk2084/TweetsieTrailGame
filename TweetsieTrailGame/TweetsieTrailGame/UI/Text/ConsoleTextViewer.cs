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
            Console.Clear();
            for(int i = 0; i < viewModel.Count; ++i)
            {
                Console.Write(viewModel[i]);
            }
        }
    }
}
