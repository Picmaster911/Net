using AppHealth.Infrastructure;
using AppHealth.ViewModel.Elements;
using Contracts;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppHealth.ViewModel
{
    internal class AddPerssonViewModel:ViewModelBase
    {
        private string _name;
        private string _surName;
        private IApplicationDbContext _applicationDbContext;
        public EventHandler NewPersonIsReady;
        private MainWindowViewModel _mainWindowViewModel { get; set; }
        public string Name { get => _name; set { _name = value; OnPropertyChanged(); } }
        public string SurName { get => _surName; set { _surName = value; OnPropertyChanged(); } }
        public AddPerssonViewModel(IApplicationDbContext applicationDbContext, MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            _applicationDbContext = applicationDbContext;
            AddPersonCommand = new LambdaCommand(OnAddPersonCommand, CanAddPersonCommand);
        }
        #region Commands
        #region Commands AddPerson
        public ICommand AddPersonCommand { get; set; }

        private void OnAddPersonCommand (object p)
        {
            var person = new Person { Name = _name, SurName = _surName, AvatarImageData ="" };
            person.Curses = new();
           _applicationDbContext.AddAsync(person);
           _applicationDbContext.SaveChangesAsync();
            NewPersonIsReady?.Invoke (this, EventArgs.Empty);
            var lastPersonGetId = _applicationDbContext.Persons.OrderBy(x => x.Id)
                .LastOrDefault();
            _mainWindowViewModel.PersonItemVMObserv.Add(new PersonItemViewModel(_applicationDbContext) 
            { Name = Name, Surname =SurName, Id = lastPersonGetId.Id, Curses =new() });
        }
        private bool CanAddPersonCommand(object p) => String.IsNullOrEmpty(Name) ? false : true;
        #endregion
        #endregion
    }
}
