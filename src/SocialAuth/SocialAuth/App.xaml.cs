using SocialAuth.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SocialAuth
{
    public partial class App : Application
    {
        static App _Instance;
        public App()
        {
            InitializeComponent();
            _Instance = this;
            MainPage = new NavigationPage(new LoginPage());
        }

        public static App Instance
        {
            get
            {
                return _Instance;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public void NavigateToMain() {
            _Instance.MainPage = new MainPage();
        }
    }
}
