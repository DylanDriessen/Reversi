using Model.Reversi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class Restart : ICommand
    {

        public BoardViewModel BoardView { get; set; }

        public Restart(BoardViewModel bvm)
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
            BoardView.game = new ReversiGame(BoardView.Width, BoardView.Height);
            BoardView.board = BoardView.game.Board;
            BoardView.CountBlack = BoardView.game.Board.CountStones(Player.BLACK);
            BoardView.CountWhite = BoardView.game.Board.CountStones(Player.WHITE);
            BoardView.CurrentPlayer = BoardView.game.CurrentPlayer;
            BoardView.NotifyElement();
        }
    }
}
