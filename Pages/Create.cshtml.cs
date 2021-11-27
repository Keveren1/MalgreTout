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
        
        Malgretout_DataContext _Context;
         public Create(Malgretout_DataContext malgretoutDataContext)
         {
             _Context = malgretoutDataContext; 
         }
         
         
         [BindProperty]
         public Kontaktperson Kontaktperson {get; set; }
         public Udleveringssted Udleveringssted { get; set; }
        
        public void OnGet()
        {
            
        }
       

        public ActionResult OnPost()
        {
            var kontaktperson = Kontaktperson;
            var udleveringssted = Udleveringssted; 
            
            if (!ModelState.IsValid)
            {
                return Page(); // return page 
            }
            
            

            //Kontaktperson.Id = 0;                  
            var result = _Context.Add(kontaktperson); 
            _Context.SaveChanges(); // gemmer data i databasen 

            /*Udleveringssted.Id = 1;                                               
            var secondresult = _Context.Add(udleveringssted);                           
            _Context.SaveChanges(); // gemmer data i databasen     #1#*/
            
            return RedirectToPage("AllKontaktperson");     
            
            
        }
    }
}