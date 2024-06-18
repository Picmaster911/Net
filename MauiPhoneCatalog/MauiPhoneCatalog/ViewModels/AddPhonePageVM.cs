using PhoneCatalog.DAL;
using PhoneCatalog.DAL.Entities;
using System;
using System.Windows.Input;

namespace MauiPhoneCatalog.ViewModels
{
    public class AddPhonePageVM : ViewModelBase, IQueryAttributable
    {
        private AppDbContext _appDbContext;
        public AddPhonePageVM(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            ButtonAddPhone = new Command(AddItem,CanAddItem);
        }

        private bool CanAddItem(object arg)
        {
            if (String.IsNullOrEmpty(Name) || String.IsNullOrEmpty(Email) || String.IsNullOrEmpty(Phone))
            { return false; }
            else { return true; }
        }
        void RefreshCanExecutes()
        {
            (ButtonAddPhone as Command).ChangeCanExecute();
        }
        private async void AddItem(object obj)
        {
            _appDbContext.PhoneItems.Add(new PhoneItem() { Name = Name, Phone = Phone, Email =Email });
            _appDbContext.SaveChanges();
            var lastItem = _appDbContext.PhoneItems
                       .OrderByDescending(p => p.Id)
                       .FirstOrDefault();
            _mainPageVM.PhoneItems.Add(new PhoneItemsVM() { Name = Name, Phone = Phone, Email=Email, Id = lastItem.Id });
             await Shell.Current.GoToAsync("//MainPage");
        }

        private MainPageVM _mainPageVM;
        private string _name;
        private string _email;
        private string _phone;

        public string Name { get => _name; set
            { 
             _name = value;
                OnPropertyChanged();
                RefreshCanExecutes();
            }
        }

        public string Email { get => _email; set
            {
                _email = value;
                OnPropertyChanged();
                RefreshCanExecutes();
            }
        }
        public string Phone
        {
            get => _phone; set
            {
                _phone = value;
                OnPropertyChanged();
                RefreshCanExecutes();
            }
        }
        public ICommand ButtonAddPhone { get; }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("MainPageVM"))
            {
                _mainPageVM = query["MainPageVM"] as MainPageVM;
            }
        }
    }
}
