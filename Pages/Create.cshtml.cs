using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MalgreTout.Models;


namespace MalgreTout.Pages
{
    public class Create : PageModel
    {
        
        //Dependency Injection
        Malgretout_DataContext _Context;
         public Create(Malgretout_DataContext malgretoutDataContext)
         {
             _Context = malgretoutDataContext; 
         }
         
         
         
         [BindProperty]
         public NewAllUdleveringssted NewAllUdleveringssted {get; set; }
        
         
         
        //gemmer data i databasen 
        public ActionResult OnPost()
        {
            var newAllUdleveringssted = NewAllUdleveringssted;
            
            if (!ModelState.IsValid)
            {
                return Page(); 
            }
            
            var result = _Context.Add(newAllUdleveringssted); 
            _Context.SaveChanges(); 
            
            return RedirectToPage("ViewAll");
        }
    }
}