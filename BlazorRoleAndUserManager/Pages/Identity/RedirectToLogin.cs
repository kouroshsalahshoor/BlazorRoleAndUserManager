using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRoleAndUserManager.Pages.Identity
{
    //https://www.iambacon.co.uk/blog/blazor-authentication-and-authorisation-redirect-to-login
    public class RedirectToLogin : ComponentBase
    {
        [Inject] protected NavigationManager NavigationManager { get; set; }

        //https://stackoverflow.com/questions/59728006/how-do-i-pass-returnurl-to-login-page-in-blazor-server-application
        //[Parameter] public string ReturnUrl { get; set; }
        protected override void OnInitialized()
        {
            //ReturnUrl = "~/" + ReturnUrl;
            //NavigationManager.NavigateTo($"Login?returnUrl={ReturnUrl}", forceLoad: true);
            NavigationManager.NavigateTo("Login");
        }
    }
}
