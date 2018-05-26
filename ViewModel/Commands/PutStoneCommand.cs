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
        public OptionsViewModel optionsView { get; set; }
        public BoardViewModel BoardView { get; set; }
        public StartWindow startWindow { get; set; }
        public EndGameCommand endGameCommand { get; set; }

        public PutStoneCommand(BoardViewModel bvm)
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
            return BoardView.game.IsValidMove((Vector2D)parameter);
        }

        public void Execute(object parameter)
        {
            BoardView.game = BoardView.game.PutStone((Vector2D)parameter);
            BoardView.CurrentPlayer = BoardView.game.CurrentPlayer;
            BoardView.Height = BoardView.game.Board.Height;
            BoardView.Width = BoardView.game.Board.Width;
            BoardView.CountBlack = BoardView.game.Board.CountStones(Player.BLACK);
            BoardView.CountWhite = BoardView.game.Board.CountStones(Player.WHITE);
            if (BoardView.game.IsGameOver)
            {
                endGameCommand = new EndGameCommand(optionsView, BoardView);
            }
            BoardView.NotifyElement();
        }
    }
}
