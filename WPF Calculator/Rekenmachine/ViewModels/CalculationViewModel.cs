using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Rekenmachine.ViewModels
{
    internal class CalculationViewModel : INotifyPropertyChanged
    {
        internal class Calc
        {
            public int A { get; set; }
            public int B { get; set; }
            public int Result { get; set; }
        }

        public int ValueA { get; set; }
        public int ValueB { get; set; }

        private int result;
        public ObservableCollection<Calc> History { get; set; } = new ObservableCollection<Calc>();

        public CalculationViewModel()
        {
            AddCommand = new RelayCommand(o => Add());
        }

        public ICommand AddCommand { get; }

        public int Result
        {
            get { return result; }
            set {
                result = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Result)));
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        private void Add()
        {
            Result = ValueA + ValueB;

            History.Insert(0, new Calc { A = ValueA, B = ValueB, Result = Result });
        }
    }
}
