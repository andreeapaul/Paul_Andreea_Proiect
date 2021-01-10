using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Paul_Andreea_Proiect.Data;
using Paul_Andreea_Proiect.Models;

namespace Paul_Andreea_Proiect.Pages.Sellers
{
    public class IndexModel : PageModel
    {
        private readonly Paul_Andreea_Proiect.Data.Paul_Andreea_ProiectContext _context;

        public IndexModel(Paul_Andreea_Proiect.Data.Paul_Andreea_ProiectContext context)
        {
            _context = context;
        }

        public IList<Seller> Seller { get;set; }

        public async Task OnGetAsync()
        {
            Seller = await _context.Seller.ToListAsync();
        }
    }
}
