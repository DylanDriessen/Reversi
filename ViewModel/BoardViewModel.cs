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
    public class BoardViewModel : INotifyPropertyChanged
    {
        public ReversiBoard board;
        public ReversiGame game;
        public Player player;
        private int blackStones;
        private int whiteStones;
        private Player playertest;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<BoardRowViewModel> Rows { get; set; }
        public PutStoneCommand Command { get; set; }
        public CountStoneCommand CountCommand { get; set; }

        public BoardViewModel()
        {
            this.game = new ReversiGame(6, 6);
            this.Rows = new List<BoardRowViewModel>();
            this.Command = new PutStoneCommand(this);
            this.CountCommand = new CountStoneCommand(this);

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


        protected void OnPropertyChanged(String property)
        {
            PropertyChangedEventHandler h = PropertyChanged;
            if (null != h)
            {
                h(this, new PropertyChangedEventArgs(property));
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
                this.player = value; OnPropertyChanged("CurrentPlayer");
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
                blackStones = value; OnPropertyChanged("CountBlack");
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
                whiteStones = value; OnPropertyChanged("CountWhite");
            }
        }
    }
}
