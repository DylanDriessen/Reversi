using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel.Commands
{
    public class NewGameCommand : ICommand
    {
        private EndWindow endWindow;

        public NewGameCommand(OptionsViewModel optionsView, EndWindow endWindow)
        {
            this.optionsView = optionsView;
            this.endWindow = endWindow;
        }

        public StartWindow startWindow { get; set; }
        public OptionsViewModel optionsView { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.optionsView.SelectedOptionPane = new OptionsViewModel.OptionsCategory(new StartWindow(optionsView));
        }
    }
}
