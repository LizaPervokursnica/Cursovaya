using HotelAccounting.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HotelAccounting.Classes;

public class Authorization
{
    public static async Task<string> CheckLogAndPass(string log, string pass, HotelDbContext context)
    {

        User authUser = null;
        try
        {
            authUser = await context.Users.FirstOrDefaultAsync(x => x.Login == log.Trim());
            return authUser != null && BCrypt.Net.BCrypt.Verify(pass.Trim(), authUser.Password) ? "true" : "false";
        }
        catch
        {
            return "noConnect";
        }

    }
}

