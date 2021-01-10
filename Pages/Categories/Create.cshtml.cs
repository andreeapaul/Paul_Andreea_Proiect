using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Paul_Andreea_Proiect.Data;
using Paul_Andreea_Proiect.Models;

namespace Paul_Andreea_Proiect.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly Paul_Andreea_Proiect.Data.Paul_Andreea_ProiectContext _context;

        public CreateModel(Paul_Andreea_Proiect.Data.Paul_Andreea_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Category.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
