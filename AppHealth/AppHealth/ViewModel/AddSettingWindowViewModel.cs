using AppHealth.Infrastructure;
using AppHealth.Model;
using AppHealth.View;
using AppHealth.View.Elements;
using AppHealth.ViewModel.Elements;
using Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;


namespace AppHealth.ViewModel
{
    internal class AddSettingWindowViewModel:ViewModelBase
    {
        private string _nameCurs;
        private DateTime _startDate = DateTime.Now;
        private DateTime _endDate = DateTime.Now;
        private int[] _itemsInDaySource = [1, 2, 3, 4]; 
        private int[] _inADaySource = [1, 2, 3, 4];
        private int _inADay = 1;
        private int _itemsInDay = 1;
        private string _description;
        private IApplicationDbContext _applicationDbContext;
        PersonItemViewModel _personItem;
        private Window _allNotifyColWindow;
        private Window _mainWindow;
        public ObservableCollection<CursesItemViewModel> CursesItems {  get; set; }

        public string NameCurs {get { return _nameCurs;} set { _nameCurs = value; OnPropertyChanged();}}
        public DateTime StartDate { get { return _startDate; } set { _startDate = value; OnPropertyChanged(); } }
        public DateTime EndDate { get { return _endDate; } set { _endDate = value; OnPropertyChanged(); } }

        public int[] ItemsInDaySource { get { return _itemsInDaySource; } }
        public int[] InADaySource { get { return _inADaySource; } }
        public int ItemsInDay { get { return _itemsInDay; } set { _itemsInDay = value; OnPropertyChanged(); } }
        public int InADay { get { return _inADay; } set { _inADay = value; OnPropertyChanged(); } }
        public string Description { get { return _description; } set { _description = value; OnPropertyChanged(); } }
        public AddSettingWindowViewModel(IApplicationDbContext applicationDbContext, PersonItemViewModel personItem )
        {
            ShowAllNotifyColWindowCommand = new LambdaCommand(OnShowAllNotifyColWindowCommand, CanShowAllNotifyColWindowCommand);
            AddCursButton = new LambdaCommand(OnAddCursButton, CanAddCursButon);
            ButtonDeleteItem = new LambdaCommand(OnButtonDeleteItem, CanButtonDeleteItem);
            _mainWindow = Application.Current.MainWindow;
            _applicationDbContext = applicationDbContext;
            _personItem = personItem;
            CursesItemVM();
        }
        private void CursesItemVM()
        {
            CursesItems = new();
            if (_personItem.Curses != null)
            {
                _personItem.Curses.ToList().ForEach(curses => { CursesItems.Add(curses); });
            }         
        }
        #region  ButtonCommandsMethod
        public ICommand AddCursButton {get; set;}   

        private void OnAddCursButton (object p)
        {
            var createCurs = new CreateCurs(_applicationDbContext);
            var notification =  createCurs.CreatorCurs(StartDate, EndDate, ItemsInDay, InADay, NameCurs);

            var newItemCurs = new CursesItemViewModel(_applicationDbContext)
            {
                Name = NameCurs,
                StartDate = StartDate.ToString(("yy.MM.dd")),
                EndDate = EndDate.ToString(("yy.MM.dd")),
                ItemsInDay = ItemsInDay,
                InADay = InADay,
                Description = Description
            };
            CursesItems.Add(newItemCurs);
            _personItem.Curses.Add(newItemCurs);

            var person = _applicationDbContext.Persons.Where(x => x.Id == _personItem.Id).FirstOrDefault();
            person.Curses.Add(new Contracts.CursesItem()
            {
                Name = NameCurs,
                StartDate = StartDate,
                EndDate = EndDate,
                ItemsInDay = ItemsInDay,
                InADay = InADay,
                Description = Description,
                Message = notification
            });
            _applicationDbContext.SaveChangesAsync();

           
        }
        private bool CanAddCursButon(object p) =>
            (string.IsNullOrEmpty(NameCurs) || string.IsNullOrEmpty(Description)) ? false : true;

        #endregion
        #region ButtonDeleteItem
        public ICommand ButtonDeleteItem {  get; set; }
        
        private  void OnButtonDeleteItem (object p)
        {
             var cursesItem = p as CursesItemViewModel;
            if (cursesItem != null)
            {
                CursesItems.Remove(cursesItem);
                _personItem.Curses.Remove(cursesItem);
               var person = _applicationDbContext.Persons.Where(x => x.Id == _personItem.Id).FirstOrDefault();
                var needItem =   person.Curses.Where(x => x.Id != cursesItem.Id).FirstOrDefault();
                if (needItem != null)
                {
                    person.Curses.Remove(needItem);
                }
                _applicationDbContext.SaveChangesAsync();
            }          
        }
        private bool CanButtonDeleteItem (object p)
        {
            return true;
        }

        #endregion

        public ICommand ShowAllNotifyColWindowCommand { get; }

        private void OnShowAllNotifyColWindowCommand(object p)
        {
            var cursesItem = p as CursesItemViewModel;
            _allNotifyColWindow = new AllNotifyColWindow();
            var listMesage = cursesItem.Message;
            var allNotifyColWindowFM = new AllNotifyColWindowViewModel(CreateColection(listMesage));
            _allNotifyColWindow.DataContext = allNotifyColWindowFM;
            _allNotifyColWindow.Owner = _mainWindow;
            _allNotifyColWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            _allNotifyColWindow.ShowDialog();
        }
        private bool CanShowAllNotifyColWindowCommand(object p)
        {
            return true;
        }

        private ObservableCollection<NotifyItemViewModel> CreateColection (List <Notification> list )
        {
         var observColection = new ObservableCollection <NotifyItemViewModel> ();
            list.ForEach(x => observColection.Add(new NotifyItemViewModel {
                Id = x.Id,
                Messege = x.Message,
                Accept = x.Accept,
                DateTimeShowMassege = x.DateTimeShowMassege,
            }));
            return observColection; 
        }
    }
}
