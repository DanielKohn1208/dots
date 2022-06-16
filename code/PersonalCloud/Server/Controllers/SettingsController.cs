using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PersonalCloud.Server.Models;
using PersonalCloud.Server.Utility;

namespace PersonalCloud.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserSettingsController: ControllerBase
    {
        private readonly PersonalCloudDb _context;

        public UserSettingsController(PersonalCloudDb context)
        {
            this._context = context;
        }
        [HttpGet("test")]
        public string Test()
        {
            return "this is a test";
        }

        //POST: usersettings/changeusername
        [HttpPost("changeusername")]
        public async Task<IActionResult> ChangeUsername([FromBody] string newUsername)
        {
            Console.WriteLine($"The new username is {newUsername}");
            var userWithNewUsername = _context.Users.FirstOrDefault(f => f.UserName== newUsername);
            if(userWithNewUsername != null)
            {
                return BadRequest("A user with that username already exists");
            }
            var userToChange = await _context.Users
                .FirstOrDefaultAsync(f =>f.UserId == Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)); 
            userToChange.UserName = newUsername;
            await  _context.SaveChangesAsync();

            var claimsList = new List<Claim>();
            //create claims 
            var nameClaim = new Claim(ClaimTypes.Name, newUsername);
            claimsList.Add(nameClaim);
            var nameIdentifierClaim = new Claim(ClaimTypes.NameIdentifier, User.Claims.FirstOrDefault(c => c.Type==ClaimTypes.NameIdentifier).Value);
            claimsList.Add(nameIdentifierClaim);
            if(User.IsInRole("root"))
            {
                var rootRole = new Claim(ClaimTypes.Role, "root");
                claimsList.Add(rootRole);
            }

            //create claims Identity
            var claimsIdentity = new ClaimsIdentity(claimsList,"serverAuth");
            //create claims principal
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            
            var authProperties = new AuthenticationProperties()
            {
                IsPersistent = true
            };
            await HttpContext.SignOutAsync();
            await HttpContext.SignInAsync(claimsPrincipal,authProperties);
            return Ok();
        }

        //POST: settings/changepassword
        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword([FromBody]string newPassword)
        {
            Console.WriteLine($"the new password is {newPassword}");
            var id = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var userToChange = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            var salt = PasswordCryptography.GenerateSalt();
            userToChange.Salt = salt;
            userToChange.Password = PasswordCryptography.SaltAndHashPassword(newPassword, salt);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("deleteaccount")]
        public async Task<IActionResult> DeleteAccount()
        {
            var id = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            Console.WriteLine("this is here");
            var files = _context.UserFiles.Where(u => u.CreatorId == id);
            if(files.Any()) 
            {
                _context.RemoveRange();
            }
            Console.WriteLine("this here again");
            _context.Remove(await _context.Users.FirstOrDefaultAsync(u => u.UserId == id));
            Console.WriteLine("this is here again again");
            await _context.SaveChangesAsync();
            Console.WriteLine("Alright we are done");
            return Ok();
        }
    }
}