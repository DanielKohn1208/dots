using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalCloud.Shared.Models;

namespace PersonalCloud.Client.ViewModels
{
    public interface IRootFilesViewModel
    {
        List<UserFileInfo> AllUserFiles { get; set; }
        UserInfo UserInfo { get; set; }

        Task DeleteFile(int id);
        Task GetFiles(int id);
        Task<bool> GetUser(int id);
    }
}