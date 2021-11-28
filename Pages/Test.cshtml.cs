using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MalgreTout.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.InkML;

namespace MalgreTout.Pages
{
    public class Test : PageModel
    {
        Malgretout_DataContext _Context;
        public Test(Malgretout_DataContext Malgretout_databasecontext)
        {
            _Context = Malgretout_databasecontext;
        }

        public List<Kontaktperson> KontaktpersonList { get; set; }
        public IList<Kontaktperson> Kontaktperson { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var kontaktpeople = from m in _Context.Kontaktperson
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                kontaktpeople = kontaktpeople.Where(s => s.Person.Contains(SearchString));
            }

            Kontaktperson = await kontaktpeople.ToListAsync();
        }



        //public void OnGet()
        //{
            

        //}
    }
}