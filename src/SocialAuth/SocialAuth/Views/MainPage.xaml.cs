using SocialAuth.Models;
using SocialAuth.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SocialAuth.Views
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel vm;
        public MainPage(User user)
        {
            InitializeComponent();
            BindingContext = vm = new MainPageViewModel(user);
        }
    }
}
