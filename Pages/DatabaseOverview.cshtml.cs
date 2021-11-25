using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MalgreTout.Pages
{
    public class DatabaseOverview : PageModel
    {
        
        
        public string WelcomeMessage { get; set; }
        
        
        public void OnGet()
        {

            WelcomeMessage = "Welcome to our new RazorPages!"; 

        }
    }
}