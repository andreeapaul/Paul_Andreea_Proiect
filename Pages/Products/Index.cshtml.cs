using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Paul_Andreea_Proiect.Data;
using Paul_Andreea_Proiect.Models;

namespace Paul_Andreea_Proiect.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly Paul_Andreea_Proiect.Data.Paul_Andreea_ProiectContext _context;

        public IndexModel(Paul_Andreea_Proiect.Data.Paul_Andreea_ProiectContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get; set; }
        public ProductData ProductD { get; set; }
        public int ProductID { get; set;}
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            ProductD = new ProductData();

            ProductD.Products = await _context.Product
            .Include(b => b.Seller)
            .Include(b => b.ProductCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .ToListAsync();
            if (id != null)
            {
                ProductID = id.Value;
                Product product = ProductD.Products
                .Where(i => i.ID == id.Value).Single();
                ProductD.Categories = product.ProductCategories.Select(s => s.Category);
            }
        }
    }
}
