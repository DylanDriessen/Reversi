using System;
using Model.Reversi;

namespace ViewModel
{
    public class StartWindow : PropertyChangedEvent
    {
        public ScreenCommand screenCommand { get; set; }
        public OptionsViewModel optionsView { get; set; }
        public static ReversiBoard Board { get; set; }
        public ReversiGame game { get; set; }
        public Player player { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }
        public string playerOne { get; set; }
        public string playerTwo { get; set; }


        public StartWindow(OptionsViewModel optionsViewModel)
        {
            this.optionsView = optionsViewModel;
            try
            {
                if(playerOne == null)
                {
                    playerOne = "Sonic";
                }
                if(playerTwo == null)
                {
                    playerTwo = "Mario";
                }
                Width = 6;
                Height = 6;
                var board = new BoardViewModel();
                board.playerOne = playerOne;
                board.playerTwo = playerTwo;
            }
            catch (Exception)
            {
                if (playerOne == null)
                {
                    playerOne = "Sonic";
                }
                if (playerTwo == null)
                {
                    playerTwo = "Mario";
                }
                var board = new BoardViewModel();
                board.playerOne = playerOne;
                board.playerTwo = playerTwo;
            }
            this.screenCommand = new ScreenCommand(optionsView, this);
        }
    }
}