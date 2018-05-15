using DataStructures;
using Model.Reversi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class BoardViewModel
    {
        public ReversiBoard board;
        public ReversiGame game;

        public List<BoardRowViewModel> Rows { get; set; }
        public PutStoneCommand Command { get; set; }

        public BoardViewModel()
        {
            this.game = new ReversiGame(6, 6);
            this.Rows = new List<BoardRowViewModel>();


            for (int i = 0; i < game.Board.Height; i++)
            {
                var boardRow = new BoardRowViewModel(game);
                for (int j = 0; j < game.Board.Width; j++)
                {
                    boardRow.Squares[j].Owner = game.Board[new Vector2D(j, i)];
                    System.Diagnostics.Debug.WriteLine(boardRow.Squares[j].Owner + " Owner");
                    boardRow.Squares[j].SquarePosition = new Vector2D(j, i);
                }
                Rows.Add(boardRow);
            }
        }

        public void NotifyElement()
        {
            this.board = game.Board;
            for (int i = 0; i < board.Height; i++)
            {
                for (int j = 0; j < board.Width; j++)
                {
                    Rows[i].Squares[j].Owner = game.Board[new Vector2D(j, i)];
                }
            }
        }
    }
}
