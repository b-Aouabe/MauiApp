using MauiApp1.Views;

namespace MauiApp1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(RegisterPage),typeof(RegisterPage));
            //Routing.RegisterRoute(nameof(LoginPage),typeof(LoginPage));
            Routing.RegisterRoute(nameof(DefaultPage),typeof(DefaultPage));
            Routing.RegisterRoute(nameof(AddStudentPage),typeof(AddStudentPage));
            Routing.RegisterRoute(nameof(DetailsPage),typeof(DetailsPage));
            Routing.RegisterRoute(nameof(SearchStudentPage),typeof(SearchStudentPage));
            Routing.RegisterRoute(nameof(UpdateAbsencePage),typeof(UpdateAbsencePage));
        }
    }
}
