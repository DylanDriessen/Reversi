using Model.Reversi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Commands;

namespace ViewModel
{
    public class EndWindow : PropertyChangedEvent
    {
        public ReversiGame game { get; set; }
        public Player player;
        public string endResult { get; set; }

        public BoardViewModel bvm { get; set; }
        public OptionsViewModel optionsView { get; set; }
        public EndGameCommand endGameCommand { get; set; }
        public StartWindow startWindow { get; set; }
        public NewGameCommand newGameCommand { get; set; }

        public EndWindow(OptionsViewModel optionsViewModel)
        {
            this.optionsView = optionsViewModel;
            this.endGameCommand = new EndGameCommand(optionsView, bvm);
            this.newGameCommand = new NewGameCommand(optionsView, this);
        }
    }
}

