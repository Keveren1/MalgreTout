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
         public Kontaktperson Kontaktperson {get; set; }
         [BindProperty]
         public Udleveringssted Udleveringssted { get; set; }
         [BindProperty]
         public Postnumre Postnumre { get; set; }
        
        public void OnGet()
        {
            
        }
       

        
        //gemmer data i databasen 
        public ActionResult OnPost()
        {
            var kontaktperson = Kontaktperson;
            var udleveringssted = Udleveringssted;
            var postnumre = Postnumre;
            
            if (!ModelState.IsValid)
            {
                return Page(); 
            }
            
            var secondresult = _Context.Add(udleveringssted);                           
            _Context.SaveChanges();  
            
            var result = _Context.Add(kontaktperson); 
            _Context.SaveChanges(); 
            
            var thridresult = _Context.Add(postnumre);                           
            _Context.SaveChanges();    
            
            return RedirectToPage("ViewAll");
        }
    }
}