using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using MalgreTout.Models;
using MalgreTout.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Data;
using System.Linq;
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;


namespace MalgreTout.Pages
{
    public class ViewAllModel : PageModel
    {

        //Dependency Injection
        Malgretout_DataContext _Context;
        public ViewAllModel(Malgretout_DataContext Malgretout_databasecontext)
        {
            _Context = Malgretout_databasecontext;
        }



        public List<Kontaktperson> KontaktpersonList { get; set; }
        public List<Udleveringssted> UdleveringsstedList { get; set; }
        public List<Postnumre> PostnumreList { get; set; }



        [BindProperty(SupportsGet = true)] public string SearchString { get; set; }



        public string KontaktpersonSort { get; set; }
        public string UdleveringsstedSort { get; set; }
        public string PostnrSort { get; set; }



        public async Task OnGetAsync(string sortOrder)
        {

            //Henter database og laver liste
            var kontaktData = (from kontaktpersonlist in _Context.Kontaktperson
                select kontaktpersonlist).ToList();

            var udleveringData = (from udleveringsstedList in _Context.Udleveringssted
                select udleveringsstedList).ToList();

            var postnumreData = (from postnumreList in _Context.Postnumre
                select postnumreList).ToList();

            KontaktpersonList = kontaktData;
            UdleveringsstedList = udleveringData;
            PostnumreList = postnumreData;



            //Search metode
            var Kontakt = from m in _Context.Kontaktperson
                select m;
            if (!string.IsNullOrEmpty(SearchString)) {
                Kontakt = Kontakt.Where(s => s.Person.Contains(SearchString));
                /*Kontakt = Kontakt.Where(s => s.Mail.Contains(SearchString));*/
            }

            var Udlevering = from m in _Context.Udleveringssted
                select m;
            if (!string.IsNullOrEmpty(SearchString)) {
                /*Udlevering = Udlevering.Where(s => s.Adresse.Contains(SearchString));*/
                Udlevering = Udlevering.Where(s => s.Virksomhed.Contains(SearchString));
            }

            var Post = from m in _Context.Postnumre
                select m;
            if (!string.IsNullOrEmpty(SearchString)) {
                Post = Post.Where(s => s.Bynavn.Contains(SearchString));
            }

            KontaktpersonList = await Kontakt.ToListAsync();
            UdleveringsstedList = await Udlevering.ToListAsync();
            PostnumreList = await Post.ToListAsync();
        
        

        //Sortering metode
        KontaktpersonSort = String.IsNullOrEmpty(sortOrder)? "person_desc" : "";
        UdleveringsstedSort = String.IsNullOrEmpty(sortOrder)? "virksomhed_desc" : "";
        PostnrSort = sortOrder == "Postnr" ? "postnr_desc" : "Postnr";

        IQueryable<Kontaktperson> kontaktperson = from s in _Context.Kontaktperson
            select s;

        IQueryable<Udleveringssted> udleveringssted = from s in _Context.Udleveringssted
            select s;

        IQueryable<Postnumre> postnumre = from s in _Context.Postnumre
                select s;

            switch (sortOrder)
        {
            case "person_desc":
            kontaktperson = kontaktperson.OrderByDescending(s => s.Person);
            break;
            case "virksomhed_desc":
            udleveringssted = udleveringssted.OrderByDescending(s => s.Virksomhed);
            break;
            case "virksomhed":
            udleveringssted = udleveringssted.OrderBy(s => s.Virksomhed);
            break;
            case "postnr_desc":
            postnumre = postnumre.OrderByDescending(s => s.Postnr);
            break;
            default:
            kontaktperson = kontaktperson.OrderBy(s => s.Id);
            break;
        }
            
            // denne ødelækker søg funktionen (SPØRG Jens Peter!)
            /*KontaktpersonList = await kontaktperson.AsNoTracking().ToListAsync();
            UdleveringsstedList = await udleveringssted.AsNoTracking().ToListAsync();
            PostnumreList = await postnumre.AsNoTracking().ToListAsync();*/
    }



        //Delete metode
        public ActionResult OnGetDelete(int? id)
        {
            if (id != null)
            {
                var data = (from kontaktperson in _Context.Kontaktperson
                            where kontaktperson.Id == id
                            select kontaktperson).SingleOrDefault();
                _Context.Remove(data);
                _Context.SaveChanges();
            }

            if (id != null)
            {
                var data = (from udleveringssted in _Context.Udleveringssted
                    where udleveringssted.Id == id
                    select udleveringssted).SingleOrDefault();
                _Context.Remove(data);
                _Context.SaveChanges();
            }
            
            if (id != null)
            {
                var data = (from Postnumre in _Context.Postnumre
                    where Postnumre.Id == id
                    select Postnumre).SingleOrDefault();
                _Context.Remove(data);
                _Context.SaveChanges();
            }

            return RedirectToPage("ViewAll");
        }
        
        
        
        //Export til Excel metode
        public FileResult OnPostExport()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[8] {
                new DataColumn("Id"),
                new DataColumn("Virksomhed"),
                new DataColumn("Adresse"),
                new DataColumn("Postnr"),
                new DataColumn("Bynavn"),
                new DataColumn("Person"),
                new DataColumn("Tlf"),
                new DataColumn("Mail")
            });
            
            var kontaktperson = from Kontaktperson in this._Context.Kontaktperson.Take(10)
                            select Kontaktperson;

            foreach (var Kontaktperson in kontaktperson)
            {
                dt.Rows.Add(Kontaktperson.Id, Kontaktperson.Person, Kontaktperson.Tlf, Kontaktperson.Mail);
            }
            
            var udleveringssted = from Udleveringssted in this._Context.Udleveringssted.Take(10)
                select Udleveringssted;

            foreach (var Udleveringssted in udleveringssted)
            {
                dt.Rows.Add(Udleveringssted.Virksomhed, Udleveringssted.Adresse);
            }
            
            var postnumre = from Postnumre in this._Context.Postnumre.Take(10)
                select Postnumre;

            foreach (var Postnumre in postnumre)
            {
                dt.Rows.Add(Postnumre.Postnr, Postnumre.Bynavn);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Data.xlsx");
                }
            }
        }
    }
}


