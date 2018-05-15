using DataStructures;
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
            this.BoardView = bvm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            BoardView.game = BoardView.game.PutStone((Vector2D)parameter);
            System.Diagnostics.Debug.WriteLine("Execute");
            BoardView.NotifyElement();
        }
    }
}
