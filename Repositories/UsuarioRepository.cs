using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using api_my_bank_dotnet.Common;
using api_my_bank_dotnet.Data;
using api_my_bank_dotnet.Dtos;
using api_my_bank_dotnet.Entities;
using api_my_bank_dotnet.RepositoryInterfaces;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

namespace api_my_bank_dotnet.Repositories
{
  public class UsuarioRepository : UsuarioRepositoryInterface
  {
    private DataContext _context;

    public UsuarioRepository(DataContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<UsuarioDto>> GetUsuariosAsync()
    {
      var usuarios = await _context.Usuario
        .Select(usuario => usuario.AsDto())
        .ToListAsync();

      return usuarios;
    }

    public async Task<UsuarioDto> GetUsuarioAsync(ulong usuarioId)
    {
      var usuario = await _context.Usuario
        .Where(u => u.usuario_id == usuarioId)
        .Select(usuario => usuario.AsDto())
        .FirstOrDefaultAsync();

      return usuario;
    }

    public async Task CreateUsuarioAsync(CreateUsuarioDto usuarioDto)
    {
      DateTime date = DateTime.UtcNow;

      Endereco endereco = new()
      {
        uf = usuarioDto.endereco.uf,
        cep = usuarioDto.endereco.cep,
        logradouro = usuarioDto.endereco.logradouro,
        numero = usuarioDto.endereco.numero,
        complemento = usuarioDto.endereco.complemento,
        bairro = usuarioDto.endereco.bairro,
        cidade = usuarioDto.endereco.cidade,
        created_at = date,
        updated_at = date
      };
      await _context.Endereco.AddAsync(endereco);
      await _context.SaveChangesAsync();

      ContaBancaria contaBancaria = new()
      {
        num_agencia = 1,
        num_conta_corrente = await GerarNumContaBancaria(),
        created_at = date
      };
      await _context.ContaBancaria.AddAsync(contaBancaria);
      await _context.SaveChangesAsync();

      Usuario usuario = new()
      {
        endereco_id = endereco.endereco_id,
        conta_bancaria_id = contaBancaria.conta_bancaria_id,
        nome_completo = usuarioDto.nome_completo,
        apelido = usuarioDto.apelido,
        login = usuarioDto.login,
        email = usuarioDto.email,
        senha = CommonMethods.ConvertToEncrypt(usuarioDto.senha),
        rg = usuarioDto.rg,
        cpf = usuarioDto.cpf,
        idade = usuarioDto.idade,
        sexo = usuarioDto.sexo,
        estado_civil = usuarioDto.estado_civil,
        renda_mensal = usuarioDto.renda_mensal,
        data_nascimento = usuarioDto.data_nascimento,
        created_at = date,
        updated_at = date
      };
      await _context.Usuario.AddAsync(usuario);
      await _context.SaveChangesAsync();
    }

    private async Task<ulong> GerarNumContaBancaria()
    {
      var ultimaContaBancaria = await _context.ContaBancaria
        .AsNoTracking()
        .OrderBy(c => c.num_conta_corrente)
        .LastOrDefaultAsync();

      ulong numeroUltimaContaBancaria = 1000;

      if (ultimaContaBancaria is not null)
      {
        numeroUltimaContaBancaria = ultimaContaBancaria.num_conta_corrente + 1;
      }

      return numeroUltimaContaBancaria;
    }

    public async Task UpdateUsuarioAsync(ulong usuarioId, UpdateUsuarioDto usuarioDto)
    {
      var usuarios = await _context.Usuario.Where(u =>
        u.login.Contains(usuarioDto.login) ||
        u.email.Contains(usuarioDto.email) ||
        u.rg.Contains(usuarioDto.rg) ||
        u.cpf.Contains(usuarioDto.cpf)
      )
      .ToListAsync();

      if (usuarios.Count > 1 || usuarios.Any(u => u.usuario_id != usuarioId))
      {
        throw new Exception("login, email, rg ou cpf inválidos");
      }

      DateTime date = DateTime.UtcNow;

      Endereco endereco = new()
      {
        endereco_id = usuarioDto.endereco.endereco_id,
        uf = usuarioDto.endereco.uf,
        cep = usuarioDto.endereco.cep,
        logradouro = usuarioDto.endereco.logradouro,
        numero = usuarioDto.endereco.numero,
        complemento = usuarioDto.endereco.complemento,
        bairro = usuarioDto.endereco.bairro,
        cidade = usuarioDto.endereco.cidade,
        updated_at = date
      };
      _context.Endereco.Update(endereco);
      await _context.SaveChangesAsync();

      var usuario = await _context.Usuario.Where(u => u.usuario_id == usuarioId).FirstOrDefaultAsync();

      usuario.nome_completo = usuarioDto.nome_completo;
      usuario.apelido = usuarioDto.apelido;
      usuario.login = usuarioDto.login;
      usuario.email = usuarioDto.email;
      usuario.senha = CommonMethods.ConvertToEncrypt(usuarioDto.senha);
      usuario.rg = usuarioDto.rg;
      usuario.cpf = usuarioDto.cpf;
      usuario.idade = usuarioDto.idade;
      usuario.sexo = usuarioDto.sexo;
      usuario.estado_civil = usuarioDto.estado_civil;
      usuario.renda_mensal = usuarioDto.renda_mensal;
      usuario.data_nascimento = usuarioDto.data_nascimento;
      usuario.updated_at = date;

      _context.Usuario.Update(usuario);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteUsuarioAsync(ulong usuarioId)
    {
      var usuario = await _context.Usuario.Where(u => u.usuario_id == usuarioId).FirstOrDefaultAsync();
      _context.Usuario.Remove(usuario);
      await _context.SaveChangesAsync();

      var contaBancaria = await _context.ContaBancaria.Where(c => c.conta_bancaria_id == usuario.conta_bancaria_id).FirstOrDefaultAsync();
      _context.ContaBancaria.Remove(contaBancaria);
      await _context.SaveChangesAsync();

      var endereco = await _context.Endereco.Where(e => e.endereco_id == usuario.endereco_id).FirstOrDefaultAsync();
      _context.Endereco.Remove(endereco);
      await _context.SaveChangesAsync();
    }
  }
}