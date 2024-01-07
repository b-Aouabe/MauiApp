using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class UpdateAbsencePage : ContentPage
{
	public UpdateAbsencePage()
	{
		InitializeComponent();
		BindingContext = new UpdateAbsenceVM();
	}
}