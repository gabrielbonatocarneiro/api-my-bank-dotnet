using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_my_bank_dotnet.Common;
using api_my_bank_dotnet.Data;
using api_my_bank_dotnet.Dtos.User;
using api_my_bank_dotnet.Entities;
using api_my_bank_dotnet.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api_my_bank_dotnet.Repositories
{
  public class UserRepository : UserRepositoryInterface
  {
    private DataContext _context;

    public UserRepository(DataContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<UserDto>> GetUsersAsync()
    {
      var users = await _context.User
        .Include(u => u.addresses)
        .Include(u => u.bankAccount)
        .Select(user => user.AsDto())
        .AsNoTracking()
        .ToListAsync();

      return users;
    }

    public async Task<User> GetUserAsync(ulong userId)
    {
      var user = await _context.User
        .Where(u => u.user_id == userId)
        .Include(u => u.addresses)
        .Include(u => u.bankAccount)
        .AsNoTracking()
        .FirstOrDefaultAsync();

      return user;
    }

    public async Task CreateUserAsync(CreateUserDto userDto)
    {
      DateTime date = DateTime.UtcNow;

      BankAccount bankAccount = new()
      {
        branch_number = 1,
        account_number = await GenerateBankAccountNumber(),
        currency = userDto.infoCurrency.currency,
        monthly_income = userDto.infoCurrency.monthly_income,
        created_at = date
      };
      await _context.BankAccount.AddAsync(bankAccount);
      await _context.SaveChangesAsync();

      User user = new()
      {
        bank_account_id = bankAccount.bank_account_id,
        full_name = userDto.full_name,
        surname = userDto.surname,
        login = userDto.login,
        email = userDto.email,
        password = CommonMethods.ConvertToEncrypt(userDto.password),
        passport_number = userDto.passport_number,
        age = userDto.age,
        gender = userDto.gender,
        civil_status = userDto.civil_status,
        birth_date = userDto.birth_date,
        created_at = date,
        updated_at = date
      };
      await _context.User.AddAsync(user);
      await _context.SaveChangesAsync();

      foreach (CreateUserAddressDto addressDto in userDto.addresses)
      {
        Address address = new()
        {
          user_id = user.user_id,
          address_name = addressDto.address_name,
          number = addressDto.number,
          complement = addressDto.complement,
          district = addressDto.district,
          city = addressDto.city,
          state = addressDto.state,
          country = addressDto.country,
          created_at = date,
          updated_at = date
        };
        await _context.Address.AddAsync(address);
        await _context.SaveChangesAsync();
      }
    }

    private async Task<ulong> GenerateBankAccountNumber()
    {
      var lastBankAccount = await _context.BankAccount
        .AsNoTracking()
        .OrderBy(c => c.account_number)
        .LastOrDefaultAsync();

      ulong lastNumberBankAccount = 1000;

      if (lastBankAccount is not null)
      {
        lastNumberBankAccount = lastBankAccount.account_number + 1;
      }

      return lastNumberBankAccount;
    }

    public async Task UpdateUserAsync(ulong userId, UpdateUserDto userDto)
    {
      var users = await _context.User.Where(u =>
        u.login.Contains(userDto.login) ||
        u.email.Contains(userDto.email) ||
        u.passport_number.Contains(userDto.passport_number)
      )
      .ToListAsync();

      if (users.Count > 1 || users.Any(u => u.user_id != userId))
      {
        throw new Exception("invalid login, email, rg or passport number");
      }

      DateTime date = DateTime.UtcNow;

      // User
      var user = await _context.User.Where(u => u.user_id == userId).FirstOrDefaultAsync();

      user.full_name = userDto.full_name;
      user.surname = userDto.surname;
      user.login = userDto.login;
      user.email = userDto.email;
      user.password = CommonMethods.ConvertToEncrypt(userDto.password);
      user.passport_number = userDto.passport_number;
      user.age = userDto.age;
      user.gender = userDto.gender;
      user.civil_status = userDto.civil_status;
      user.birth_date = userDto.birth_date;
      user.updated_at = date;

      _context.User.Update(user);
      await _context.SaveChangesAsync();

      // Bank Account
      var bankAccount = await _context.BankAccount.Where(ba => ba.bank_account_id == user.bank_account_id).FirstOrDefaultAsync();

      bankAccount.currency = userDto.infoCurrency.currency;
      bankAccount.monthly_income = userDto.infoCurrency.monthly_income;

      _context.BankAccount.Update(bankAccount);
      await _context.SaveChangesAsync();

      // Address
      foreach (UpdateUserAddressDto addressDto in userDto.addresses)
      {
        Address address = new()
        {
          user_id = userId,
          address_name = addressDto.address_name,
          number = addressDto.number,
          complement = addressDto.complement,
          district = addressDto.district,
          city = addressDto.city,
          state = addressDto.state,
          country = addressDto.country,
          created_at = addressDto.created_at ?? date,
          updated_at = date
        };

        if (Convert.ToUInt64(addressDto.address_id).Equals(null))
        {
          await _context.Address.AddAsync(address);
        }
        else
        {
          address.address_id = Convert.ToUInt64(addressDto.address_id);

          _context.Address.Update(address);
        }

        await _context.SaveChangesAsync();
      }
    }

    public async Task DeleteUserAsync(ulong userId)
    {
      var user = await _context.User.Where(u => u.user_id == userId).FirstOrDefaultAsync();
      _context.User.Remove(user);
      await _context.SaveChangesAsync();

      var bankAccount = await _context.BankAccount.Where(c => c.bank_account_id == user.bank_account_id).FirstOrDefaultAsync();
      _context.BankAccount.Remove(bankAccount);
      await _context.SaveChangesAsync();
    }
  }
}