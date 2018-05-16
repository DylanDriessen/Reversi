using DataStructures;
using Model.Reversi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class CountStoneCommand : ICommand
    {
        public BoardViewModel BoardView { get; set; }

        public CountStoneCommand(BoardViewModel bvm)
        {
            this.BoardView = bvm;
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
            BoardView.CountBlack = BoardView.game.Board.CountStones(Player.BLACK);
            BoardView.CountWhite = BoardView.game.Board.CountStones(Player.WHITE);
            System.Diagnostics.Debug.WriteLine(BoardView.CountBlack + " aantal zwart");
            BoardView.NotifyElement();
        }
    }
}
