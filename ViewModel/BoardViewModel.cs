using Cells;
using DataStructures;
using Model.Reversi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class BoardViewModel : PropertyChangedEvent
    {
        public ReversiBoard board;
        public ReversiGame game;
        public Player player;
        private int blackStones;
        private int whiteStones;

        public List<BoardRowViewModel> Rows { get; set; }
        public PutStoneCommand Command { get; set; }

        public BoardViewModel()
        {
            this.game = new ReversiGame(6, 6);
            this.Rows = new List<BoardRowViewModel>();
            this.Command = new PutStoneCommand(this);      

            for (int i = 0; i < game.Board.Height; i++)
            {
                var boardRow = new BoardRowViewModel(game);
                for (int j = 0; j < game.Board.Width; j++)
                {
                    boardRow.Squares[j].Owner = game.Board[new Vector2D(j, i)];
                    boardRow.Squares[j].SquarePosition = new Vector2D(j, i);
                }
                Rows.Add(boardRow);
            }
        }

        public Player CurrentPlayer
        {
            get
            {
                return game.CurrentPlayer;
            }
            set
            {
                this.player = value; OnPropertyChanged(nameof(CurrentPlayer));
            }
        }

        public int CountBlack
        {
            get
            {
                this.blackStones = this.game.Board.CountStones(Player.BLACK);
                return blackStones;
            }
            set
            {
                blackStones = value; OnPropertyChanged(nameof(CountBlack));
                System.Diagnostics.Debug.WriteLine(blackStones + " in setter");
            }
        }

        public int CountWhite
        {
            get
            {
                this.whiteStones = this.game.Board.CountStones(Player.WHITE);
                return whiteStones;
            }
            set
            {
                whiteStones = value; OnPropertyChanged(nameof(CountWhite));
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
