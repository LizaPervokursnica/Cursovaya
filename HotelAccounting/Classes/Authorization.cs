using System.Linq;

namespace HotelAccounting.Classes
{
    public class Authorization
    {
        public static string CheckLogAndPass(string log, string pass)
        {
            User? authUser = null;
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                    authUser = context.Users.FirstOrDefault(x => x.Login == log.Trim());

                return authUser != null && BCrypt.Net.BCrypt.Verify(pass.Trim(), authUser.Password) ? "true" : "false";
            }
            catch 
            { 
                return "noConnect"; 
            }
        }
    }
}
