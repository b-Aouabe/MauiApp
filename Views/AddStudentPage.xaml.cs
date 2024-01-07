using MauiApp1.DbConfig;
using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class AddStudentPage : ContentPage
{
	public AddStudentPage(AddStudentVM vm)
	{

		InitializeComponent();
		BindingContext = vm;
		AppShell.SetNavBarIsVisible(this,false);
	}
}