using Coban.Market.Web.Models;
using System.Web.Mvc;
using Coban.Market.Entities.Enums;

namespace Coban.Market.Web.Filters
{
    public class AuthAdmin : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (
                CurrentSession.User != null && (
                CurrentSession.User.Role != MarketUserRole.Admin ||
                CurrentSession.User.Role != MarketUserRole.FullAdmin
                ))
            {
                filterContext.Result = new RedirectResult("/Error/AccessDenied");
            }
        }
    }
}