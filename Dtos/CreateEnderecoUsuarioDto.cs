using System.ComponentModel.DataAnnotations;

namespace api_my_bank_dotnet.Dtos
{
  public class CreateEnderecoUsuarioDto
  {
    [Required]
    [StringLength(2, MinimumLength = 2)]
    public string uf { get; set; }

    [Required]
    [StringLength(8, MinimumLength = 8)]
    public string cep { get; set; }

    [Required]
    [StringLength(255, MinimumLength = 5)]
    public string logradouro { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 1)]
    public string numero { get; set; }

    [Required]
    [StringLength(255, MinimumLength = 2)]
    public string complemento { get; set; }

    [Required]
    [StringLength(255, MinimumLength = 2)]
    public string bairro { get; set; }

    [Required]
    [StringLength(255, MinimumLength = 2)]
    public string cidade { get; set; }
  }
}