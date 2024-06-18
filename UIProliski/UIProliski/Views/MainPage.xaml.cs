namespace UIProliski.Views
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {

            try
            {
                InitializeComponent();
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
