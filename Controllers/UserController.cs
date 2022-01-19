using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api_my_bank_dotnet.Data;
using api_my_bank_dotnet.Dtos.User;
using api_my_bank_dotnet.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api_my_bank_dotnet.Controllers
{
  [ApiController]
  [Route("api/user")]
  [Produces("application/json")]
  public class UserController : ControllerBase
  {
    private DataContext context;

    private UserRepository repository;

    public UserController(DataContext context)
    {
      this.context = context;
      this.repository = new UserRepository(context);
    }

    [HttpGet]
    [Authorize]
    public async Task<IEnumerable<UserDto>> GetUsersAsync()
    {
      var usuarios = await repository.GetUsersAsync();

      return usuarios;
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<UserDto>> GetUserAsync(ulong id)
    {
      var usuario = await repository.GetUserAsync(id);

      if (usuario is null)
      {
        return NotFound();
      }

      return usuario.AsDto();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<UserDto>> CreateUserAsync(CreateUserDto userDto)
    {
      var hashCodeTimeNow = DateTime.Now.GetHashCode();

      var transaction = context.Database.BeginTransaction();

      try
      {
        transaction.CreateSavepoint($"addUser{hashCodeTimeNow}");

        var user = await repository.CreateUserAsync(userDto);

        transaction.Commit();

        return user.AsDto();
      }
      catch (Exception e)
      {
        transaction.RollbackToSavepoint($"addUser{hashCodeTimeNow}");

        return BadRequest($"Error create user: {e}");
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult> UpdateUserAsync(ulong id, UpdateUserDto userDto)
    {
      var existingUser = await repository.GetUserAsync(id);

      if (existingUser is null)
      {
        return NotFound();
      }

      var hashCodeTimeNow = DateTime.Now.GetHashCode();

      var transaction = context.Database.BeginTransaction();

      try
      {
        transaction.CreateSavepoint($"updateUser{hashCodeTimeNow}");

        await repository.UpdateUserAsync(id, userDto);

        transaction.Commit();

        return NoContent();
      }
      catch (Exception e)
      {
        transaction.RollbackToSavepoint($"updateUser{hashCodeTimeNow}");

        return BadRequest($"Error update user: {e}");
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult> DeleteUserAsync(ulong id)
    {
      var existingUser = await repository.GetUserAsync(id);

      if (existingUser is null)
      {
        return NotFound();
      }

      await repository.DeleteUserAsync(id);

      return NoContent();
    }
  }
}
