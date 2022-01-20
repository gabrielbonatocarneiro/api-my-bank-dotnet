using System.ComponentModel.DataAnnotations;

namespace api_my_bank_dotnet.Dtos
{
  public class UpdatedValeuRedisDto
  {
    [Required]
    public dynamic value { get; set; }
  }
}
