using MauiApp1.ViewModels;
using MauiApp1.Views;

namespace MauiApp1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
            // Set the default page to DefaultPage
            //MainPage = new NavigationPage(new DefaultPage { BindingContext = new DefaultPageViewModel() });
        }
    }
}
