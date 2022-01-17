using System;

namespace api_my_bank_dotnet.Entities
{
  public class BankAccount
  {
    public ulong bank_account_id { get; set; }

    public uint branch_number { get; set; }

    public ulong account_number { get; set; }

    public string currency { get; set; }

    public ulong monthly_income { get; set; }

    public DateTime created_at { get; set; }

    public User user { get; set; }
  }
}