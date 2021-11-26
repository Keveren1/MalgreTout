using System.Collections.Generic;
using System;
using System.Collections.Generic;
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
        //public object Kontaktpeople { get; private set; }

        public void OnGet(int? id)
        {
            if (id != null)
            {
                var data = (from kontaktperson in _Context.Kontaktperson
                            where kontaktperson.Id == id
                            select kontaktperson).SingleOrDefault();
                Kontaktperson = data;

            }

        }

        //public ActionResult OnPost()
        //{
        //    var Kontaktperson = kontaktperson;
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _Context.Entry(kontaktperson).Property(x => x.Person).IsModified = true;
        //    _Context.Entry(kontaktperson).Property(x => x.TLF).IsModified = true;
        //    _Context.Entry(kontaktperson).Property(x => x.Mail).IsModified = true;
        //    _Context.SaveChanges();
        //    return RedirectToPage("AllKontaktperson");


        //}


        public ActionResult OnPost()
        {
            var kontaktperson = Kontaktperson;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _Context.Entry(kontaktperson).Property(x => x.Name).IsModified = true;
            _Context.Entry(kontaktperson).Property(x => x.Phoneno).IsModified = true;
            _Context.Entry(kontaktperson).Property(x => x.Address).IsModified = true;
            _Context.Entry(kontaktperson).Property(x => x.City).IsModified = true;
            _Context.Entry(kontaktperson).Property(x => x.Country).IsModified = true;
            _Context.SaveChanges();
            return RedirectToPage("AllCustomer");
        }



    }
}