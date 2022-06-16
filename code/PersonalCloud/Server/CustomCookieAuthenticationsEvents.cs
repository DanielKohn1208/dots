using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using PersonalCloud.Server.Models;
namespace PersonalCloud.Server
{
    public class CustomCookieAuthenticationEvents : CookieAuthenticationEvents
    {
        private readonly PersonalCloudDb _context;

        public CustomCookieAuthenticationEvents(PersonalCloudDb context)
        {
            this._context = context;
        }

        public override async Task ValidatePrincipal(CookieValidatePrincipalContext user)
        {
            var value = Int32.Parse(user.Principal.FindFirst(ClaimTypes.NameIdentifier).Value);
            var userToSignOut = await _context.Users.FirstOrDefaultAsync(u => u.UserId == value);
            if(userToSignOut != null) { return; }
            
            await user.HttpContext.SignOutAsync();



            
            
        }
    }
}