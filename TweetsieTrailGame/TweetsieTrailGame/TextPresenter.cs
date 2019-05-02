using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    class TextPresenter : IPresenter
    {
        private ITextViewer viewer;

        public TextPresenter(ITextViewer textViewer)
        {
            viewer = textViewer;
        }
           
        public void showOpeningScreen()
        {
            TextViewModel viewModel = new TextViewModel();
            viewModel.Lines.Add("Tweetsie Trail Game");
            viewer.displayText(viewModel);
        }

        public void showExitMessage()
        {
            TextViewModel viewModel = new TextViewModel();
            viewModel.Lines.Add("");
            viewModel.Lines.Add("Thank you for playing Tweetsie Trail");
            viewer.displayText(viewModel);
        }
    }
}
