using MauiPhoneCatalog.Helpers;
using MauiPhoneCatalog.Views;
using PhoneCatalog.DAL.Entities;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiPhoneCatalog.ViewModels
{
    public class Transport
    {
        public PhoneItemsVM SellectedItem { get; set; }
        public MainPageVM PageVM { get; set; }  
    }
    public  class MainPageVM : ViewModelBase
    {
        private CreateCollection _createCollection;
        private int _itemId;
        public int ItemId
        {
            get => _itemId;
            set
            {
                _itemId = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<PhoneItemsVM> _phoneItems;
        public ObservableCollection<PhoneItemsVM> PhoneItems
        {
            get => _phoneItems;
            set
            {
                if (_phoneItems != value)
                {
                    _phoneItems = value;
                    OnPropertyChanged();
                }
            }
        }
        public ICommand GotoItemSreen {  get; set; }
        public ICommand GoAddPhone { get; set; }
        public ICommand ItemSelectedCommand { get; }
        public MainPageVM(CreateCollection createCollection)
        {
            _createCollection = createCollection;
            PhoneItems = new ObservableCollection<PhoneItemsVM>();
            PhoneItems = _createCollection.CreateColection();
            GotoItemSreen = new Command(async () => { await Shell.Current.GoToAsync("PhoneItemPage"); });

            ItemSelectedCommand = new Command (async (selectedItem) =>
            {
                if (selectedItem != null)
                {
                   var NselectedItem =    (PhoneItemsVM)selectedItem;
                    var navigationParameter = new Dictionary<string, object>
                    {
                        { "SelectedItem", new Transport (){ SellectedItem = NselectedItem, PageVM = this } }
                    };
                    await Shell.Current.GoToAsync(nameof(PhoneItemPage), navigationParameter);
                }
            });
           

            GoAddPhone = new Command(async () => {

                var navigationParameter = new Dictionary<string, object>
                    {
                        { "MainPageVM", this }
                    };

                await Shell.Current.GoToAsync(nameof(AddPhonePage), navigationParameter); 
            });
        }
        public void LoadData ()
        {
            PhoneItems = _createCollection.CreateColection();
        }

    }
}
