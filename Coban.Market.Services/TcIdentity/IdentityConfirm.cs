using System;

namespace Coban.Market.Services.TcIdentity
{
    public class IdentityConfirm
    {
        public bool IConfirm(long Identity, int Birthdayyear, string Name, string Surname)
        {
            bool statu;
            try
            {
                using (TcIdentity.KPSPublicSoapClient services = new KPSPublicSoapClient())
                {
                    statu = services.TCKimlikNoDogrula(Identity, Name, Surname, Birthdayyear);
                }
            }
            catch (Exception e)
            {
                statu = false;
            }

            return statu;
        }
    }
}
