using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using api_my_bank_dotnet.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace api_my_bank_dotnet.Services
{
  public static class TokenService
  {
    public static string GenerateToken(dynamic user)
    {
      IEnumerable<Claim> claims = new Claim[]
      {
        // Coloque quantas claims precisar
        new Claim(ClaimTypes.Name, user.login.ToString()),
        new Claim(ClaimTypes.NameIdentifier, user.user_id.ToString()),
        new Claim(ClaimTypes.DateOfBirth, user.birth_date.ToString()),
        new Claim(ClaimTypes.Email, user.email.ToString()),
        new Claim(ClaimTypes.Gender, user.gender.ToString()),
        new Claim(ClaimTypes.Surname, user.surname.ToString())
      };

      return _GenerateToken(claims);
    }

    public static string GenerateToken(IEnumerable<Claim> claims)
    {
      return _GenerateToken(claims);
    }

    private static string _GenerateToken(IEnumerable<Claim> claims)
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(Settings.Secret);


      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.UtcNow.AddHours(2),
        SigningCredentials = new SigningCredentials(
         new SymmetricSecurityKey(key),
         SecurityAlgorithms.HmacSha256Signature
       )
      };

      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }

    public static string GenerateRefreshToken()
    {
      var rng = RandomNumberGenerator.Create();

      var randomNumber = new byte[32];
      rng.GetBytes(randomNumber);

      return Convert.ToBase64String(randomNumber);
    }

    public static ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
      var tokenValidationParameters = new TokenValidationParameters
      {
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.Secret)),
        ValidateLifetime = false
      };

      var tokenHandler = new JwtSecurityTokenHandler();
      var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

      if (securityToken is not JwtSecurityToken jwtSecurityToken ||
          !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
      {
        throw new SecurityTokenException("Invalid token");
      }

      return principal;
    }

    private static List<(string, string)> _refreshTokens = new();

    public static void SaveRefreshToken(string login, string refreshToken)
    {
      var item = _refreshTokens.FirstOrDefault(x => x.Item1 == login);

      if (item.Item1 is not null)
      {
        _refreshTokens.Remove(item);
      }

      _refreshTokens.Add(new(login, refreshToken));
    }

    public static string GetRefreshToken(string login)
    {
      return _refreshTokens.FirstOrDefault(x => x.Item1 == login).Item2;
    }

    public static void DeleteRefreshToken(string login, string refreshToken)
    {
      var item = _refreshTokens.FirstOrDefault(x => x.Item1 == login && x.Item2 == refreshToken);
      _refreshTokens.Remove(item); // Mesmo principio para deslogar um usuário
    }
  }
}
