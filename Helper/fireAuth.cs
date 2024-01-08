using Firebase.Auth.Providers;
using Firebase.Auth;

namespace MauiApp1.Helper
{
    public class FireAuth
    {
        private static FirebaseAuthConfig config = new FirebaseAuthConfig()

        {
            ApiKey = "AIzaSyD2lHNpPgjEDeQSNBF0zPNxxXdIk6vyjbU",
            AuthDomain = "mauiauth-3680b.firebaseapp.com",
            Providers = new FirebaseAuthProvider[]
            {
              new EmailProvider()
            }

        };

        FirebaseAuthClient client = new FirebaseAuthClient(config);

        //events



        //create account
        public async Task<string> Create(string Email, string Password)
        {
            var res = await client.CreateUserWithEmailAndPasswordAsync(Email, Password);
            return res.User.Info.Uid.ToString();
        }
        public async Task<string> Login(string email, string password)
        {
            var res = await client.SignInWithEmailAndPasswordAsync(email, password);
            return res.User.Info.Uid.ToString();
        }
    }
}
