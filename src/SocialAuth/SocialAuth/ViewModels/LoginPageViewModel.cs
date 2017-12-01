using SocialAuth.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Auth;
using Xamarin.Forms;

namespace SocialAuth.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        public ICommand LoginFacebookCommand { get; set; }
        public INavigation Navigation { get; set; }

        public LoginPageViewModel()
        {
            LoginFacebookCommand = new Command(LoginFacebook);
            MessagingCenter.Subscribe<object>(this, "GoBack", (sender) =>
            {
                App.Current.MainPage = new NavigationPage(new LoginPage());
            });
        }

        private void LoginFacebook()
        {
            IsBusy = true;
            MessagingCenter.Subscribe<object, string>(this, "GetUser", async (sender, token) =>
            {
                var u = await Services.Facebook.Service.GetUserAsync(token);
                App.Current.MainPage = new NavigationPage(new MainPage(u));
            });
            Navigation.PushAsync(new LoginTransitionPage());
            IsBusy = false;
        }
    }
}
