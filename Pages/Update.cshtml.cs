using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MalgreTout.Models;
using MalgreTout.Pages;
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
    }
}