using SocialAuth.Models;
using SocialAuth.Resources;
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
        public ICommand SocialLoginCommand { get; set; }
        public INavigation Navigation { get; set; }

        public LoginPageViewModel()
        {
            SocialLoginCommand = new Command<string>(SocialLogin);
        }

        private void SocialLogin(string provider)
        {
            switch (provider)
            {
                case "Facebook":
                    Config.ClientId = Resources.Facebook.Variables.ClientId;
                    Config.ClientSecret = "";
                    Config.AccesTokenUrl = "https://accounts.google.com/o/oauth2/token";
                    Config.AuthorizeUrl = Resources.Facebook.Variables.AuthorizeUrl;
                    Config.RedirectUrl = Resources.Facebook.Variables.RedirectUrl;
                    Config.Scope = Resources.Facebook.Variables.Scope;
                    Config.IsUsingNativeUI = false;
                    MessagingCenter.Subscribe<object, OAuthToken>(this, "GetUser", async (sender, oAuthToken) =>
                    {
                        var u = await Services.Facebook.Service.GetUserAsync(oAuthToken.AccessToken);
                        Application.Current.MainPage = new NavigationPage(new MainPage(u));
                    });
                    break;
                case "Google":
                    Config.ClientId = Resources.Google.Variables.ClientId;
                    Config.ClientSecret = Resources.Google.Variables.ClientSecret;
                    Config.AccesTokenUrl = Resources.Google.Variables.AccesTokenUrl;
                    Config.AuthorizeUrl = Resources.Google.Variables.AuthorizeUrl;
                    Config.RedirectUrl = Resources.Google.Variables.RedirectUrl;
                    Config.Scope = Resources.Google.Variables.Scope;
                    Config.IsUsingNativeUI = true;
                    MessagingCenter.Subscribe<object, OAuthToken>(this, "GetUserGoogle", async (sender, oAuthToken) =>
                    {
                        var u = await Services.Google.Service.GetUserAsync(oAuthToken.AccessToken);
                        Application.Current.MainPage = new NavigationPage(new MainPage(u));
                    });
                    break;
            }
            
            Navigation.PushAsync(new LoginTransitionPage());
        }
    }
}
