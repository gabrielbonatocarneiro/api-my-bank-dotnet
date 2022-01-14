using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_my_bank_dotnet.Data;
using api_my_bank_dotnet.Dtos;
using api_my_bank_dotnet.Entities;
using api_my_bank_dotnet.RepositoryInterfaces;
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
      var ultimoEndereco = await _context.Endereco.Select(e => new { e.endereco_id }).OrderBy(e => e.endereco_id).LastOrDefaultAsync();
      ulong ultimoEnderecoId = ultimoEndereco is not null ? ultimoEndereco.endereco_id + 1 : 1;

      DateTime date = DateTime.UtcNow;

      Endereco endereco = new()
      {
        endereco_id = ultimoEnderecoId,
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

      var ultimoContaBancaria = await _context.ContaBancaria.Select(c => new { c.conta_bancaria_id }).OrderBy(c => c.conta_bancaria_id).LastOrDefaultAsync();
      ulong ultimoContaBancariaId = ultimoContaBancaria is not null ? ultimoContaBancaria.conta_bancaria_id + 1 : 1;

      ContaBancaria contaBancaria = new()
      {
        conta_bancaria_id = ultimoContaBancariaId,
        num_agencia = 1,
        num_conta_corrente = await GerarNumContaBancaria(),
        created_at = date
      };
      await _context.ContaBancaria.AddAsync(contaBancaria);
      await _context.SaveChangesAsync();

      var ultimoUsuario = await _context.Usuario.Select(u => new { u.usuario_id }).OrderBy(u => u.usuario_id).LastOrDefaultAsync();
      ulong ultimoUsuarioId = ultimoUsuario is not null ? ultimoUsuario.usuario_id + 1 : 1;

      Usuario usuario = new()
      {
        usuario_id = ultimoUsuarioId,
        endereco_id = ultimoEnderecoId,
        conta_bancaria_id = ultimoContaBancariaId,
        nome_completo = usuarioDto.nome_completo,
        apelido = usuarioDto.apelido,
        login = usuarioDto.login,
        email = usuarioDto.email,
        senha = EncriptarSenha(usuarioDto.senha),
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

    public Task UpdateUsuarioAsync(Usuario usuario)
    {
      throw new System.NotImplementedException();
    }

    public Task<Usuario> DeleteUsuarioAsync(ulong usuarioId)
    {
      throw new System.NotImplementedException();
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

    public string EncriptarSenha(string senha)
    {
      byte[] encData_byte = new byte[senha.Length];

      encData_byte = System.Text.Encoding.UTF8.GetBytes(senha);

      return Convert.ToBase64String(encData_byte);
    }

    public string DecriptarSenha(string senha)
    {
      System.Text.Decoder utf8Decode = new System.Text.UTF8Encoding().GetDecoder();

      byte[] todecode_byte = Convert.FromBase64String(senha);
      int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);

      char[] decoded_char = new char[charCount];

      utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);

      return new String(decoded_char);
    }
  }
}