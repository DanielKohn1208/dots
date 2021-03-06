#pragma checksum "/home/daniel/code/PersonalCloud/Client/Pages/Root.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a0702875a09845565db50155aa43bc9bf9a52b9c"
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/root")]
    public partial class Root : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h2><b>Root Controls</b></h2>\n\n");
            __builder.AddMarkupContent(1, "<h3>Add User</h3>\n");
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "col-6");
            __builder.OpenElement(4, "input");
            __builder.AddAttribute(5, "type", "text");
            __builder.AddAttribute(6, "class", "form-control");
            __builder.AddAttribute(7, "placeholder", "User Name");
            __builder.AddAttribute(8, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 10 "/home/daniel/code/PersonalCloud/Client/Pages/Root.razor"
                               _rootViewModel.UserName

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(9, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => _rootViewModel.UserName = __value, _rootViewModel.UserName));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\n\n");
            __builder.OpenElement(11, "div");
            __builder.AddAttribute(12, "class", "col-6");
            __builder.OpenElement(13, "input");
            __builder.AddAttribute(14, "type", "text");
            __builder.AddAttribute(15, "class", "form-control");
            __builder.AddAttribute(16, "placeholder", "Password");
            __builder.AddAttribute(17, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 14 "/home/daniel/code/PersonalCloud/Client/Pages/Root.razor"
                               _rootViewModel.Password

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(18, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => _rootViewModel.Password = __value, _rootViewModel.Password));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "\n\n");
            __builder.OpenElement(20, "div");
            __builder.AddAttribute(21, "class", "col-6");
            __builder.OpenElement(22, "button");
            __builder.AddAttribute(23, "class", "btn btn-primary");
            __builder.AddAttribute(24, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 18 "/home/daniel/code/PersonalCloud/Client/Pages/Root.razor"
                                              CreateUser

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(25, "Add User");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\n\n");
            __builder.AddMarkupContent(27, "<h3>Users</h3>\n");
            __builder.OpenElement(28, "table");
            __builder.AddAttribute(29, "class", "table");
            __builder.AddMarkupContent(30, "<tr><td scope=\"col\">User Name</td>\n        <td scope=\"col\">Id</td>\n        <td scope=\"col\">Delete</td></tr>");
#nullable restore
#line 28 "/home/daniel/code/PersonalCloud/Client/Pages/Root.razor"
     foreach(var user in @_rootViewModel.Users)
    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(31, "tr");
            __builder.OpenElement(32, "td");
#nullable restore
#line 31 "/home/daniel/code/PersonalCloud/Client/Pages/Root.razor"
__builder.AddContent(33, user.UserName);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(34, "\n            ");
            __builder.OpenElement(35, "td");
#nullable restore
#line 32 "/home/daniel/code/PersonalCloud/Client/Pages/Root.razor"
__builder.AddContent(36, user.Id);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(37, "\n            ");
            __builder.OpenElement(38, "td");
            __builder.OpenElement(39, "button");
            __builder.AddAttribute(40, "class", "btn btn-danger");
            __builder.AddAttribute(41, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 34 "/home/daniel/code/PersonalCloud/Client/Pages/Root.razor"
                                                         () => DeleteUser(user.Id)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(42, "Delete User");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 37 "/home/daniel/code/PersonalCloud/Client/Pages/Root.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 42 "/home/daniel/code/PersonalCloud/Client/Pages/Root.razor"
      
    
    [CascadingParameter]
    public Task<AuthenticationState> authenticationState{get; set;}
    
    protected override async Task OnInitializedAsync()
    {
        var authState = await authenticationState;

        var user = authState.User;
        if(!user.IsInRole("root"))
        {
            _navigationManager.NavigateTo("/");
        }
        await _rootViewModel.GetUsers();
    }

    protected async Task CreateUser()
    {
        await _rootViewModel.CreateUser();
        await _rootViewModel.GetUsers();
    }

    protected async Task DeleteUser(long id)
    {
        await _rootViewModel.DeleteUser(id);
        await _rootViewModel.GetUsers();
    }



#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IModalService Modal { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IRootViewModel _rootViewModel { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager _navigationManager { get; set; }
    }
}
#pragma warning restore 1591
