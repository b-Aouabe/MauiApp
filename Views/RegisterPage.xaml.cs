using MauiApp1.Helper;

namespace MauiApp1.Views;

public partial class RegisterPage : ContentPage
{
    FireAuth helper = new FireAuth();
    public RegisterPage()
    {
        InitializeComponent();

        AppShell.SetNavBarIsVisible(this, false);
    }


    private async void btn_Create_account(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(email.Text) && password.Text.Length < 7)
            {
                await DisplayAlert("Info", "Invalid Infromation", "OK");
                return;
            }
            else
            {
                var resUID = await helper.Create(email.Text, password.Text);
                if (string.IsNullOrEmpty(resUID))
                {
                    await DisplayAlert("Error", "You Don't Create Account", "OK");
                    return;
                }
                else
                {
                    await DisplayAlert("OK", "Account Created Successfuly", "OK");
                    email.Text = string.Empty;
                    password.Text = string.Empty;
                    await Shell.Current.GoToAsync(nameof(LoginPage));
                }

            }

        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("EMAIL_EXISTS"))
            {
                await DisplayAlert("Error", "Email Already Exist", "OK");
            }
            else
            {
                await DisplayAlert("Error", "Failed Creating Account", "OK");
            }

        }
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        email.Text = string.Empty;
        password.Text = string.Empty;
        await Shell.Current.GoToAsync("..", animate: true);
    }
}