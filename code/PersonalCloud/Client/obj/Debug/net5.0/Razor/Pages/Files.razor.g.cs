#pragma checksum "/home/daniel/code/PersonalCloud/Client/Pages/Files.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "975ceb8f404c4944e7189f99684596ace316debb"
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/files")]
    public partial class Files : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Files</h1>\n\n");
            __builder.AddMarkupContent(1, "<h2>Your Files</h2>");
#nullable restore
#line 9 "/home/daniel/code/PersonalCloud/Client/Pages/Files.razor"
 if(_filesViewModel.AllUserFiles.Count() > 0)
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(2, "table");
            __builder.AddAttribute(3, "class", "table ");
            __builder.AddMarkupContent(4, "<tr><th>Title</th>\n            <th>Date Added</th>\n            <th>Download</th>\n            <th>Delete</th></tr>");
#nullable restore
#line 18 "/home/daniel/code/PersonalCloud/Client/Pages/Files.razor"
             foreach(var userFileInfo in _filesViewModel.AllUserFiles)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(5, "tr");
            __builder.OpenElement(6, "td");
#nullable restore
#line 21 "/home/daniel/code/PersonalCloud/Client/Pages/Files.razor"
__builder.AddContent(7, userFileInfo.FullFileName);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\n                    ");
            __builder.OpenElement(9, "td");
#nullable restore
#line 22 "/home/daniel/code/PersonalCloud/Client/Pages/Files.razor"
__builder.AddContent(10, userFileInfo.DateCreated);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(11, "\n                    ");
            __builder.OpenElement(12, "td");
            __builder.OpenElement(13, "a");
            __builder.AddAttribute(14, "class", "btn btn-outline-dark");
            __builder.AddAttribute(15, "href", 
#nullable restore
#line 24 "/home/daniel/code/PersonalCloud/Client/Pages/Files.razor"
                                                               $"https://localhost:5001/filemanagement/getfile/{userFileInfo.FileId}"

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(16, "download", 
#nullable restore
#line 24 "/home/daniel/code/PersonalCloud/Client/Pages/Files.razor"
                                                                                                                                                 userFileInfo.FullFileName

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(17, "target", "_top");
            __builder.AddMarkupContent(18, "\n                            Download\n                        ");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "\n                    ");
            __builder.OpenElement(20, "td");
            __builder.OpenElement(21, "button");
            __builder.AddAttribute(22, "class", "btn btn-outline-danger");
            __builder.AddAttribute(23, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 29 "/home/daniel/code/PersonalCloud/Client/Pages/Files.razor"
                                                                         () => DeleteFile(userFileInfo.FileId)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(24, "Delete");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 32 "/home/daniel/code/PersonalCloud/Client/Pages/Files.razor"
                
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 35 "/home/daniel/code/PersonalCloud/Client/Pages/Files.razor"
}

else
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(25, "<p>Your uploaded files will show up when </p>");
#nullable restore
#line 40 "/home/daniel/code/PersonalCloud/Client/Pages/Files.razor"
}

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(26, "<h2>Upload</h2>\n\n");
            __builder.OpenElement(27, "form");
            __builder.AddAttribute(28, "onsubmit", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.EventArgs>(this, 
#nullable restore
#line 43 "/home/daniel/code/PersonalCloud/Client/Pages/Files.razor"
                 SubmitFiles

#line default
#line hidden
#nullable disable
            ));
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputFile>(29);
            __builder.AddAttribute(30, "class", "btn btn-outline-dar");
            __builder.AddAttribute(31, "OnChange", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.InputFileChangeEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.InputFileChangeEventArgs>(this, 
#nullable restore
#line 44 "/home/daniel/code/PersonalCloud/Client/Pages/Files.razor"
                                                     OnInputFileChange

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(32, "\n    <br><br>\n    ");
            __builder.AddMarkupContent(33, "<button class=\"btn btn-outline-dark\" type=\"submit\">Upload Selected File</button>");
            __builder.CloseElement();
            __builder.AddMarkupContent(34, "\n");
            __builder.OpenElement(35, "p");
            __builder.AddAttribute(36, "class", "text-danger");
#nullable restore
#line 48 "/home/daniel/code/PersonalCloud/Client/Pages/Files.razor"
__builder.AddContent(37, ErrorMessage);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(38, "\n\n");
            __builder.OpenElement(39, "p");
            __builder.AddAttribute(40, "class", "text-dark");
#nullable restore
#line 50 "/home/daniel/code/PersonalCloud/Client/Pages/Files.razor"
__builder.AddContent(41, StatusMessage);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 52 "/home/daniel/code/PersonalCloud/Client/Pages/Files.razor"
      
    public string ErrorMessage{get; set;} = String.Empty;
    public string StatusMessage{get; set;} = String.Empty;
    
    [CascadingParameter]
    public Task<AuthenticationState> authenticationState{get; set;}
    


    public void OnInputFileChange(InputFileChangeEventArgs e)
    {
        _filesViewModel.SelectedFile = e.File;
    }
    

    protected async override Task OnInitializedAsync()
    {
        var authState = await authenticationState;
        if(!authState.User.Identity.IsAuthenticated)
        {
            _navigationManager.NavigateTo("/");
            return;
        }
        await _filesViewModel.GetFiles();
    }

    protected async Task SubmitFiles()
    {
        if(_filesViewModel.SelectedFile==null)
        {
            Console.WriteLine("here");
            ErrorMessage = "You need to select a file to upload";
            return;
        }
        if(_filesViewModel.SelectedFile.Size > 250000000)
        {
            ErrorMessage = "File is too large. It must be smaller than 250mb.";
            return;  
        }
        ErrorMessage = String.Empty;
        StatusMessage = $"Uploading {_filesViewModel.SelectedFile.Name} to server... (This may take a while depending on file size)";
        var  response = await _filesViewModel.OnSubmit();
        if(response.IsSuccessStatusCode)
        {
            StatusMessage = $"{_filesViewModel.SelectedFile.Name} was successfully uploaded to the server";
            await _filesViewModel.GetFiles();
        }
        else
        {
            StatusMessage=String.Empty;
            ErrorMessage = await response.Content.ReadAsStringAsync();
        }
    

    }

    protected async Task DeleteFile(int id)
    {
        Console.WriteLine("we are deleting a file");
        await _filesViewModel.DeleteFile(id);
        await _filesViewModel.GetFiles();
    }

    

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager _navigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IFilesViewModel _filesViewModel { get; set; }
    }
}
#pragma warning restore 1591
