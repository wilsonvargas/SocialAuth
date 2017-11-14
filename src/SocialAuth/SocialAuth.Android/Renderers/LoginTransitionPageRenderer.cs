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

            // this is a ViewGroup - so should be able to load an AXML file and FindView<>
            var activity = this.Context as Activity;

            var auth = new OAuth2Authenticator(
                clientId: Variables.ClientId, // your OAuth2 client id
                scope: Variables.Scope, // The scopes for the particular API you're accessing. The format for this will vary by API.
                authorizeUrl: new Uri(Variables.AuthorizeUrl), // the auth URL for the service
                redirectUrl: new Uri(Variables.RedirectUrl)); // the redirect URL for the service

            auth.Completed += (sender, eventArgs) => {
                if (eventArgs.IsAuthenticated)
                {
                    var token = eventArgs.Account.Properties["access_token"];
                    App.Instance.NavigateToMain();
                }
                else
                {
                    // The user cancelled
                }
            };

            activity.StartActivity(auth.GetUI(activity));
        }
    }
}