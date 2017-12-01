using SocialAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialAuth.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private User _user;

        public User User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        public MainPageViewModel(User user)
        {
            _user = user;
        }
    }
}
