using System;

namespace api_my_bank_dotnet.Entities
{
  public class User
  {
    public UInt64 user_id { get; set; }

    public UInt64 address_id { get; set; }

    public UInt64 bank_account_id { get; set; }

    public string full_name { get; set; }

    public string surname { get; set; }

    public string login { get; set; }

    public string email { get; set; }

    public string password { get; set; }

    public string passport_number { get; set; }

    public int age { get; set; }

    public string gender { get; set; }

    public string civil_status { get; set; }

    public UInt64 monthly_income { get; set; }

    public DateTime birth_date { get; set; }

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public Address address { get; set; }

    public BankAccount bankAccount { get; set; }
  }
}