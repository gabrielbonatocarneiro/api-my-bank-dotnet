using System;

namespace api_my_bank_dotnet.Entities
{
  public class ContaBancaria
  {
    public UInt64 conta_bancaria_id { get; set; }

    public uint num_agencia { get; set; }

    public UInt64 num_conta_corrente { get; set; }

    public DateTime created_at { get; set; }

    public Usuario usuario { get; set; }
  }
}