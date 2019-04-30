
using Coban.Market.Web.Models;
using System.Web.Mvc;

namespace Coban.Market.Web.Filters
{
    public class Auth : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (CurrentSession.User == null)
            {
                filterContext.Result = new RedirectResult("/Account/Account");
            }
        }
    }
}