using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F4perkSimc
{
    public class Stat : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public int Point
        {
            get => _point;
            set
            {
                if (_point != value)
                {
                    _point = value;
                    OnPropertyChanged("Point");
                    OnStatPointChanged(new EventArgs());
                }
            }
        }
        private int _point;
        public string Tips { get; set; }

        public event EventHandler StatPointChanged;
        private void OnStatPointChanged(EventArgs e)
        {
            StatPointChanged?.Invoke(this,e);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
