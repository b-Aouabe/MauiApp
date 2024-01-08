using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class UpdateAbsencePage : ContentPage
{
	public UpdateAbsencePage(UpdateAbsenceVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
		if (BindingContext is UpdateAbsenceVM obj)
		{
			obj.SetLessons();
		}
    }
}