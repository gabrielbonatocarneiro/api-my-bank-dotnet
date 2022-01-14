using System;
using api_my_bank_dotnet.Entities;

namespace api_my_bank_dotnet.Dtos
{
  public class UsuarioDto
  {
    public UInt64 usuario_id { get; set; }

    public UInt64 endereco_id { get; set; }

    public UInt64 conta_bancaria_id { get; set; }

    public string nome_completo { get; set; }

    public string apelido { get; set; }

    public string login { get; set; }

    public string email { get; set; }

    public string rg { get; set; }

    public string cpf { get; set; }

    public int idade { get; set; }

    public string sexo { get; set; }

    public string estado_civil { get; set; }

    public UInt64 renda_mensal { get; set; }

    public DateTime data_nascimento { get; set; }

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }
  }
}