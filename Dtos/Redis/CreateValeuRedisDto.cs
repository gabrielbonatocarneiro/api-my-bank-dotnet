using System.ComponentModel.DataAnnotations;

namespace api_my_bank_dotnet.Dtos
{
  public class CreateValeuRedisDto
  {
    [Required]
    public string key { get; set; }

    [Required]
    public dynamic value { get; set; }
  }
}
