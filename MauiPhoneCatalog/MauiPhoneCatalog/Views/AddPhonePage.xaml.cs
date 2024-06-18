using MauiPhoneCatalog.ViewModels;
using Microsoft.Maui.Controls;
namespace MauiPhoneCatalog.Views;

public partial class AddPhonePage : ContentPage
{
	public AddPhonePage()
	{
	 InitializeComponent();
      var viewModel = App.Services.GetService<AddPhonePageVM>();
      BindingContext = viewModel;
    }
}