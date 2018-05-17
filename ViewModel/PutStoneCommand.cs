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
    public class PutStoneCommand : ICommand
    {

        public BoardViewModel BoardView { get; set; }

        public PutStoneCommand(BoardViewModel bvm)
        {
            System.Diagnostics.Debug.WriteLine("PutStoneCommand");
            this.BoardView = bvm;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return BoardView.game.IsValidMove((Vector2D)parameter);
        }

        public void Execute(object parameter)
        {
            BoardView.game = BoardView.game.PutStone((Vector2D)parameter);

            BoardView.CurrentPlayer = BoardView.game.CurrentPlayer;
            BoardView.CountBlack = BoardView.game.Board.CountStones(Player.BLACK);
            BoardView.CountWhite = BoardView.game.Board.CountStones(Player.WHITE);
            System.Diagnostics.Debug.WriteLine(BoardView.CountBlack + " aantal zwart");
            System.Diagnostics.Debug.WriteLine("Execute");
            BoardView.NotifyElement();
        }
    }
}
