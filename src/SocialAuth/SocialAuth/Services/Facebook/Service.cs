using Newtonsoft.Json;
using SocialAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SocialAuth.Services.Facebook
{
    public class Service
    {
        public static async Task<User> GetUserAsync(string accessToken)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync($"https://graph.facebook.com/me?fields=id,name,email,gender&access_token={accessToken}");
            var user = JsonConvert.DeserializeObject<User>(json);
            user.ImageUrl = new Uri(string.Format("http://graph.facebook.com/{0}/picture?type=large", user.Id));
            return user;
        }
    }
}
