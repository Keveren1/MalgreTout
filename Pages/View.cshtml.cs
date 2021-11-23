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
    public class ViewModel : PageModel
    {
        private Malgretout_DataContext _context;

        public ViewModel(Malgretout_DataContext malgretoutDataContext)
        {
            _context = malgretoutDataContext;
        }
        
        public List<Kontaktperson> KontaktpersonList { get; set; }
        public void OnGet()
        {
            var data = (from kontaktpersonList in _context.Kontaktpeople 
                                        select kontaktpersonList).ToList();
            KontaktpersonList = data;
        }
    }
}
