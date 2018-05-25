using System;
using Model.Reversi;

namespace ViewModel
{
    public class StartWindow : PropertyChangedEvent
    {
        public ScreenCommand screenCommand { get; set; }
        public OptionsViewModel optionsView { get; set; }
        public static ReversiBoard Board { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }
        public string PlayerOne;
        public string PlayerTwo;


        public StartWindow(OptionsViewModel optionsViewModel)
        {
            this.optionsView = optionsViewModel;
            try
            {
                Board = ReversiBoard.CreateInitialState(Width, Height);
            }
            catch (Exception)
            {
                Board = ReversiBoard.CreateInitialState(6, 6);
            }
            this.screenCommand = new ScreenCommand(optionsView, this);
        }
    }
}