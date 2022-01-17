using System;

namespace api_my_bank_dotnet.Entities
{
  public class BankAccount
  {
    public UInt64 bank_account_id { get; set; }

    public uint branch_number { get; set; }

    public UInt64 account_number { get; set; }

    public DateTime created_at { get; set; }

    public User user { get; set; }
  }
}