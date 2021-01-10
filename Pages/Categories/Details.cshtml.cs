using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Paul_Andreea_Proiect.Data;
using Paul_Andreea_Proiect.Models;

namespace Paul_Andreea_Proiect.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly Paul_Andreea_Proiect.Data.Paul_Andreea_ProiectContext _context;

        public DetailsModel(Paul_Andreea_Proiect.Data.Paul_Andreea_ProiectContext context)
        {
            _context = context;
        }

        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
