using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using PersonalCloud.Shared.Models;

namespace PersonalCloud.Client.ViewModels
{
    public interface IFilesViewModel
    {
        public string FullFileName{get; set;}
        public byte[] FileContent{get; set;}
        IBrowserFile SelectedFile {get; set;}
        List<UserFileInfo> AllUserFiles { get; set; }

        Task DeleteFile(int id);
        Task GetFiles();
        Task<HttpResponseMessage> OnSubmit();
    }
}