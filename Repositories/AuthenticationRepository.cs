using System.Linq;
using System.Threading.Tasks;
using api_my_bank_dotnet.Common;
using api_my_bank_dotnet.Data;
using api_my_bank_dotnet.Dtos.User;
using api_my_bank_dotnet.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api_my_bank_dotnet.Repositories
{
  public class AuthenticationRepository : AuthenticationRepositoryInterface
  {
    private DataContext _context;

    public AuthenticationRepository(DataContext context)
    {
      _context = context;
    }

    public async Task<UserDto> AuthenticateUserAsync(string email, string password)
    {
      var encryptedPassword = CommonMethods.ConvertToEncrypt(password);

      var user = await _context.User
       .Where(u => u.email == email && u.password == encryptedPassword)
       .Include(u => u.addresses)
       .Include(u => u.bankAccount)
       .Select(user => user.AsDto())
       .AsNoTracking()
       .FirstOrDefaultAsync();

      return user;
    }
  }
}
