using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api_my_bank_dotnet.Dtos.User;
using api_my_bank_dotnet.Models;

namespace api_my_bank_dotnet.Repositories.Interfaces
{
  public interface UserRepositoryInterface
  {
    Task<IEnumerable<UserDto>> GetUsersAsync();

    Task<User> GetUserAsync(ulong userId);

    Task<User> CreateUserAsync(CreateUserDto userDto);

    Task UpdateUserAsync(ulong userId, UpdateUserDto userDto);

    Task DeleteUserAsync(ulong userId);
  }
}
