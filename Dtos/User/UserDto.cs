using System;
using api_my_bank_dotnet.Entities;

namespace api_my_bank_dotnet.Dtos.User
{
  public class UserDto
  {
    public ulong user_id { get; set; }

    public ulong address_id { get; set; }

    public ulong bank_account_id { get; set; }

    public string full_name { get; set; }

    public string surname { get; set; }

    public string login { get; set; }

    public string email { get; set; }

    public string passport_number { get; set; }

    public int age { get; set; }

    public string gender { get; set; }

    public string civil_status { get; set; }

    public ulong monthly_income { get; set; }

    public DateTime birth_date { get; set; }

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public Address address { get; set; }

    public BankAccount bankAccount { get; set; }
  }
}