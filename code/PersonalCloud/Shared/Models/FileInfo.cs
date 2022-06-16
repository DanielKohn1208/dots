//this file is used to send the information about a file without overloading with the contents,. That would maek the requests to large
using System;
namespace PersonalCloud.Shared.Models
{
    public class UserFileInfo
    {
        public int FileId{get; set;}

        public string FullFileName{get; set;}
        
        public DateTime? DateCreated{get; set;}

        public static implicit operator UserFileInfo(UserFile file)
        {
            return new UserFileInfo
            {
                FileId = file.FileId,
                FullFileName = $"{file.FileName}{file.FileExtension}",
                DateCreated = file.DateAdded
            };
        }


    }
}