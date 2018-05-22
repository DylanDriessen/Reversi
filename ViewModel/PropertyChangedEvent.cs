using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public abstract class PropertyChangedEvent : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(String name)
        {
            PropertyChangedEventHandler h = PropertyChanged;
            if (null != h)
            {
                h(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
