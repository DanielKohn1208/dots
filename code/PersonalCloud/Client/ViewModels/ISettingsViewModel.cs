
using System.Net.Http;
using System.Threading.Tasks;

namespace PersonalCloud.Client.ViewModels
{
    public interface ISettingsViewModel
    {
        string NewUsername { get; set; }
        string NewPassword { get; set; }

        Task<HttpResponseMessage> DeleteAccount();
        Task<HttpResponseMessage> PostNewPassword();
        Task<HttpResponseMessage> PostNewUsername();
    }
}