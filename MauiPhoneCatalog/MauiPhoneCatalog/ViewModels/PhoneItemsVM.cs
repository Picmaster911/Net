using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiPhoneCatalog.ViewModels
{
    public class PhoneItemsVM: ViewModelBase
    {
        private int _id;
        private string _name;
        private string _email;
        private string _phone;

        public int Id
        {
            get => _id; set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get => _name; set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _email; set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        public string Phone
        {
            get => _phone; set
            {
                _phone = value;
                OnPropertyChanged();
            }
        }
    }
}
