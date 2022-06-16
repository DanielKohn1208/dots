using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using PersonalCloud.Shared.Models;
using System;
using System.Collections.Generic;

namespace BlazingChat.Client
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;

        public CustomAuthenticationStateProvider(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            User currentUser = await _httpClient.GetFromJsonAsync<User>("user/getcurrentuser");

            if (currentUser != null && currentUser.UserName != null)
            {
                var claimsList = new List<Claim>();
                var claimName = new Claim(ClaimTypes.Name, currentUser.UserName);
                var claimNameIdentifier = new Claim(ClaimTypes.NameIdentifier, Convert.ToString(currentUser.UserId));
                claimsList.Add(claimName);
                claimsList.Add(claimNameIdentifier);
                if (currentUser.Isroot)
                {
                    var rootRole = new Claim(ClaimTypes.Role, "root");
                    claimsList.Add(rootRole);
                }
                var claimsIdentity = new ClaimsIdentity(claimsList, "serverAuth");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                return new AuthenticationState(claimsPrincipal);

            }
            else
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

        }
    }
}
