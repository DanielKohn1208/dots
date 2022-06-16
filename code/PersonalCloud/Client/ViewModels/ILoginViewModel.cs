using System;
using System.Threading.Tasks;

namespace PersonalCloud.Client.ViewModels
{
    public interface ILoginViewModel
    {
        public string UserName{get; set;}
        public string Password{get; set;}

        public Task<bool> LoginUser();


    }
}