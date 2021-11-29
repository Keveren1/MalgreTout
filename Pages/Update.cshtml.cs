using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using MalgreTout.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MalgreTout.Pages
{
    public class UpdateModel : PageModel
    {
        Malgretout_DataContext _Context;
        public UpdateModel(Malgretout_DataContext Malgretout_databaseContext)
        {
            _Context = Malgretout_databaseContext;
        }
        
        
        [BindProperty]
        public Kontaktperson Kontaktperson { get; set; }
        [BindProperty]
        public Udleveringssted Udleveringssted { get; set; }
        [BindProperty]
        public Postnumre Postnumre { get; set; }
        
        
        
        //public object Kontaktpeople { get; private set; }

        public void OnGet(int? id)
        {
            if (id != null)
            {
                var data = (from kontaktperson in _Context.Kontaktperson
                            where kontaktperson.Id == id
                            select kontaktperson).SingleOrDefault();
                
                var data2 = (from udleveringssted in _Context.Udleveringssted
                    where udleveringssted.Id == id
                    select udleveringssted).SingleOrDefault();
                
                var data3 = (from postnumre in _Context.Postnumre
                    where postnumre.Id == id
                    select postnumre).SingleOrDefault();
                
                Kontaktperson = data;
                Udleveringssted = data2;
                Postnumre = data3;

            }
        }
        public ActionResult OnPost()
        {
            var kontaktperson = Kontaktperson;
            var udleveringssted = Udleveringssted;
            var postnumre = Postnumre;
            
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _Context.Entry(kontaktperson).Property(x => x.Person).IsModified = true;
            _Context.Entry(kontaktperson).Property(x => x.Tlf).IsModified = true;
            _Context.Entry(kontaktperson).Property(x => x.Mail).IsModified = true;
            _Context.Entry(udleveringssted).Property(x => x.Virksomhed).IsModified = true;
            _Context.Entry(udleveringssted).Property(x => x.Adresse).IsModified = true;
            _Context.Entry(postnumre).Property(x => x.Postnr).IsModified = true;
            _Context.Entry(postnumre).Property(x => x.Bynavn).IsModified = true;
            _Context.SaveChanges();
            
            return RedirectToPage("AllKontaktperson");
        }
    }
}
