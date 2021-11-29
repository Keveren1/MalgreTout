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
       

        public ActionResult OnPost()
        {
            var kontaktperson = Kontaktperson;
            var udleveringssted = Udleveringssted;
            var postnumre = Postnumre;
            
            if (!ModelState.IsValid)
            {
                return Page(); // return page 
            }



            var secondresult = _Context.Add(udleveringssted);                           
            _Context.SaveChanges(); // gemmer data i databasen   
            
            var result = _Context.Add(kontaktperson); 
            _Context.SaveChanges(); // gemmer data i databasen 
            
            var thridresult = _Context.Add(postnumre);                           
            _Context.SaveChanges(); // gemmer data i databasen     
            
            return RedirectToPage("AllKontaktperson");     
            
            
        }
    }
}