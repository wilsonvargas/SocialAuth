﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SocialAuth.Resources.Google {
    using System;
    using System.Reflection;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Variables {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Variables() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SocialAuth.Resources.Google.Variables", typeof(Variables).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to https://accounts.google.com/o/oauth2/token.
        /// </summary>
        internal static string AccesTokenUrl {
            get {
                return ResourceManager.GetString("AccesTokenUrl", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to https://accounts.google.com/o/oauth2/auth.
        /// </summary>
        internal static string AuthorizeUrl {
            get {
                return ResourceManager.GetString("AuthorizeUrl", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 602031139153-pco6rmu1d8i03q3lh830hggduf0q9shn.apps.googleusercontent.com.
        /// </summary>
        internal static string ClientId {
            get {
                return ResourceManager.GetString("ClientId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 0tAyt6QDp4Gz0I4KK8ti4tQM.
        /// </summary>
        internal static string ClientSecret {
            get {
                return ResourceManager.GetString("ClientSecret", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to https://www.google.com.
        /// </summary>
        internal static string RedirectUrl {
            get {
                return ResourceManager.GetString("RedirectUrl", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to openid.
        /// </summary>
        internal static string Scope {
            get {
                return ResourceManager.GetString("Scope", resourceCulture);
            }
        }
    }
}
