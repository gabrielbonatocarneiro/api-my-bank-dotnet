using System.ComponentModel.DataAnnotations;

namespace api_my_bank_dotnet.Dtos.User
{
  public class InfoCurrencyDto
  {
    [Required]
    [RegularExpression("BRL", ErrorMessage = "The currency must be BRL")]
    [StringLength(20, MinimumLength = 2)]
    public string currency { get; set; }

    [Required]
    [Range(1, ulong.MaxValue)]
    public ulong monthly_income { get; set; }
  }
}