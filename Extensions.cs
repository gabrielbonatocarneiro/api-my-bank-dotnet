using System;
using System.Text.Json;
using api_my_bank_dotnet.Dtos;
using api_my_bank_dotnet.Entities;
using Newtonsoft.Json;

namespace api_my_bank_dotnet
{
  public static class Extensions
  {
    public static UsuarioDto AsDto(this Usuario usuario)
    {
      return new UsuarioDto
      {
        usuario_id = usuario.usuario_id,
        endereco_id = usuario.endereco_id,
        conta_bancaria_id = usuario.conta_bancaria_id,
        nome_completo = usuario.nome_completo,
        apelido = usuario.apelido,
        login = usuario.login,
        email = usuario.email,
        rg = usuario.rg,
        cpf = usuario.cpf,
        idade = usuario.idade,
        sexo = usuario.sexo,
        estado_civil = usuario.estado_civil,
        renda_mensal = usuario.renda_mensal,
        data_nascimento = usuario.data_nascimento,
        created_at = usuario.created_at,
        updated_at = usuario.updated_at
      };
    }
  }
}