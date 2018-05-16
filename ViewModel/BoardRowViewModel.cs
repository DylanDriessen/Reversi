using Model.Reversi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class BoardRowViewModel
    {
        public ReversiGame game;
        public List<BoardSquareViewModel> Squares { get; set; }

        public BoardRowViewModel(ReversiGame game)
        {
            this.game = game;
            this.Squares = setSquares;
        }

        public List<BoardSquareViewModel> setSquares
        {
            get
            {
                List<BoardSquareViewModel> result = new List<BoardSquareViewModel>();
                for (var column = 0; column < game.Board.Width; column++)
                {
                    result.Add(new BoardSquareViewModel(game));
                }
                return result;
            }
        }
    }
}
