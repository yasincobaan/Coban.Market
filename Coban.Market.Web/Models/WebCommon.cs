using Coban.Market.Common;
using Coban.Market.Entities;


namespace Coban.Market.Web.Models
{
    public class WebCommon : ICommon
    {
        public string GetCurrentUsername()
        {
            MarketUser user = CurrentSession.User;

            if (user != null)
                return user.Username;
            else
                return "system";
        }
    }
}