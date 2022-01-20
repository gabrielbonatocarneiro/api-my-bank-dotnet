using System.Threading.Tasks;

namespace api_my_bank_dotnet.Repositories.Interfaces
{
  public interface RedisRepositoryInterface
  {
    Task<string> GetAsync(string key);

    Task<string> CreateAsync(string key, dynamic value);

    Task DeleteAsync(string key);
  }
}
