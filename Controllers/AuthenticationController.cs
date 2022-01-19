using System;
using System.Threading.Tasks;
using api_my_bank_dotnet.Data;
using api_my_bank_dotnet.Models;
using api_my_bank_dotnet.Repositories;
using api_my_bank_dotnet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace api_my_bank_dotnet.Controllers
{
  [Route("api/auth")]
  public class AuthenticationController : ControllerBase
  {
    private DataContext context;

    private AuthenticationRepository repository;

    public AuthenticationController(DataContext context)
    {
      this.context = context;
      this.repository = new AuthenticationRepository(context);
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
      var refreshToken = TokenService.GenerateRefreshToken();
      TokenService.SaveRefreshToken(user.login, refreshToken);

      return new
      {
        user = user,
        token = token,
        refreshToken = refreshToken
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

    [HttpPost]
    [Route("refresh")]
    public IActionResult Refresh(string token, string refreshToken)
    {
      var principal = TokenService.GetPrincipalFromExpiredToken(token);
      var login = principal.Identity.Name;

      var savedRefreshToken = TokenService.GetRefreshToken(login);
      if (savedRefreshToken != refreshToken)
      {
        throw new SecurityTokenException("Invalid refresh token");
      }

      var newJwtToken = TokenService.GenerateToken(principal.Claims);
      var newRefreshToken = TokenService.GenerateRefreshToken();

      TokenService.DeleteRefreshToken(login, refreshToken);
      TokenService.SaveRefreshToken(login, newRefreshToken);

      return new ObjectResult(new
      {
        token = newJwtToken,
        refreshToken = newRefreshToken
      });
    }
  }
}
