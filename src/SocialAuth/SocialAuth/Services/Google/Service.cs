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
        public static async Task<User> GetUserAsync(string tokenType, string accessToken)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);
            var json = await httpClient.GetStringAsync("https://www.googleapis.com/userinfo/id,name,picture,email?alt=json");
            var user = JsonConvert.DeserializeObject<User>(json);
            return user;
        }
    }
}
