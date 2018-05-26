using Model.Reversi;
using System;
using System.Windows.Input;

namespace ViewModel
{
    public class EndGameCommand : ICommand
    {
        public OptionsViewModel optionsView { get; set; }
        public BoardViewModel BoardView { get; set; }
        public StartWindow startWindow { get; set; }

        public EndGameCommand(OptionsViewModel optionsView, BoardViewModel bvm)
        {
            this.optionsView = optionsView;
            this.BoardView = bvm;
        }

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
            EndWindow endWindow;
            endWindow = new EndWindow(optionsView);
            if (BoardView.CountBlack > BoardView.CountWhite)
            {
                endWindow.endResult = BoardView.playerOne;
            }
            if (BoardView.CountBlack < BoardView.CountWhite)
            {
                endWindow.endResult = BoardView.playerTwo;
            }
            if (BoardView.CountBlack == BoardView.CountWhite)
            {
                endWindow.endResult = "DRAW";
            }
            this.optionsView.SelectedOptionPane = new OptionsViewModel.OptionsCategory(endWindow);          
        }
    } 
}