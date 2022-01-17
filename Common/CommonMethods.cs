using System;
using System.Text;

namespace api_my_bank_dotnet.Common
{
  public static class CommonMethods
  {
    public static string ConvertToEncrypt(string senha)
    {
      if (string.IsNullOrEmpty(senha))
      {
        throw new Exception("Senha inválida");
      }

      var bytesSenha = Encoding.UTF8.GetBytes(senha);

      return Convert.ToBase64String(bytesSenha);
    }

    public static string ConvertToDecrypt(string base64EncodeData)
    {
      if (string.IsNullOrEmpty(base64EncodeData))
      {
        throw new Exception("Hash da seenha inválido");
      }

      var base64EncodeBytes = Convert.FromBase64String(base64EncodeData);
      var result = Encoding.UTF8.GetString(base64EncodeBytes);

      return result.Substring(0, result.Length);
    }
  }
}