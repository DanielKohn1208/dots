using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System;
using PersonalCloud.Shared.Models;

namespace PersonalCloud.Client.ViewModels
{
    public class RootFilesViewModel:IRootFilesViewModel
    {
        public RootFilesViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private readonly HttpClient _httpClient;

        public List<UserFileInfo> AllUserFiles{get; set;} = new List<UserFileInfo>();

        public UserInfo UserInfo{get; set;} = new UserInfo();

        public async Task GetFiles(int id)
        {
            AllUserFiles = await _httpClient.GetFromJsonAsync<List<UserFileInfo>>($"root/getfiles/{id}");
            foreach(var file in AllUserFiles)
            {
                Console.WriteLine(file.FullFileName);
            }
        }

        public async Task<bool> GetUser(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<UserInfo>($"/root/getuserinfo/{id}");
            if (result == null)
            {
                return false;
            }
            UserInfo = result;
            return true;
        }

        public async Task DeleteFile(int id)
        {
            await _httpClient.DeleteAsync($"filemanagement/deletefile/{id}");
        }
        
        
    }
}