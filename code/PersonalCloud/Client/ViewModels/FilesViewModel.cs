using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using PersonalCloud.Shared.Models;

namespace PersonalCloud.Client.ViewModels
{
    public class FilesViewModel : IFilesViewModel
    {
        private readonly HttpClient _httpClient;
        public FilesViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
            AllUserFiles = new List<UserFileInfo>();
        }

        public string FullFileName{get; set;}

        public byte[] FileContent{get; set;}

        public IBrowserFile SelectedFile{get; set;}
        
        public List<UserFileInfo> AllUserFiles{get; set;}

        public async Task GetFiles()
        {
            AllUserFiles = await _httpClient.GetFromJsonAsync<List<UserFileInfo>>("filemanagement/getfiles");
        }
        public async Task DeleteFile(int id)
        {
            
            await _httpClient.DeleteAsync($"filemanagement/deletefile/{id}");
        }

        public async Task<HttpResponseMessage> OnSubmit()
        {
            Stream stream = SelectedFile.OpenReadStream(250000000);
            MemoryStream ms = new MemoryStream();
            await stream.CopyToAsync(ms);
            stream.Close();   
            FullFileName = SelectedFile.Name;
            FileContent = ms.ToArray();
            Console.WriteLine("posting the file");
            var result = await _httpClient.PostAsJsonAsync<UserFile>("/filemanagement/upload",new UserFile{
                FileContent = FileContent,
                FileName = Path.GetFileNameWithoutExtension(FullFileName),
                FileExtension = Path.GetExtension(FullFileName)
            });
            ms.Close();
            return result;

        }

    }
}