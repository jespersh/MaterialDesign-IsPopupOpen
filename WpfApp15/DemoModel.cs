using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp15
{
    class DemoModel : INotifyPropertyChanged
    {
        private bool _isPopupOpen;
        private bool _yesNo;

        public bool IsPopupOpen
        {
            get => _isPopupOpen;
            set
            {
                _isPopupOpen = value;
                OnPropertyChanged();
            }
        }

        public bool YesNo
        {
            get => _yesNo; 
            set
            {
                _yesNo = value;
                OnPropertyChanged();
            }
        }

        public ICommand SetToFalseCommand { get; }
        public ICommand SetToTrueCommand { get; }

        public DemoModel()
        {
            SetToFalseCommand = new AnotherCommandImplementation(SetToFalse);
            SetToTrueCommand = new AnotherCommandImplementation(SetToTrue);
        }

        private void SetToFalse(object obj)
        {
            IsPopupOpen = false;
        }

        private void SetToTrue(object obj)
        {
            IsPopupOpen = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
