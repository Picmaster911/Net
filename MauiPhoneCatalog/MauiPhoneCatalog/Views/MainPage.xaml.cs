using MauiPhoneCatalog.ViewModels;

namespace MauiPhoneCatalog.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageVM _viewModel;
        public MainPage()
        {
            InitializeComponent();
            var viewModel = App.Services.GetService<MainPageVM>();
            BindingContext = viewModel;
            _viewModel = viewModel;
            // BindingContext = new MainPageVM();
        }

    }

}
