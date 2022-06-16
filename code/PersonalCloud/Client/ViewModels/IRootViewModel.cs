using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PersonalCloud.Shared.Models;

namespace PersonalCloud.Client.ViewModels
{
    public interface IRootViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<UserInfo> Users{get; set;}
        public Task GetUsers();
        public Task<HttpResponseMessage> CreateUser();
        public Task DeleteUser(long id);
    }
}