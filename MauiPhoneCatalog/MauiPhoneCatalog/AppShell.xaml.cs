using MauiPhoneCatalog.Views;

namespace MauiPhoneCatalog
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(PhoneItemPage), typeof(PhoneItemPage));
            Routing.RegisterRoute(nameof(AddPhonePage), typeof(AddPhonePage));  
        }
    }
}
