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
    [Authorize(Roles = "root")]
    public class RootController : ControllerBase
    {
        private readonly ILogger<RootController> _logger;
        private readonly PersonalCloudDb _context;

        public RootController(ILogger<RootController> logger,PersonalCloudDb context)
        {
            this._logger = logger;
            this._context = context;
        }

        //allows the root user to add the user
        //POST: root/adduser
        [HttpPost("adduser")]
        public async Task<ActionResult> AddUser(AddUserModel userToAdd)
        {
            //check for user with the same name 
            Console.WriteLine("we made it here");
            if(userToAdd.Username.Length>16 || userToAdd.Username.Length<0 
                || userToAdd.Password.Length>16 || userToAdd.Password.Length<0)
            {
                return BadRequest("The username or password were of incorrect length");
            }
            Console.WriteLine("here 2");
            if(await _context.Users.FirstOrDefaultAsync(u => u.UserName == userToAdd.Username) != null)
            {
                return BadRequest("A user with this username already exists");
            }
            Console.WriteLine("here 3 ");
            var user = PasswordCryptography.Register(userToAdd.Username,userToAdd.Password);
            await _context.AddAsync(user); 
            await _context.SaveChangesAsync();
            return Ok();
        }

        //returns a list of all users
        //GET: root/getusers
        [HttpGet("getusers")]
        public async Task<List<UserInfo>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            var usersInfo = new List<UserInfo>();
            foreach(var user in users)
            {
                usersInfo.Add(user);
            }
            return usersInfo;
            
        }

        [HttpGet("getuserinfo/{id}")]
        public async Task<UserInfo> GetUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            return user;
            
        }


        //Deletes a specific user from the database
        //DELETE: root/deleteuser/{id}
        [HttpDelete("deleteuser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            
            var userToDelete = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            var filesToDelete = _context.UserFiles.Where(u => u.CreatorId== id);
            if(filesToDelete.Any())
            {
                _context.UserFiles.RemoveRange();
            }
            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //GET: root/getfiles/{id}
        [HttpGet("getfiles/{id}")]
        public List<UserFileInfo> GetAllFiles(int id)
        {
            var files = _context.UserFiles
                .Where(u => u.CreatorId == id);
            List<UserFileInfo> fileInfo = new List<UserFileInfo>();
            foreach(var file in files)
            {
                fileInfo.Add(file);
            }
            return fileInfo.OrderBy(f => f.DateCreated).ToList();
        }

    }
}