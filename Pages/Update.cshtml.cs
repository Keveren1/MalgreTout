using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Spreadsheet;
using MalgreTout.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MalgreTout.Pages
{
    public class UpdateModel : PageModel
    {
        //Dependency Injection
        Malgretout_DataContext _Context;
        public UpdateModel(Malgretout_DataContext Malgretout_databaseContext)
        {
            _Context = Malgretout_databaseContext;
        }


        
        [BindProperty]
        public NewAllUdleveringssted NewAllUdleveringssted { get; set; }
      
        
        //Indhenter data fra felter
        public void OnGet(int? id)
        {
            if (id != null)
            {
                var newAllUdleveringsstedData = (from newAllUdleveringssted in _Context.NewAllUdleveringssted
                            where newAllUdleveringssted.Id == id
                            select newAllUdleveringssted).SingleOrDefault();
                
                NewAllUdleveringssted = newAllUdleveringsstedData;
            }
        }
        
        
        //Gemmer ændringer til felter 
        public ActionResult OnPost()
        {
            
            var newAllUdleveringsstedData = NewAllUdleveringssted;
            
            
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            _Context.Entry(newAllUdleveringsstedData).Property(x => x.Virksomhed).IsModified = true;
            _Context.Entry(newAllUdleveringsstedData).Property(x => x.Adresse).IsModified = true;
            _Context.Entry(newAllUdleveringsstedData).Property(x => x.Person).IsModified = true;
            _Context.Entry(newAllUdleveringsstedData).Property(x => x.Tlf).IsModified = true;
            _Context.Entry(newAllUdleveringsstedData).Property(x => x.Mail).IsModified = true;
            _Context.Entry(newAllUdleveringsstedData).Property(x => x.Postnr).IsModified = true;
            _Context.Entry(newAllUdleveringsstedData).Property(x => x.Bynavn).IsModified = true;
            _Context.SaveChanges();
            
            return RedirectToPage("ViewAll");
        }
    }
}
