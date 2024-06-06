using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiAppHW
{
    internal class MauiProgramVM : INotifyPropertyChanged
    {
        public ICommand CommandLoadResume { get; }

        private string _displayResume = "Нажмите кнопку и посмотрите резюме";

        public event PropertyChangedEventHandler? PropertyChanged;

        public MauiProgramVM()
        {
            CommandLoadResume = new Command(OnUpdateText);
        }

        private void OnUpdateText()
        {
            DisplayResume = "И если вы не знаете, как правильно написать резюме, просмотрите образец резюме других специалистов на портале Jobs.ua";
        }
        public string DisplayResume
        {
            get => _displayResume;
            set
            {
                _displayResume = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
