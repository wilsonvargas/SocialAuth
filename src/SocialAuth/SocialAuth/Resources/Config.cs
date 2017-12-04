using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialAuth.Resources
{
    public static class Config
    {
        public static string ClientId { get; set; }
        public static string Scope { get; set; }
        public static string AuthorizeUrl { get; set; }
        public static string RedirectUrl { get; set; }
        public static bool IsUsingNativeUI { get; set; }
        public static string ClientSecret { get; set; }
        public static string AccesTokenUrl { get; set; }
    }
}
