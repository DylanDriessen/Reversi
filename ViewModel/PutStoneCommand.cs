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
            System.Diagnostics.Debug.WriteLine("Execute");
            BoardView.NotifyElement();
        }
    }
}
