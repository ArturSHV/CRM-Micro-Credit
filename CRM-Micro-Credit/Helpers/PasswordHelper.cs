using System.Security.Cryptography;
using System.Text;

namespace CRM_Micro_Credit.Helpers
{
	public class PasswordHelper
	{
		public static string HashPassword(string password)
		{
			if (!string.IsNullOrEmpty(password))
			{
				using (var sha256 = SHA256.Create())
				{
					var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
					var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

					return hash;
				}
			}
			return "";
		}
	}
}
