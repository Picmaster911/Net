using MauiPhoneCatalog.ViewModels;
using PhoneCatalog.DAL;
using PhoneCatalog.DAL.Entities;
using System.Collections.ObjectModel;

namespace MauiPhoneCatalog.Helpers
{
    public class CreateCollection
    {
        private AppDbContext _appDbContext;
        public static ObservableCollection<PhoneItemsVM> _phoneItems { get; set; }

        public CreateCollection(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            CreateColection();
        }
        public ObservableCollection<PhoneItemsVM> CreateColection()
        {
            _phoneItems = new();
            var test = _appDbContext.PhoneItems.ToList();
            test.ForEach(item => _phoneItems.Add(new PhoneItemsVM() {
                        Id = item.Id, 
                        Name = item.Name,
                        Email = item.Email,
                        Phone = item.Phone,                        
                    }));
            return _phoneItems; 
        }
    }
}
