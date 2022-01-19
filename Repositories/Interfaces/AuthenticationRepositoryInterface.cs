using System.Threading.Tasks;
using api_my_bank_dotnet.Dtos.User;

namespace api_my_bank_dotnet.Repositories.Interfaces
{
  public interface AuthenticationRepositoryInterface
  {
    Task<UserDto> AuthenticateUserAsync(string email, string password);
  }
}
