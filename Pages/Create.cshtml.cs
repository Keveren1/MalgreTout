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
        public Udleveringssted Udleveringssted { get; set; }

        Malgretout_DataContext _context;
        public Create(Malgretout_DataContext malgretoutDataContext)
        {
            _context = malgretoutDataContext; 
        }
        
        
        public void OnGet()
        {
            
        }

        public ActionResult OnPost()
        {
            var kontaktperson = Kontaktperson;
            var udleveringssted = Udleveringssted; 
            
            if (ModelState.IsValid)
            {
                return Page(); // return page 
            }

            Kontaktperson.Id = 0;                  
            var result = _context.Add(kontaktperson); 
            _context.SaveChanges(); // gemmer data i databasen 

            Udleveringssted.Id = 0;                                               
            var secondresult = _context.Add(udleveringssted);                           
            _context.SaveChanges(); // gemmer data i databasen     
            
            return RedirectToPage("View");  // overview er ikke lavet endnu   
        }
    }
}