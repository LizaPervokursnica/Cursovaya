using HotelAccounting.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HotelAccounting.Classes;

public class Authorization
{
    public static async Task<bool> CheckLogAndPass(string login, string pass, HotelDbContext context)
    {
        var authUser = await context.Users.FirstOrDefaultAsync(x => x.Login == login);
        return authUser != null && BCrypt.Net.BCrypt.Verify(pass, authUser.Password);
    }
}

