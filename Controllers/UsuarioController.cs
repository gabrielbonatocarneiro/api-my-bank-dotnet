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
    // private readonly UsuarioRepositoryInterface repositoryInterface;

    // public UsuarioController(UsuarioRepositoryInterface repositoryInterface)
    // {
    //   this.repositoryInterface = repositoryInterface;
    // }

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
      var transaction = context.Database.BeginTransaction();

      try
      {
        transaction.CreateSavepoint("AntesDeAdicionar");

        await repository.CreateUsuarioAsync(usuarioDto);

        transaction.Commit();

        return NoContent();
      }
      catch (Exception e)
      {
        transaction.RollbackToSavepoint("AntesDeAdicionar");

        return BadRequest($"Erro ao criar o usuário: {e}");
      }
    }
  }
}