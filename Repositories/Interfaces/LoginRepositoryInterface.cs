using System.Threading.Tasks;
using api_my_bank_dotnet.Models;

namespace api_my_bank_dotnet.Repositories.Interfaces
{
  public interface LoginRepositoryInterface
  {
    Task<User> AuthenticateUserAsync(string email, string password);
  }
}