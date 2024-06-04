using AppHealth.ViewModel.Elements;
using Contracts;
using DAL;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace AppHealth.Model
{

    internal class CreateGlobalDO
    {
        private IApplicationDbContext _dbContext;
        public CreateGlobalDO(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ObservableCollection<PersonItemViewModel> PersonItemVMObserv = new();
        public void CreatePersonItemVM()
        {
            PersonItemVMObserv = new();
            List<Person> person = _dbContext.Persons
                .Include(t => t.Curses)
            .ThenInclude(p => p.Message).ToList();

            var personItemVMList = person.Select(x => new PersonItemViewModel(_dbContext)
            {
                Name = x.Name,
                Surname = x.SurName,
                Id = x.Id,
                AvatarImagePath = x.AvatarImageData,
                Curses = x.Curses.Select(p => new CursesItemViewModel(_dbContext)
                {
                    Name = p.Name,
                    StartDate = p.StartDate.ToString(("yy.MM.dd")),
                    EndDate = p.EndDate.ToString((("yy.MM.dd")))  ,
                    ItemsInDay = p.ItemsInDay,
                    InADay = p.InADay,
                    Description = p.Description,
                }).ToList(),
            }).ToList();

            personItemVMList.ForEach(x => PersonItemVMObserv.Add(x));
        }
    }
}
