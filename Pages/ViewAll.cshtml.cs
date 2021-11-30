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
        
        public void OnGet()
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
        }
        
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


