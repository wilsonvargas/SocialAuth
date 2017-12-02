using SocialAuth.iOS.Renderers;
using SocialAuth.Models;
using SocialAuth.Resources;
using SocialAuth.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(LoginTransitionPage), typeof(LoginTransitionPageRenderer))]
namespace SocialAuth.iOS.Renderers
{
    public class LoginTransitionPageRenderer : PageRenderer
    {
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            var auth = new OAuth2Authenticator(
                clientId: Config.ClientId,
                scope: Config.Scope,
                authorizeUrl: new Uri(Config.AuthorizeUrl),
                redirectUrl: new Uri(Config.RedirectUrl),
                getUsernameAsync: null,
                isUsingNativeUI: Config.IsUsingNativeUI);

            auth.Completed += (sender, eventArgs) => {
                if (eventArgs.IsAuthenticated)
                {
                    var oAuthToken = new OAuthToken()
                    {
                        AccessToken = eventArgs.Account.Properties["access_token"],
                        TokenType = eventArgs.Account.Properties["token_type"]
                    };
                    MessagingCenter.Send<object, OAuthToken>(this, "GetUser", oAuthToken);
                }
                else
                {
                    App.Current.MainPage = new NavigationPage(new LoginPage());
                }
            };
            PresentViewController(auth.GetUI(), true, null);
        }
    }
}
