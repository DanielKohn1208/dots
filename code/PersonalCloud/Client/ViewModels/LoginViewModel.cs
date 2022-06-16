using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using PersonalCloud.Shared.Models;

namespace PersonalCloud.Client.ViewModels
{
    public class LoginViewModel : ILoginViewModel
    {
        private readonly HttpClient _httpClient;

        public LoginViewModel(){}

        public LoginViewModel(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public string UserName {get; set;}
        public string Password {get; set;}

        public async Task<bool> LoginUser()
        {
            Console.WriteLine("making the api call");

            User userToLogin = this;
            var response = await _httpClient.PostAsJsonAsync<User>("user/loginuser",userToLogin);
            Console.WriteLine("the statu code is : "+response.StatusCode);
            return response.IsSuccessStatusCode;
        }

        public static implicit operator LoginViewModel(User user)
        {
            return new LoginViewModel
            {
                UserName = user.UserName,
                Password = user.Password
            };
        }

        public static implicit operator User(LoginViewModel loginViewModel)
        {
            return new User
            {
                UserName = loginViewModel.UserName,
                Password = loginViewModel.Password
            };
        }
    }
}