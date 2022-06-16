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
    [AllowAnonymous]//not necessary but just wanted it to be stated explicitely:
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly PersonalCloudDb _context;

        public UserController(ILogger<UserController> logger,PersonalCloudDb context)
        {
            this._logger = logger;
            this._context = context;
        }

        //used to login the user
        //POST: user/loginuser
        [HttpPost("loginuser")]
        public async Task<ActionResult<User>> LoginUser([FromBody]User user)
        {
            User userLogin= await _context.Users
                .Where(u => u.UserName == user.UserName 
                && PasswordCryptography.ValidatePassword(user.UserName, user.Password))
                .FirstOrDefaultAsync();
            if(userLogin != null && userLogin.UserName == user.UserName)
            {
                Console.WriteLine("valid credentials");
                //list of claims
                var claimsList = new List<Claim>();

                //create claims 
                var nameClaim = new Claim(ClaimTypes.Name, userLogin.UserName);
                claimsList.Add(nameClaim);
                var nameIdentifierClaim = new Claim(ClaimTypes.NameIdentifier, userLogin.UserId.ToString());
                claimsList.Add(nameIdentifierClaim);
                if(userLogin.Isroot)
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
                await HttpContext.SignInAsync(claimsPrincipal,authProperties);
                return await Task.FromResult(userLogin);
            }
            else
            {
                return NotFound();
            }
        }

        //Gets the current user based on the cookie
        //GET user/currentuser
        [HttpGet("getcurrentuser")]
        public async Task<ActionResult<User>> GetCurrentUser()
        {
            User currentUser = new User();

            if(User.Identity.IsAuthenticated)
            {
                var userName = User.FindFirstValue(ClaimTypes.Name);
                currentUser = await _context.Users.Where(u => u.UserName == userName).FirstOrDefaultAsync();
            }

            return await Task.FromResult(currentUser);
        }

        //logs out the current user
        //GET: /user/logoutuser
        [HttpGet("logoutuser")]
        public async Task<ActionResult<string>> LogOutUser()
        {
            await HttpContext.SignOutAsync();
            return "Success";
        }
    
    }
}