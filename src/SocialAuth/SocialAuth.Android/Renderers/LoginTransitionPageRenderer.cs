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
using SocialAuth.Resources.Facebook;
using Xamarin.Forms.Platform.Android;
using Xamarin.Auth;
using SocialAuth.Models;

[assembly: ExportRenderer(typeof(LoginTransitionPage), typeof(LoginTransitionPageRenderer))]
namespace SocialAuth.Droid.Renderers
{
    public class LoginTransitionPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            var activity = this.Context as Activity;

            var auth = new OAuth2Authenticator(
                clientId: Variables.ClientId,
                scope: Variables.Scope, 
                authorizeUrl: new Uri(Variables.AuthorizeUrl),
                redirectUrl: new Uri(Variables.RedirectUrl));

            auth.Completed += (sender, eventArgs) => {
                if (eventArgs.IsAuthenticated)
                {
                    var token = eventArgs.Account.Properties["access_token"];
                    MessagingCenter.Send<object, string>(this, "GetUser", token);
                }
                else
                {
                    App.Current.MainPage = new NavigationPage(new LoginPage());
                }
            };

            activity.StartActivity(auth.GetUI(activity));
        }
    }
}