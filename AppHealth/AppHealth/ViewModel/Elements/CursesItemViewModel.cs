using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppHealth.ViewModel.Elements
{
    internal class CursesItemViewModel:ViewModelBase
    {
        private int _id;
        private string _name;
        private string _description;
        private string _startDate;
        private string _endDate;
        private int _itemsInDay;
        private int _inADay; 
        private List<Notification> _message;
        private IApplicationDbContext _dbContext;
        public int Id { get => _id; set { _id = value; OnPropertyChanged(); } }
        public string Name { get => _name; set { _name = value; OnPropertyChanged(); } }
        public string StartDate { get => _startDate; set { _startDate = value; OnPropertyChanged(); } }
        public string EndDate { get => _endDate; set { _endDate = value; OnPropertyChanged(); } }
        public int ItemsInDay { get => _itemsInDay; set { _itemsInDay = value; OnPropertyChanged(); } }
        public int InADay { get => _inADay; set { _inADay = value; OnPropertyChanged(); } }
        public string Description { get => _description; set { _description = value; OnPropertyChanged(); } }
        public List<Notification> Message { get => _message; set { _message = value; OnPropertyChanged(); } }
        public CursesItemViewModel(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
