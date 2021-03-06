using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api_my_bank_dotnet.Dtos.User
{
  public class CreateUserDto
  {
    [Required]
    [StringLength(255, MinimumLength = 2)]
    public string full_name { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 2)]
    public string surname { get; set; }

    [Required]
    [StringLength(15, MinimumLength = 2)]
    public string login { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    [EmailAddress]
    public string email { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 8)]
    public string password { get; set; }

    [Required]
    [StringLength(9, MinimumLength = 9)]
    public string passport_number { get; set; }

    [Required]
    [Range(18, 150)]
    public int age { get; set; }

    [Required]
    [RegularExpression("MALE|FEMALE", ErrorMessage = "The gender must be MALE or FEMALE")]
    [StringLength(6, MinimumLength = 4)]
    public string gender { get; set; }

    [Required]
    [RegularExpression("SINGLE|MARRIED|WIDOWER", ErrorMessage = "The civil status must be SINGLE, MARRIED or WIDOWER")]
    [StringLength(7, MinimumLength = 6)]
    public string civil_status { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime birth_date { get; set; }

    [Required]
    public InfoCurrencyDto infoCurrency { get; set; }

    [Required]
    public ICollection<CreateUserAddressDto> addresses { get; set; }
  }
}