using CRM_Micro_Credit.Entity.Models;
using Microsoft.AspNetCore.Authentication;
using System.Reflection;
using System.Security.Claims;

namespace CRM_Micro_Credit.Helpers
{
    public class ClaimsHelper
    {
        /// <summary>
        /// Установка куки
        /// </summary>
        /// <param name="HttpContext"></param>
        /// <param name="claimsDictionary"></param>
        public async static void SetCookieAsync(HttpContext HttpContext, Dictionary<string, string> claimsDictionary)
        {
            var claims = new List<Claim>();

            foreach (var item in claimsDictionary)
            {
                claims.Add(new Claim(item.Key, item.Value));
            }    

            var claimIdentity = new ClaimsIdentity(claims, "Cookie");

            var claimPrincipal = new ClaimsPrincipal(claimIdentity);

            await HttpContext.SignInAsync("Cookie", claimPrincipal);
        }

        /// <summary>
        /// Получение значения куки
        /// </summary>
        /// <param name="claims"></param>
        /// <param name="type"></param>
        /// <param name="logPath"></param>
        /// <returns></returns>
        public static string GetClaimValue(IEnumerable<Claim> claims, string type, string logPath)
        {
            try
            {
                return claims.Where(x => x.Type.Contains(type)).First().Value;
            }
            catch (Exception ex)
            {
                FileHelper fileHelper = new FileHelper(logPath);

                fileHelper.WriteLog(ex.Message, MethodBase.GetCurrentMethod().Name);

                return "";
            }
        }

        /// <summary>
        /// Получение значения куки
        /// </summary>
        /// <param name="claims"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetClaimValue(IEnumerable<Claim> claims, string type)
        {
            try
            {
                return claims.Where(x => x.Type.Contains(type)).First().Value;
            }
            catch
            {
                return "";
            }
        }
    }
}
