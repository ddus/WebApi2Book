using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Security.Claims;
using System.Web;

namespace WebApi2Book.Common.Security
{
    public class UserSession : IWebUserSession
    {
        ClaimsPrincipal UserPrincipal
        {
            get
            { return ((ClaimsPrincipal)HttpContext.Current.User); }
        }

        public string ApiVersionInUse
        {
            get
            {
                const int versionIndex = 2;
                if (RequestUri.Segments.Count() < versionIndex + 1)
                {
                    return string.Empty;
                }
                else
                {
                    return RequestUri.Segments[versionIndex];
                }
            }
        }

        public Uri RequestUri
        { get { return HttpContext.Current.Request.Url; } }

        public string HttpRequestMethod
        { get { return HttpContext.Current.Request.HttpMethod; } }

        public string Firstname
        { get { return UserPrincipal.FindFirst(ClaimTypes.GivenName).Value; } }
        public string Lastname
        { get { return UserPrincipal.FindFirst(ClaimTypes.Surname).Value; } }
        public string Username
        {
          get { return UserPrincipal.FindFirst(ClaimTypes.Name).Value; }
        }

        public bool IsInRole(string roleName)
        {
          return UserPrincipal.IsInRole(roleName);
        }
    }
}
