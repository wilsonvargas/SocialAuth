using Newtonsoft.Json;
using SocialAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SocialAuth.Services.Google
{
    public class Service
    {
        public static async Task<User> GetUserAsync(string accessToken)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://www.googleapis.com/oauth2/v1/userinfo?access_token=" + accessToken);
            var user = JsonConvert.DeserializeObject<User>(json);
            return user;
        }
    }
}
