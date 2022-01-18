using System.Linq;
using System.Threading.Tasks;
using api_my_bank_dotnet.Common;
using api_my_bank_dotnet.Data;
using api_my_bank_dotnet.Models;
using api_my_bank_dotnet.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api_my_bank_dotnet.Repositories
{
  public class LoginRepository : LoginRepositoryInterface
  {
    private DataContext _context;

    public LoginRepository(DataContext context)
    {
      _context = context;
    }

    public async Task<User> AuthenticateUserAsync(string email, string password)
    {
      var encryptedPassword = CommonMethods.ConvertToEncrypt(password);

      var user = await _context.User
       .Where(u => u.email == email && u.password == encryptedPassword)
       .AsNoTracking()
       .FirstOrDefaultAsync();

      return user;
    }
  }
}