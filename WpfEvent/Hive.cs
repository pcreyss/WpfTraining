using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfEvent
{
    public class Hive : INotifyPropertyChanged
    {
        public string RegHive {
            get { return _regHive; }
            set { if (_regHive !=value)
                {
                    _regHive = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string _regHive;

        public Hive(string s)
        {
            _regHive = s;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
