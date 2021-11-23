using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MalgreTout.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MalgreTout.Pages
{
    public class Create : PageModel
    {
        [BindProperty]
        public Kontaktperson Kontaktperson {get; set; }
        
        public void OnGet()
        {
            
        }

        public ActionResult OnPost()
        {
            var kontaktperson = Kontaktperson;
            
            if (ModelState.IsValid)
            {
                return Page(); 
            }

            return RedirectToPage("Overview"); 
        }
    }
}