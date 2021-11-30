using Microsoft.AspNetCore.Mvc.RazorPages;
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
    public class Delete : PageModel
    {
        
        //Dependency Injection
        Malgretout_DataContext _Context;
        public Delete(Malgretout_DataContext Malgretout_databasecontext)
        {
            _Context = Malgretout_databasecontext;
        }
        
        [BindProperty]
        public Kontaktperson Kontaktperson { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? Id, bool? saveChangesError = false)
        {
            if (Id == null)
            {
                return NotFound();
            }

            Kontaktperson = await _Context.Kontaktperson
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == Id);

            if (Kontaktperson == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("Delete {Id} failed. Try again", Id);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var student = await _Context.Kontaktperson.FindAsync(Id);

            if (student == null)
            {
                return NotFound();
            }

            try
            {
                _Context.Kontaktperson.Remove(student);
                await _Context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException ex)
            {
               

                return RedirectToAction("./Delete",
                    new { Id, saveChangesError = true });
            }
        }
    }
}