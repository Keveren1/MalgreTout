using MalgreTout.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MalgreTout.Pages
{
    public class DeleteModel : PageModel
    {
        Malgretout_DataContext _Context;
        private readonly ILogger<DeleteModel> _logger;
        
        public DeleteModel(Malgretout_DataContext Malgretout_databasecontext, ILogger<DeleteModel> logger)
        {
            _Context = Malgretout_databasecontext;
            _logger = logger;
        }

        [BindProperty]
        public NewAllUdleveringssted NewAllUdleveringssted { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            NewAllUdleveringssted = await _Context.NewAllUdleveringssted
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (NewAllUdleveringssted == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("Delete {ID} failed. Try again", id);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var NewAllUdleveringssted = await _Context.NewAllUdleveringssted.FindAsync(id);

            if (NewAllUdleveringssted == null)
            {
                return NotFound();
            }

            try
            {
                _Context.Remove(NewAllUdleveringssted);
                await _Context.SaveChangesAsync();
                return RedirectToPage("./ViewAll");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, ErrorMessage);

                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }
        }
    }
}