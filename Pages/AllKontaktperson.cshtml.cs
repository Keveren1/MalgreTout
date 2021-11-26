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
    public class AllKontaktpersonModel : PageModel
    {

        Malgretout_DataContext _Context;
        public AllKontaktpersonModel(Malgretout_DataContext Malgretout_databasecontext)
        {
            _Context = Malgretout_databasecontext;
        }

        public List<Kontaktperson> KontaktpersonList { get; set; }

        public void OnGet()
        {
            var data = (from kontaktpersonlist in _Context.Kontaktperson
                        select kontaktpersonlist).ToList();

            KontaktpersonList = data;
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

            /*if (id != null)
            {
                var data = (from udleveringssted in _context.Udleveringssted
                    where udleveringssted.Id == id
                    select udleveringssted).SingleOrDefault();
                _context.Remove(data);
                _context.SaveChanges();
            }*/

            return RedirectToPage("AllKontaktperson");
        }


        //Export til Excel metode
        public FileResult OnPostExport()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Id"),
                                    new DataColumn("Person"),
                                    new DataColumn("TLF"),
                                    new DataColumn("Mail") });

            var kontaktperson = from Kontaktperson in this._Context.Kontaktperson.Take(10)
                            select Kontaktperson;

            foreach (var Kontaktperson in kontaktperson)
            {
                dt.Rows.Add(Kontaktperson.Id, Kontaktperson.Person, Kontaktperson.TLF, Kontaktperson.Mail);
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

