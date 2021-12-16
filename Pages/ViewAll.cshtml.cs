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
        
        
        
        public string IdSort { get; set; }
        public string VirksomhedSort { get; set; }
        public string AdresseSort { get; set; }
        public string PostnrSort { get; set; }
        public string BynavnSort { get; set; }
        public string PersonSort { get; set; }
        public string TlfSort { get; set; }
        public string MailSort { get; set; }
        
        public string CurrentFilter { get; set; }
        
        public IList<NewAllUdleveringssted> NewAllUdleveringssted { get; set; }
        
        [BindProperty]
        public NewAllUdleveringssted NewAllUdleveringssteds { get; set; }
        
        public async Task OnGetAsync(string sortOrder, string searchString)
        {

            //Henter database og laver liste
            var newAllUdleveringsstedListData = (from newAllUdleveringsstedList in _Context.NewAllUdleveringssted
                select newAllUdleveringsstedList).ToList();
            
            
            
            CurrentFilter = searchString;
            
            
            
            //Search metode
            IQueryable<NewAllUdleveringssted> newAllUdleveringsstedIQ = from s in _Context.NewAllUdleveringssted
                select s;
            
            if (!string.IsNullOrEmpty(searchString)) {
                newAllUdleveringsstedIQ = newAllUdleveringsstedIQ.Where(s => s.Virksomhed.Contains(searchString)|| s.Adresse.Contains(searchString) 
                    || s.Bynavn.Contains(searchString) || s.Person.Contains(searchString) || s.Mail.Contains(searchString));
            }
            
            
            
            //Sortering metode
            IdSort = sortOrder == "Id" ? "Id_desc" : "Id";
            VirksomhedSort = sortOrder == "Virksomhed" ? "Virksomhed_desc" : "Virksomhed";
            AdresseSort = sortOrder == "Adresse" ? "Adresse_desc" : "Adresse";
            PostnrSort = sortOrder == "Postnr" ? "Postnr_desc" : "Postnr";
            BynavnSort = sortOrder == "Bynavn" ? "Bynavn_desc" : "Bynavn";
            PersonSort = sortOrder == "Person" ? "Person_desc" : "Person";
            TlfSort = sortOrder == "Tlf" ? "Tlf_desc" : "Tlf";
            MailSort = sortOrder == "Mail" ? "Mail_desc" : "Mail";
            
                switch (sortOrder)
            {
                case "Id_desc":
                    newAllUdleveringsstedIQ = newAllUdleveringsstedIQ.OrderByDescending(s => s.Id);
                    break;
                case "Id":
                    newAllUdleveringsstedIQ = newAllUdleveringsstedIQ.OrderBy(s => s.Id);
                    break;
                case "Virksomhed_desc":
                    newAllUdleveringsstedIQ = newAllUdleveringsstedIQ.OrderByDescending(s => s.Virksomhed);
                    break;
                case "Virksomhed":
                    newAllUdleveringsstedIQ = newAllUdleveringsstedIQ.OrderBy(s => s.Virksomhed);
                    break;
                case "Adresse_desc":
                    newAllUdleveringsstedIQ = newAllUdleveringsstedIQ.OrderByDescending(s => s.Adresse);
                    break;
                case "Adresse":
                    newAllUdleveringsstedIQ = newAllUdleveringsstedIQ.OrderBy(s => s.Adresse);
                    break;
                case "Postnr_desc":
                    newAllUdleveringsstedIQ = newAllUdleveringsstedIQ.OrderByDescending(s => s.Postnr);
                    break;
                case "Postnr":
                    newAllUdleveringsstedIQ = newAllUdleveringsstedIQ.OrderBy(s => s.Postnr);
                    break;
                case "Bynavn_desc":
                    newAllUdleveringsstedIQ = newAllUdleveringsstedIQ.OrderByDescending(s => s.Bynavn);
                    break;
                case "Bynavn":
                    newAllUdleveringsstedIQ = newAllUdleveringsstedIQ.OrderBy(s => s.Bynavn);
                    break;
                case "Person_desc":
                    newAllUdleveringsstedIQ = newAllUdleveringsstedIQ.OrderByDescending(s => s.Person);
                    break;
                case "Person":
                    newAllUdleveringsstedIQ = newAllUdleveringsstedIQ.OrderBy(s => s.Person);
                    break;
                case "Tlf_desc":
                    newAllUdleveringsstedIQ = newAllUdleveringsstedIQ.OrderByDescending(s => s.Tlf);
                    break;
                case "Tlf":
                    newAllUdleveringsstedIQ = newAllUdleveringsstedIQ.OrderBy(s => s.Tlf);
                    break;
                case "Mail_desc":
                    newAllUdleveringsstedIQ = newAllUdleveringsstedIQ.OrderByDescending(s => s.Mail);
                    break;
                case "Mail":
                    newAllUdleveringsstedIQ = newAllUdleveringsstedIQ.OrderBy(s => s.Mail);
                    break;
                default:
                    newAllUdleveringsstedIQ = newAllUdleveringsstedIQ.OrderBy(s => s.Virksomhed);
                break;
            }
                
                NewAllUdleveringssted = await newAllUdleveringsstedIQ.AsNoTracking().ToListAsync();
        }


        
        //Export til Excel metode
        public FileResult OnPostExport()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[7] {
                new DataColumn("Virksomhed"),
                new DataColumn("Adresse"),
                new DataColumn("Postnr"),
                new DataColumn("Bynavn"),
                new DataColumn("Person"),
                new DataColumn("Tlf"),
                new DataColumn("Mail")
            });
            
            var newAllUdleveringssted = from NewAllUdleveringssted in this._Context.NewAllUdleveringssted.Take(100)
                            select NewAllUdleveringssted;

            foreach (var NewAllUdleveringssted in newAllUdleveringssted)
            {
                dt.Rows.Add( NewAllUdleveringssted.Virksomhed, NewAllUdleveringssted.Adresse, NewAllUdleveringssted.Postnr,
                    NewAllUdleveringssted.Bynavn, NewAllUdleveringssted.Person, NewAllUdleveringssted.Tlf, NewAllUdleveringssted.Mail);
            }
            
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Distributionsliste.xlsx");
                }
            }
        }
    }
}


