using MauiApp1.DbConfig;
using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class SearchStudentPage : ContentPage
{
	public SearchStudentPage()
	{
		InitializeComponent();
        AppShell.SetNavBarIsVisible(this, false);
        BindingContext = new SearchStudentViewModel(new LocalDbService());
	}

    private void fieldOfStudyPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (BindingContext is SearchStudentViewModel obj)
        {
            obj.SetLessons();
        }
    }
}