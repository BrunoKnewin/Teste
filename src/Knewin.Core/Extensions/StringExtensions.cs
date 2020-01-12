using System.Text;
using System.Security.Cryptography;

namespace Knewin.Core.Extensions
{
    public static class StringExtensions
    {
        public static string HashPassword(this string password)
        {
            byte[] data = Encoding.UTF8.GetBytes(password);
            data = new SHA256Managed().ComputeHash(data);
            return Encoding.UTF8.GetString(data);
        }
    }
}
