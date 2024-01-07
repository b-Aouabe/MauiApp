using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Views;

namespace MauiApp1.ViewModels
{
    public partial class DefaultPageViewModel : ObservableObject
    {
        //public Command GoToSearchPageCommand { get; }

        //public DefaultPageViewModel()
        //{
        //    GoToSearchPageCommand = new Command(OnGoToSearchPageClicked);
        //}

        //private void OnGoToSearchPageClicked()
        //{
        //    // Navigate to the MainPage (SearchPage)
        //    App.Current.MainPage.Navigation.PushAsync(new SearchStudentPage { BindingContext = new SearchStudentViewModel()  });
        //}
        [RelayCommand]
        async Task GoToSearchPage()
        {
            await Shell.Current.GoToAsync(nameof(SearchStudentPage));
            //await App.Current.MainPage.Navigation.PushAsync(new SearchStudentPage());
        }

        [RelayCommand]
        async Task GoToAddStudentPage()
        {
            await Shell.Current.GoToAsync(nameof(AddStudentPage));
            //await App.Current.MainPage.Navigation.PushAsync(new AddStudentPage());
        }

        [RelayCommand]
        async Task GoToUpdateAbsencePage()
        {
            await Shell.Current.GoToAsync(nameof(UpdateAbsencePage));

            //await App.Current.MainPage.Navigation.PushAsync(new UpdateAbsencePage());
        }
    }
}
