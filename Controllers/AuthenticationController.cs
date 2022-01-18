using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using api_my_bank_dotnet.Data;
using api_my_bank_dotnet.Models;
using api_my_bank_dotnet.Repositories;
using api_my_bank_dotnet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace api_my_bank_dotnet.Controllers
{
  [Route("api/auth")]
  public class AuthenticationController : ControllerBase
  {
    private DataContext context;

    private LoginRepository repository;

    public AuthenticationController(DataContext context)
    {
      this.context = context;
      this.repository = new LoginRepository(context);
    }

    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
    public async Task<ActionResult<dynamic>> login([FromBody] User model)
    {
      var user = await repository.AuthenticateUserAsync(model.email, model.password);

      if (user is null)
      {
        return NotFound(new
        {
          message = "Usuário ou senha inválidos"
        });
      }

      var token = TokenService.GenerateToken((dynamic)user);

      return new
      {
        user = user,
        token = token
      };
    }

    [HttpGet]
    [Route("anonymous")]
    [AllowAnonymous]
    public string Anonymous() => "Anônimo";

    [HttpGet]
    [Route("authenticated")]
    [Authorize] // Roles -> [Authorize(Roles = "employee,manager")]
    public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);
  }
}