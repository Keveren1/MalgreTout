using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.InkML;
using MalgreTout.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MalgreTout.Pages
{
    public class Test : PageModel
    {
        private readonly Malgretout_DataContext _Context;

        public Test(Malgretout_DataContext malgretoutDataContext)
        {
            _Context = malgretoutDataContext;
        }
        
        public List<Kontaktperson> KontaktpersonList { get; set; }
        public List<Udleveringssted> UdleveringsstedList { get; set; }
        public List<Postnumre> PostnumreList { get; set; }

        
        
        /*public string SearchTerm { get; set; }


        public IEnumerable<Kontaktperson> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm)) {

                return KontaktpersonList;
            }

            return KontaktpersonList.Where(e =>
                e.Person.Contains(SearchTerm) || e.Mail.Contains(SearchTerm));
        }*/

            /*public void OnGet()
        {
            var data = (from kontaktpersonlist in _Context.Kontaktperson
                select kontaktpersonlist).ToList();
            
            var data2 = (from udleveringsstedList in _Context.Udleveringssted
                select udleveringsstedList).ToList();
            
            var data3 = (from postnumreList in _Context.Postnumre
                select postnumreList).ToList();
            
            KontaktpersonList = data;
            UdleveringsstedList = data2;
            PostnumreList = data3;

            
        }*/
        
        
        

        /*public async Task OnGetAsync()
        {
            var data = (from kontaktpersonList in _Context.Kontaktperson
                select kontaktpersonList).ToList();
            KontaktpersonList = data;

            var kontaktpeople = from m in _Context.Kontaktperson
                select m;
            if (!string.IsNullOrEmpty(SearchString)) {
                kontaktpeople = kontaktpeople.Where(s => s.Person.Contains(SearchString));
            }

            Kontaktperson = await kontaktpeople.ToListAsync();*/
            
            
        /*public IList<Kontaktperson> Kontaktperson { get; set; }*/
        
        [BindProperty(SupportsGet = true)] 
        public string SearchString { get; set; }
        
        
        
            public async Task OnGetAsync()
            {
                
                var data = (from kontaktpersonList in _Context.Kontaktperson
                    select kontaktpersonList).ToList();
                KontaktpersonList = data;
                
                
                var Test = from m in _Context.Kontaktperson
                    select m;
                if (!string.IsNullOrEmpty(SearchString))
                {
                    Test = Test.Where(s => s.Person.Contains(SearchString));
                }

                KontaktpersonList = await Test.ToListAsync();
            }
            
            
            
            public string NameSort { get; set; }
            public string DateSort { get; set; }
            public string CurrentFilter { get; set; }
            public string CurrentSort { get; set; }

            
            
            
            
            
            /*public async Task OnGetAsync(string sortOrder)
            {
                // using System;
                NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                
                IQueryable<Kontaktperson> studentsIQ = from s in _Context.Kontaktperson
                    select s;

                switch (sortOrder)
                {
                    case "name_desc":
                        studentsIQ = studentsIQ.OrderByDescending(s => s.Person);
                        break;
                    default:
                        studentsIQ = studentsIQ.OrderBy(s => s.Person);
                        break;
                }

                KontaktpersonList = await studentsIQ.AsNoTracking().ToListAsync();
            }*/
    }
            
            
            
            
            /*public async Task OnGetAsync()
            {
                var movies = from m in _context.Movie
                    select m;
                if (!string.IsNullOrEmpty(SearchString))
                {
                    movies = movies.Where(s => s.Title.Contains(SearchString));
                }

                Movie = await movies.ToListAsync();
            }*/
            














            /*public async Task OnGetAsync()
           {
               var kontaktpeople = from m in _context.Kontaktperson
                                   select m;
               if (!string.IsNullOrEmpty(SearchString))
               {
                   kontaktpeople = kontaktpeople.Where(s => s.Person.Contains(SearchString));
               }
   
               Kontaktperson = await kontaktpeople.ToListAsync();
   
           }*/



        }
 

