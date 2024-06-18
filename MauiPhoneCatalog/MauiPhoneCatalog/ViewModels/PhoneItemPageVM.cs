using PhoneCatalog.DAL;
using PhoneCatalog.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiPhoneCatalog.ViewModels
{
    public class PhoneItemPageVM : ViewModelBase, IQueryAttributable
    {
        private AppDbContext _appDbContext;
        private string _name;
        private string _email;
        private string _phone;
        private int _id;
        private MainPageVM _mainPageVM;

        public ICommand SaveButton { get; set; }
      
        public PhoneItemPageVM(AppDbContext appDbContext, MainPageVM mainPageVM)
        {
            _mainPageVM = mainPageVM;   
             _appDbContext = appDbContext;
            SaveButton = new Command(AddItemToBase);
        }
        private async void AddItemToBase ()
        {
            var test = _appDbContext.PhoneItems.ToList();
            var needItem = _appDbContext.PhoneItems.Where(item => item.Id == _id).FirstOrDefault();
            needItem.Phone = Phone;
            needItem.Email = Email;
            needItem.Name = Name;
            _appDbContext.SaveChanges();
            var itemForChange = Transport.PageVM.PhoneItems.Where(item => item.Id == _id).FirstOrDefault();
            itemForChange.Name = Name;
            itemForChange.Phone = Phone;
            itemForChange.Email = Email;
            itemForChange.Id = _id;

                 await Shell.Current.GoToAsync("//MainPage");
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

        private Transport _transport;

        public Transport Transport
        {
            get => _transport;
            set
            {
                _transport = value;
                OnPropertyChanged();
            }
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("SelectedItem"))
            {
                Transport = query["SelectedItem"] as Transport;
                Name =Transport.SellectedItem.Name; 
                Email =Transport.SellectedItem.Email;
                Phone =Transport.SellectedItem.Phone;
                _id= Transport.SellectedItem.Id;
            }
        }
    }
}
