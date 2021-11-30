using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MalgreTout.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MalgreTout.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Malgretout_DataContext _Context;

        public IndexModel(Malgretout_DataContext malgretoutDataContext)
        {
            _Context = malgretoutDataContext;
        }

        public IList<Kontaktperson> Kontaktperson { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }
        
        public async Task OnGetAsync()
        {
            var kontakt = from m in _Context.Kontaktperson
                select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                kontakt = kontakt.Where(s => s.Person.Contains(SearchString));
            }

            Kontaktperson = await kontakt.ToListAsync();
        }
        
    }
}
