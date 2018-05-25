using Model.Reversi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class ScreenCommand : ICommand
    {
        public OptionsViewModel optionsView { get; set; }
        public StartWindow startWindow { get; set; }

        public ScreenCommand(OptionsViewModel optionsView, StartWindow startWindow)
        {
            this.optionsView = optionsView;
            this.startWindow = startWindow;
        }

        public ScreenCommand(StartWindow startWindow)
        {
            this.startWindow = startWindow;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            BoardViewModel bvm;
            try
            {
                bvm = new BoardViewModel(ReversiBoard.CreateInitialState(startWindow.Width, startWindow.Height), optionsView);
            }
            catch(Exception)
            {
                bvm = new BoardViewModel(ReversiBoard.CreateInitialState(6, 6), optionsView);
            }
            this.optionsView.SelectedOptionPane = new OptionsViewModel.OptionsCategory(bvm);
        }
    }
}
