using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace F4perkSimc
{
    public class Perk:INotifyPropertyChanged
    {
        public string Name { get; set; }
        public Stat Parent { get; set; }
        public int Level { get; set; }
        public string Tips { get; set; }

        public List<int> SubPerk
        {
            get => _subperk;
            set
            {
                if (_subperk != value)
                {
                    _subperk = value;
                    OnPropertyChanged("SubPerk");
                }
            }
        }
        private List<int> _subperk= new List<int>();
        public int SubLevel
        {
            get => _sublevel;
            set
            {
                if (_sublevel != value)
                {
                    _sublevel = value;
                    OnPropertyChanged("SubLevel");                    
                }
            }
        }
        private int _sublevel;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
