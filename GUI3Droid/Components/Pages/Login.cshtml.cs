using Microsoft.AspNetCore.Mvc.RazorPages;
using _3droidUser;

namespace GUI3Droid.Components.Pages;

public class Login : PageModel
{
    public void OnGet(string username, string password)
    {
        if (userLogin.Login(username, password))
        {
            Response.Redirect("/Home");
            
            HttpContext.Response.Cookies.Append();
        }
        else
        {
            Response.Redirect("/Login");
        }
    }
    
}