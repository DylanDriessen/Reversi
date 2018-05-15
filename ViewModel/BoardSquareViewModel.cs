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
    public class BoardSquareViewModel : INotifyPropertyChanged
    {
        private ReversiGame game;
        private Player owner;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(String name)
        {
            PropertyChangedEventHandler h = PropertyChanged;
            if (null != h)
            {
                h(this, new PropertyChangedEventArgs(name));
            }
        }

        public Player Owner
        {
            get { return owner; }
            set { owner = value; OnPropertyChanged("Owner"); }
        }

        public Player Position { get; set; }
        public Vector2D SquarePosition { get; set; }

        public BoardSquareViewModel(ReversiGame game)
        {
            this.game = game;
        }
    }
}
