using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class DefaultPage : ContentPage
{
	public DefaultPage()
	{
		InitializeComponent();
		BindingContext = new DefaultPageViewModel();
	}
}