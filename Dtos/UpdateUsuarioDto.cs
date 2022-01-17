using System;
using System.ComponentModel.DataAnnotations;

namespace api_my_bank_dotnet.Dtos
{
  public class UpdateUsuarioDto
  {
    [Required]
    [StringLength(255, MinimumLength = 2)]
    public string nome_completo { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 2)]
    public string apelido { get; set; }

    [Required]
    [StringLength(15, MinimumLength = 2)]
    public string login { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    [EmailAddress]
    public string email { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 8)]
    public string senha { get; set; }

    [Required]
    [StringLength(9, MinimumLength = 9)]
    public string rg { get; set; }

    [Required]
    [StringLength(11, MinimumLength = 11)]
    public string cpf { get; set; }

    [Required]
    [Range(18, 150)]
    public int idade { get; set; }

    [Required]
    [RegularExpression("MASCULINO|FEMININO", ErrorMessage = "O sexo deve ser MASCULINO ou FEMININO")]
    [StringLength(9, MinimumLength = 8)]
    public string sexo { get; set; }

    [Required]
    [RegularExpression("SOLTEIRO|CASADO|VIUVO", ErrorMessage = "O sexo deve ser MASCULINO ou FEMININO")]
    [StringLength(8, MinimumLength = 5)]
    public string estado_civil { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public UInt64 renda_mensal { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime data_nascimento { get; set; }

    [Required]
    public UpdateEnderecoUsuarioDto endereco { get; set; }
  }
}