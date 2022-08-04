using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Statements.Contracts.Helper
{
  public static class Hash
  {
    public static string HashImageName(string text)
    {
      var now = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds().ToString();
      var bytes=Encoding.UTF8.GetBytes(String.Concat(text,now));
      var hashed = Convert.ToBase64String(SHA1.HashData(bytes));
      return hashed;
    }
  }
}
