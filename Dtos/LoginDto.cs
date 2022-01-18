using System.ComponentModel.DataAnnotations;

namespace api_my_bank_dotnet.Dtos
{
  public class LoginDto
  {
    [Required]
    [StringLength(100, MinimumLength = 2)]
    [EmailAddress]
    public string email { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 8)]
    public string password { get; set; }
  }
}