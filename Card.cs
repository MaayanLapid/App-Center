using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Memory_Game
{
    public class Card : INotifyPropertyChanged
    {
        private ImageSource _cardImage;

        public int Id { get; set; }
        // public string Location { get; set; }

        public ImageSource CardImage
        {
            get { return _cardImage; }
            set
            {
                if (_cardImage != value)
                {
                    _cardImage = value;
                    OnPropertyChanged(nameof(CardImage)); // Notify that the property has changed
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
