#pragma checksum "/home/daniel/code/PersonalCloud/Client/Pages/Login.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5a1b3a120d5939c773eafee4e109430a062f1218"
// <auto-generated/>
#pragma warning disable 1591
namespace PersonalCloud.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/home/daniel/code/PersonalCloud/Client/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/daniel/code/PersonalCloud/Client/_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/home/daniel/code/PersonalCloud/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/home/daniel/code/PersonalCloud/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/home/daniel/code/PersonalCloud/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/home/daniel/code/PersonalCloud/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/home/daniel/code/PersonalCloud/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/home/daniel/code/PersonalCloud/Client/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/home/daniel/code/PersonalCloud/Client/_Imports.razor"
using PersonalCloud.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/home/daniel/code/PersonalCloud/Client/_Imports.razor"
using PersonalCloud.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "/home/daniel/code/PersonalCloud/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "/home/daniel/code/PersonalCloud/Client/_Imports.razor"
using PersonalCloud.Client.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "/home/daniel/code/PersonalCloud/Client/_Imports.razor"
using Blazored;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "/home/daniel/code/PersonalCloud/Client/_Imports.razor"
using Blazored.Modal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "/home/daniel/code/PersonalCloud/Client/_Imports.razor"
using Blazored.Modal.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/daniel/code/PersonalCloud/Client/Pages/Login.razor"
using PersonalCloud.Shared.Models;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Login : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h2><b>Login</b></h2>\n<hr>\n\n");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "col-6");
            __builder.OpenElement(3, "input");
            __builder.AddAttribute(4, "type", "text");
            __builder.AddAttribute(5, "class", "form-control");
            __builder.AddAttribute(6, "placeholder", "User Name");
            __builder.AddAttribute(7, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 11 "/home/daniel/code/PersonalCloud/Client/Pages/Login.razor"
                              _loginViewModel.UserName

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(8, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => _loginViewModel.UserName = __value, _loginViewModel.UserName));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\n\n");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", "col-6");
            __builder.OpenElement(12, "input");
            __builder.AddAttribute(13, "type", "text");
            __builder.AddAttribute(14, "class", "form-control");
            __builder.AddAttribute(15, "placeholder", "Password");
            __builder.AddAttribute(16, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 15 "/home/daniel/code/PersonalCloud/Client/Pages/Login.razor"
                              _loginViewModel.Password

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(17, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => _loginViewModel.Password = __value, _loginViewModel.Password));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\n\n");
            __builder.OpenElement(19, "div");
            __builder.AddAttribute(20, "class", "col-6");
            __builder.OpenElement(21, "button");
            __builder.AddAttribute(22, "class", "btn btn-primary");
            __builder.AddAttribute(23, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 19 "/home/daniel/code/PersonalCloud/Client/Pages/Login.razor"
                                              LoginUser

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(24, "Login");
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 22 "/home/daniel/code/PersonalCloud/Client/Pages/Login.razor"
      
    public async Task LoginUser()
    {
        await _loginViewModel.LoginUser();
        _navigationManager.NavigateTo("/counter", true);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILoginViewModel _loginViewModel { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient _httpClient { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager _navigationManager { get; set; }
    }
}
#pragma warning restore 1591
