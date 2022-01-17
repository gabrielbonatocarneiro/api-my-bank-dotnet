using System.ComponentModel.DataAnnotations;

namespace api_my_bank_dotnet.Dtos
{
  public class CreateUserAddressDto
  {
    [Required]
    [StringLength(255, MinimumLength = 2)]
    public string address_name { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 1)]
    public string number { get; set; }

    [Required]
    [StringLength(255, MinimumLength = 2)]
    public string complement { get; set; }

    [Required]
    [StringLength(255, MinimumLength = 2)]
    public string district { get; set; }

    [Required]
    [StringLength(255, MinimumLength = 2)]
    public string city { get; set; }

    [Required]
    [StringLength(255, MinimumLength = 2)]
    public string state { get; set; }

    [Required]
    [StringLength(255, MinimumLength = 2)]
    public string country { get; set; }
  }
}