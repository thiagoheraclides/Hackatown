using System.Security.Cryptography;
using System.Text;

namespace Br.Com.Fiap.Postech.Hackaton.Api.Tools
{
    public static class Hasher
    {
        public static string Hash(string rawData)
        {
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(rawData));

            StringBuilder builder = new();

            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
