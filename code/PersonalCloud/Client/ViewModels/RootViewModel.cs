using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using PersonalCloud.Shared.Models;
namespace PersonalCloud.Client.ViewModels
{
    public class RootViewModel : IRootViewModel
    {
        public readonly HttpClient _httpClient;

        public RootViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
            Users = new List<UserInfo>();
        }

        public string Username {get; set;} = "";
        public string Password {get; set;} = "";
        public List<UserInfo> Users{get; set;}

        public async Task<HttpResponseMessage> CreateUser()
        {
            return await _httpClient.PostAsJsonAsync<AddUserModel>("root/adduser",this);
        }

        public async Task GetUsers()
        {
            Users = await _httpClient.GetFromJsonAsync<List<UserInfo>>("root/getusers");
        }

        public async Task DeleteUser(long id)
        {
            await _httpClient.DeleteAsync($"root/deleteuser?id={id}");
        }

        public static implicit operator AddUserModel(RootViewModel rootViewModel)
        {
            return new AddUserModel
            {
                Password = rootViewModel.Password,
                Username = rootViewModel.Username
            };
        }
    }
}