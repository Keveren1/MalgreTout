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

    }
}
