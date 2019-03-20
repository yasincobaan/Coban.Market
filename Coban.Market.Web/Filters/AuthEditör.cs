using Coban.Market.Web.Models;
using System.Web.Mvc;
using Coban.Market.Entities.Enums;

namespace Coban.Market.Web.Filters
{
    public class AuthEditörAdmin : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (CurrentSession.User != null && 
                (CurrentSession.User.Role == MarketUserRole.Editör || 
                 CurrentSession.User.Role == MarketUserRole.FullAdmin || 
                 CurrentSession.User.Role == MarketUserRole.Admin)
                )
            {
                filterContext.Result = new RedirectResult("/Error/AccessDenied");
            }
        }
    }
}