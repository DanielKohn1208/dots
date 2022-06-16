
//the purpose of this file is to send information to the user without exposing unwanted things suchs as salts and hashes
using System.Collections.Generic;

namespace PersonalCloud.Shared.Models
{
    public class UserInfo
    {
        public string UserName{get; set;}
        public int Id{get; set;}

        public static implicit operator User(UserInfo userInfo)
        {
            return new User
            {
                UserName = userInfo.UserName,
                UserId = userInfo.Id
            };
        }

        public static implicit operator UserInfo(User user)
        {
            return new UserInfo
            {
                UserName = user.UserName,
                Id = user.UserId
            };
        }
        
    }
}