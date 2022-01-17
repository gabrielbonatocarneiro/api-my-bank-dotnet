using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api_my_bank_dotnet.Dtos;
using api_my_bank_dotnet.Entities;

namespace api_my_bank_dotnet.RepositoryInterfaces
{
  public interface UsuarioRepositoryInterface
  {
    Task<IEnumerable<UsuarioDto>> GetUsuariosAsync();

    Task<UsuarioDto> GetUsuarioAsync(ulong usuarioId);

    Task CreateUsuarioAsync(CreateUsuarioDto usuarioDto);

    Task UpdateUsuarioAsync(ulong usuarioId, UpdateUsuarioDto usuarioDto);

    Task DeleteUsuarioAsync(ulong usuarioId);
  }
}