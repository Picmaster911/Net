using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppHealth.ViewModel.Elements
{
    internal class NotifyItemViewModel : ViewModelBase
    {
        private int _id;
        private DateTime _dateTimeShowMassege;
        private string _messege;
        private bool _accept;
        public int Id { get => _id; set { _id = value; OnPropertyChanged(); } }
        public DateTime DateTimeShowMassege { get => _dateTimeShowMassege;
            set { _dateTimeShowMassege = value; OnPropertyChanged(); } }
        public string Messege { get => _messege; set { _messege = value; OnPropertyChanged(); } }
        public bool Accept { get => _accept; set { _accept = value; OnPropertyChanged(); } }

    }
}
