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
    public class BoardSquareViewModel : PropertyChangedEvent
    {
        private ReversiGame game;
        private Player owner;

        public Player Owner
        {
            get { return owner; }
            set { owner = value; OnPropertyChanged("owner"); }
        }

        public Player Position { get; set; }

        public Vector2D SquarePosition { get; set; }

        public BoardSquareViewModel(ReversiGame game)
        {
            this.game = game;
        }
    }
}
