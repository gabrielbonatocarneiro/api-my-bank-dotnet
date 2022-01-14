using System;

namespace api_my_bank_dotnet.Entities
{
  public class Endereco
  {
    public UInt64 endereco_id { get; set; }

    public string uf { get; set; }

    public string cep { get; set; }

    public string logradouro { get; set; }

    public string numero { get; set; }

    public string complemento { get; set; }

    public string bairro { get; set; }

    public string cidade { get; set; }

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public Usuario usuario { get; set; }
  }
}