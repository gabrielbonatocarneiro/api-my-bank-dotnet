using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_my_bank_dotnet.Data;
using api_my_bank_dotnet.Dtos;
using api_my_bank_dotnet.Entities;
using api_my_bank_dotnet.Repositories;
using api_my_bank_dotnet.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_my_bank_dotnet.Controllers
{
  [ApiController]
  [Route("api/usuario")]
  public class UsuarioController : ControllerBase
  {
    private DataContext context;

    private UsuarioRepository repository;

    public UsuarioController(DataContext context)
    {
      this.context = context;
      this.repository = new UsuarioRepository(context);
    }

    [HttpGet]
    public async Task<IEnumerable<UsuarioDto>> GetUsuariosAsync()
    {
      var usuarios = await repository.GetUsuariosAsync();

      return usuarios;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UsuarioDto>> GetUsuarioAsync(ulong id)
    {
      var usuario = await repository.GetUsuarioAsync(id);

      if (usuario is null)
      {
        return NotFound();
      }

      return usuario;
    }

    [HttpPost]
    public async Task<ActionResult> CreateUsuarioAsync(CreateUsuarioDto usuarioDto)
    {
      var hashCodeTimeNow = DateTime.Now.GetHashCode();

      var transaction = context.Database.BeginTransaction();

      try
      {
        transaction.CreateSavepoint($"AntesDeAdicionar{hashCodeTimeNow}");

        await repository.CreateUsuarioAsync(usuarioDto);

        transaction.Commit();

        return NoContent();
      }
      catch (Exception e)
      {
        transaction.RollbackToSavepoint($"AntesDeAdicionar{hashCodeTimeNow}");

        return BadRequest($"Erro ao criar o usuário: {e}");
      }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateUsuarioAsync(ulong id, UpdateUsuarioDto usuarioDto)
    {
      var existingUsuario = await repository.GetUsuarioAsync(id);

      if (existingUsuario is null)
      {
        return NotFound();
      }

      var hashCodeTimeNow = DateTime.Now.GetHashCode();

      var transaction = context.Database.BeginTransaction();

      try
      {
        transaction.CreateSavepoint($"AntesDeAtualizar{hashCodeTimeNow}");

        await repository.UpdateUsuarioAsync(id, usuarioDto);

        transaction.Commit();

        return NoContent();
      }
      catch (Exception e)
      {
        transaction.RollbackToSavepoint($"AntesDeAtualizar{hashCodeTimeNow}");

        return BadRequest($"Erro ao atualizar o usuário: {e}");
      }
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUsuarioAsync(ulong id)
    {
      var existingUsuario = await repository.GetUsuarioAsync(id);

      if (existingUsuario is null)
      {
        return NotFound();
      }

      await repository.DeleteUsuarioAsync(id);

      return NoContent();
    }
  }
}