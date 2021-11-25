using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MalgreTout.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace MalgreTout.Pages
{
    public class View : PageModel
    {
        Malgretout_DataContext _context;

        public View (Malgretout_DataContext malgretoutDataContext)
        {
            _context = malgretoutDataContext;
        }

        public ActionResult OnGetDelete(int? id)
        {
            if (id != null)
            {
                var data = (from kontaktperson in _context.Kontaktperson
                                        where kontaktperson.Id == id
                                        select kontaktperson).SingleOrDefault();
                _context.Remove(data);
                _context.SaveChanges();
            }
            
            /*if (id != null)
            {
                var data = (from udleveringssted in _context.Udleveringssted
                    where udleveringssted.Id == id
                    select udleveringssted).SingleOrDefault();
                _context.Remove(data);
                _context.SaveChanges();
            }*/

            return RedirectToPage("Create"); 
        }
        
        public List<Kontaktperson> KontaktpersonList { get; set; }
        public void OnGet()
        {
            var data = (from kontaktpersonList in _context.Kontaktperson 
                                        select kontaktpersonList).ToList();
            KontaktpersonList = data;
        }
    }
}