using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class SearchStudentPage : ContentPage
{
	public SearchStudentPage()
	{
		InitializeComponent();
		BindingContext = new SearchStudentViewModel();
	}
}