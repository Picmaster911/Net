namespace UIProliski
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            try
            {
                MainPage = new AppShell();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    System.Diagnostics.Debugger.Break();
                }
            }
        }
    }
}
