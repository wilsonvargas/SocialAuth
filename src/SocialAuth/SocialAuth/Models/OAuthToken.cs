using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialAuth.Models
{
    public class OAuthToken
    {
        public string TokenType { get; set; }
        public string AccessToken { get; set; }
        public string TokenSecret { get; set; }
    }
}
