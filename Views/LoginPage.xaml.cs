using MauiApp1.Helper;

namespace MauiApp1.Views;

public partial class LoginPage : ContentPage
{
    FireAuth fire = new FireAuth();

    public LoginPage()
    {
        InitializeComponent();
        AppShell.SetNavBarIsVisible(this, false);
    }


    private async void Button_Clicked_Register(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(RegisterPage));
    }

    private async void btn_login(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(email.Text) && password.Text.Length < 7)
            {
                await DisplayAlert("INFO", "Enter All Infromation", "OK");
                return;
            }
            else
            {
                var resUID = await fire.Login(email.Text, password.Text);
                if (string.IsNullOrEmpty(resUID))
                {
                    await DisplayAlert("Error", "Error Founded", "OK");
                }
                else
                {
                    //redirect to home page
                    await Shell.Current.GoToAsync(nameof(DefaultPage));
                    await DisplayAlert("OK", "You are loged in", "OK");
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Error Found", "OK");
        }
    }
}