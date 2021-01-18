

using System.ComponentModel;

namespace ChatBot
{
    class Chat : INotifyPropertyChanged
    {
        private string _mensaje;
        private string _emisor;

        public string Mensaje
        {
            get => _mensaje;
            set
            {
                _mensaje = value;
                NotifyPropertyChanged("Mensaje");
            }
        }

        public string Emisor
        {
            get => _emisor;
            set
            {
                _emisor = value;
                NotifyPropertyChanged("Emisor");
            }
        }

        public Chat()
        {
        }

        public Chat(string mensaje, string emisor)
        {
            this._mensaje = mensaje;
            this._emisor = emisor;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
