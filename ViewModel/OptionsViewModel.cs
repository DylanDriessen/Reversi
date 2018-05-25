using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ViewModel
{
    public class OptionsViewModel : INotifyPropertyChanged
    {
        public OptionsViewModel()
        {
            var StartWindow = new StartWindow(this);
            this.OptionPanes = new List<object> {
                new OptionsCategory(StartWindow),
                new OptionsCategory( new BoardViewModel(StartWindow.Board, this)),
                new OptionsCategory(new EndWindow(this))
            };
            this.SelectedOptionPane = OptionPanes.First();
        }

        public List<object> OptionPanes { get; private set; }
        public object SelectedOptionPane
        {
            get
            {
                return _selectedOptionPane;
            }
            set
            {
                _selectedOptionPane = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedOptionPane)));
            }
        }
        private object _selectedOptionPane;

        public event PropertyChangedEventHandler PropertyChanged;

        public class OptionsCategory
        {
            public OptionsCategory(object vm)
            {
                this.ViewModel = vm;
            }
            public object ViewModel { get; private set; }
            public string Name { get; private set; }
            public override string ToString()
            {
                return Name;
            }
        }
    }
}
