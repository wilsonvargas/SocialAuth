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
        }

        private void LoginFacebook()
        {
            var auth = new OAuth2Authenticator(
                clientId: Resources.Facebook.Variables.ClientId, // your OAuth2 client id
                scope: Resources.Facebook.Variables.Scope, // The scopes for the particular API you're accessing. The format for this will vary by API.
                authorizeUrl: new Uri(Resources.Facebook.Variables.AuthorizeUrl), // the auth URL for the service
                redirectUrl: new Uri(Resources.Facebook.Variables.RedirectUrl)); // the redirect URL for the service

            auth.Completed += (sender, eventArgs) =>
            {
                if (eventArgs.IsAuthenticated)
                {
                    var token = eventArgs.Account.Properties["access_token"];

                }
                else
                {
                    // The user cancelled
                }
            };
        }
    }
}
