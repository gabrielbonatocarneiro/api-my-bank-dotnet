using System;
using System.Collections.Generic;

namespace api_my_bank_dotnet.Models
{
  public class User
  {
    public ulong user_id { get; set; }

    public ulong bank_account_id { get; set; }

    public string full_name { get; set; }

    public string surname { get; set; }

    public string login { get; set; }

    public string email { get; set; }

    public string password { get; set; }

    public string passport_number { get; set; }

    public int age { get; set; }

    public string gender { get; set; }

    public string civil_status { get; set; }

    public DateTime birth_date { get; set; }

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public ICollection<Address> addresses { get; set; }

    public BankAccount bankAccount { get; set; }
  }
}