using api_my_bank_dotnet.Dtos;
using api_my_bank_dotnet.Entities;

namespace api_my_bank_dotnet
{
  public static class Extensions
  {
    public static UserDto AsDto(this User user)
    {
      return new UserDto
      {
        user_id = user.user_id,
        address_id = user.address_id,
        bank_account_id = user.bank_account_id,
        full_name = user.full_name,
        surname = user.surname,
        login = user.login,
        email = user.email,
        passport_number = user.passport_number,
        age = user.age,
        gender = user.gender,
        civil_status = user.civil_status,
        monthly_income = user.monthly_income,
        birth_date = user.birth_date,
        created_at = user.created_at,
        updated_at = user.updated_at,
        address = new()
        {
          address_id = user.address.address_id,
          address_name = user.address.address_name,
          number = user.address.number,
          complement = user.address.complement,
          district = user.address.district,
          city = user.address.city,
          state = user.address.state,
          country = user.address.country,
          created_at = user.address.created_at,
          updated_at = user.address.updated_at
        },
        bankAccount = new()
        {
          bank_account_id = user.bankAccount.bank_account_id,
          branch_number = user.bankAccount.branch_number,
          account_number = user.bankAccount.account_number,
          created_at = user.bankAccount.created_at
        }
      };
    }
  }
}