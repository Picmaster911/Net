using UIProliski.Views;

namespace UIProliski
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("Section1DetailPage", typeof(Section1MainPage));
            Routing.RegisterRoute("Section2DetailPage", typeof(Section2MainPage));
        }
    }
}
