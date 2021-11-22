using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MalgreTout.Pages
{
    public class Customer : PageModel
    {
        public string WelcomeMessage { get; set; }
        public void OnGet()
        {
            WelcomeMessage = "Welcome to my new Razor Pages!!"; 
        }
    }
}