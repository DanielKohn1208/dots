
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PersonalCloud.Client.ViewModels
{
    public class SettingsViewModel : ISettingsViewModel
    {
        private readonly HttpClient _client;

        public SettingsViewModel(HttpClient client)
        {
            this._client = client;
        }

        public string NewUsername{get; set;}

        public string NewPassword{get; set;} = String.Empty;

        public async Task<HttpResponseMessage> PostNewUsername()
        {
            Console.WriteLine($"The new username is {NewUsername}");
            return await _client.PostAsJsonAsync<string>("usersettings/changeusername",NewUsername);
        }

        public async Task<HttpResponseMessage> PostNewPassword()
        {
            return await _client.PostAsJsonAsync<string>("usersettings/changepassword",NewPassword);
        }

        public async Task<HttpResponseMessage> DeleteAccount()
        {
            return await _client.DeleteAsync("usersettings/deleteaccount");
        }


    
    }
}