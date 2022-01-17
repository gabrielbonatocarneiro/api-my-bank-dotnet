using System;
using System.Text;

namespace api_my_bank_dotnet.Common
{
  public static class CommonMethods
  {
    public static string ConvertToEncrypt(string password)
    {
      if (string.IsNullOrEmpty(password))
      {
        throw new Exception("Senha inválida");
      }

      var bytesSenha = Encoding.UTF8.GetBytes(password);

      return Convert.ToBase64String(bytesSenha);
    }

    public static string ConvertToDecrypt(string passwordBase64EncodeData)
    {
      if (string.IsNullOrEmpty(passwordBase64EncodeData))
      {
        throw new Exception("Hash da seenha inválido");
      }

      var base64EncodeBytes = Convert.FromBase64String(passwordBase64EncodeData);
      var result = Encoding.UTF8.GetString(base64EncodeBytes);

      return result.Substring(0, result.Length);
    }
  }
}