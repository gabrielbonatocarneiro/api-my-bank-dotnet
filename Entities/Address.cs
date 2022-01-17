using System;

namespace api_my_bank_dotnet.Entities
{
  public class Address
  {
    public UInt64 address_id { get; set; }

    public string address_name { get; set; }

    public string number { get; set; }

    public string complement { get; set; }

    public string district { get; set; }

    public string city { get; set; }

    public string state { get; set; }

    public string country { get; set; }

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public User user { get; set; }
  }
}