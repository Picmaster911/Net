using MauiPhoneCatalog.ViewModels;

namespace MauiPhoneCatalog.Views;

public partial class PhoneItemPage : ContentPage
{
	public PhoneItemPage(PhoneItemPageVM phoneItemPageVM)
	{
		InitializeComponent();
        BindingContext = phoneItemPageVM;
    }
}