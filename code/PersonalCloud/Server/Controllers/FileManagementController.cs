using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PersonalCloud.Server.Models;
using PersonalCloud.Server.Utility;
using System.IO;
using System.Web;
using System.Net.Http;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace PersonalCloud.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class FileManagementController: ControllerBase
    {
        public readonly PersonalCloudDb _context;
        public readonly ILogger<FileManagementController> _logger;

        public FileManagementController(PersonalCloudDb context, ILogger<FileManagementController> logger)
        {
            _context = context;
            _logger = logger;
        }

        //this needs to return http 201 but no place to actually get the resource so that will have to wait

        //allows a user to upload a file to the server
        //POST: /filemanagement/upload
        [HttpPost("upload")]
        public async Task<IActionResult> UploadUserFile(UserFile uploadedFile) 
        {
            string idAsString = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            int id = Int32.Parse(idAsString);
            var fileWithSameName = _context.UserFiles
                .FirstOrDefault(f => $"{f.FileName}{f.FileExtension}" 
                    == $"{uploadedFile.FileName}{uploadedFile.FileExtension}"
                    && uploadedFile.CreatorId == id);
            if(fileWithSameName == null)
            {
                return BadRequest("A file with the same name already exists");
            }
            uploadedFile.CreatorId = id;
            uploadedFile.DateAdded = DateTime.Now;
            await _context.AddAsync(uploadedFile);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //slow and inneficient for the moment ***neeeds to be optomised coool ligature lmao
        //returns information about all of the files
        //GET: filemanagement/getfiles
        [HttpGet("getfiles")]
        public List<UserFileInfo> GetAllFiles()
        {
            var files = _context.UserFiles.Where(f => 
                f.CreatorId == Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value));
            List<UserFileInfo> fileInfo = new List<UserFileInfo>();
            foreach(var file in files)
            {
                fileInfo.Add(file);
            }
            return fileInfo.OrderBy(f => f.DateCreated).ToList();
        }

        //permissions for this need to be fixed to allow root or specific users to do this
        //returns the file based on the id specified
        //GET: filemanagement/getfile/{id}
        [HttpGet("getfile/{id}")]
        public async Task<IActionResult> GetFile(int id)
        {
            int userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var userFile = await _context.UserFiles.FirstOrDefaultAsync(f => f.FileId == id);
            if(userFile == null)
            {
                return NotFound();
            }
            if(userFile.CreatorId != userId)
            {
                bool isRoot = User.IsInRole("root");
                if(!isRoot)
                {
                    return Forbid();
                }
            }
            string mimeType = "appplication/octet-stream";
            return new FileContentResult(userFile.FileContent,mimeType)
            {
                FileDownloadName = userFile.FileName+userFile.FileExtension
            };
        }

        // deletes the specified file
        // DELETE: filemanagement/deletefile/{id}
        [HttpDelete("deletefile/{id}")]
        public async Task<IActionResult> DeleteFile(int id)
        {
            var file = await _context.UserFiles.FirstOrDefaultAsync(f => f.FileId == id);
            if(file == null)
            {
                return BadRequest("The provided id was not valid");
            }
            int userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if(file.CreatorId == userId || User.IsInRole("root"))
            {
                _context.Remove(file);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return Forbid();
        }




    }
}