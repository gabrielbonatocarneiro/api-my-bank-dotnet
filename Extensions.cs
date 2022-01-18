using System.Collections.Generic;
using api_my_bank_dotnet.Dtos.User;
using api_my_bank_dotnet.Entities;

namespace api_my_bank_dotnet
{
  public static class Extensions
  {
    public static UserDto AsDto(this User user)
    {
      List<Address> addresses = new();

      foreach (Address address in user.addresses)
      {
        addresses.Add(new Address
        {
          address_id = address.address_id,
          user_id = address.user_id,
          address_name = address.address_name,
          number = address.number,
          complement = address.complement,
          district = address.district,
          city = address.city,
          state = address.state,
          country = address.country,
          created_at = address.created_at,
          updated_at = address.updated_at
        });
      }

      return new UserDto
      {
        user_id = user.user_id,
        bank_account_id = user.bank_account_id,
        full_name = user.full_name,
        surname = user.surname,
        login = user.login,
        email = user.email,
        passport_number = user.passport_number,
        age = user.age,
        gender = user.gender,
        civil_status = user.civil_status,
        birth_date = user.birth_date,
        created_at = user.created_at,
        updated_at = user.updated_at,
        addresses = addresses,
        bankAccount = new()
        {
          bank_account_id = user.bankAccount.bank_account_id,
          branch_number = user.bankAccount.branch_number,
          account_number = user.bankAccount.account_number,
          currency = user.bankAccount.currency,
          monthly_income = user.bankAccount.monthly_income,
          created_at = user.bankAccount.created_at
        }
      };
    }
  }
}