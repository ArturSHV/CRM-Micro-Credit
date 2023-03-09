using CRM_Micro_Credit.Entity.Models;
using CRM_Micro_Credit.Interfaces;
using Microsoft.AspNetCore.Authentication;
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
        public async static void SetCookie(HttpContext HttpContext, Dictionary<string, string> claimsDictionary)
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
    }
}
