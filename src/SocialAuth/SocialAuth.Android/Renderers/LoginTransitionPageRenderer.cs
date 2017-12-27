using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using SocialAuth.Droid.Renderers;
using SocialAuth.Views;
using SocialAuth.Resources;
using Xamarin.Forms.Platform.Android;
using Xamarin.Auth;
using SocialAuth.Models;
using Android.Support.CustomTabs;

[assembly: ExportRenderer(typeof(LoginTransitionPage), typeof(LoginTransitionPageRenderer))]
namespace SocialAuth.Droid.Renderers
{
    public class LoginTransitionPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            var activity = this.Context as Activity;
            OAuth2Authenticator auth = null;

            if (Config.IsUsingNativeUI)
            {
                auth = new OAuth2Authenticator(
                               clientId: Config.ClientId,
                               clientSecret: Config.ClientSecret,
                               scope: Config.Scope,
                               authorizeUrl: new Uri(Config.AuthorizeUrl),
                               redirectUrl: new Uri(Config.RedirectUrl),
                               accessTokenUrl: new Uri(Config.AccesTokenUrl),
                               getUsernameAsync: null,
                               isUsingNativeUI: Config.IsUsingNativeUI
                           );
            }
            else
            {
                auth = new OAuth2Authenticator(
                                clientId: Config.ClientId,
                                scope: Config.Scope,
                                authorizeUrl: new Uri(Config.AuthorizeUrl),
                                redirectUrl: new Uri(Config.RedirectUrl),
                                getUsernameAsync: null,
                                isUsingNativeUI: Config.IsUsingNativeUI
                            );
            }



            auth.Completed += (sender, eventArgs) =>
            {
                if (eventArgs.IsAuthenticated)
                {
                    var oAuthToken = new OAuthToken()
                    {
                        AccessToken = eventArgs.Account.Properties["access_token"]
                    };
                    MessagingCenter.Send<object, OAuthToken>(this, "GetUser", oAuthToken);
                }
                else
                {
                    App.Current.MainPage = new NavigationPage(new LoginPage());
                }
            };

            var authActivity = new CustomTabsIntent.Builder().Build();
            authActivity.Intent = auth.GetUI(activity);
            authActivity.LaunchUrl(activity, Android.Net.Uri.Parse(Config.AuthorizeUrl));
            Forms.Context.StartActivity(authActivity.Intent);
            //activity.StartActivity(auth.GetUI(activity));
        }
    }
}