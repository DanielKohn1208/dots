using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Components.Authorization;
using BlazingChat.Client;
using PersonalCloud.Client.ViewModels;
using Blazored.Modal;

namespace PersonalCloud.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();

            builder.Services.AddHttpClient<ILoginViewModel, LoginViewModel>
                ("PersonalCloudClient",client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

            builder.Services.AddHttpClient<IRootViewModel, RootViewModel>
                ("PersonalCloudClient",client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
            

            builder.Services.AddHttpClient<IFilesViewModel, FilesViewModel>
                ("PersonalCloudClient",client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

            builder.Services.AddHttpClient<IRootFilesViewModel, RootFilesViewModel>
                ("PersonalCloudClient",client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

            builder.Services.AddHttpClient<ISettingsViewModel, SettingsViewModel>
                ("PersonalCloudClient",client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<AuthenticationStateProvider,CustomAuthenticationStateProvider>();

            builder.Services.AddBlazoredModal();

            await builder.Build().RunAsync();
        }
    }
}
