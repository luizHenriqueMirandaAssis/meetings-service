using System.Security.Cryptography;
using System.Text;

namespace Schedule.Meetings.Domain.Helpers
{
    public class CryptographyHelper
    {
        public static string GenerateHashMd5(string input)
        {
            var data = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(input));
            var builder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
