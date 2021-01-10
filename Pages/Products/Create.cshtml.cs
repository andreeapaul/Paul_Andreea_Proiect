using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Paul_Andreea_Proiect.Data;
using Paul_Andreea_Proiect.Models;


namespace Paul_Andreea_Proiect.Pages.Products
{
    public class CreateModel : ProductCategoriesPageModel
    {
        private readonly Paul_Andreea_Proiect.Data.Paul_Andreea_ProiectContext _context;
        public CreateModel(Paul_Andreea_Proiect.Data.Paul_Andreea_ProiectContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            ViewData["SellerID"] = new SelectList(_context.Seller, "ID", "SellerName");

            var product = new Product();
            product.ProductCategories = new List<ProductCategory>();
            PopulateAssignedCategoryData(_context, product);
            return Page();
        }
        [BindProperty]
        public Product Product { get; set; }
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newProduct = new Product();
            if (selectedCategories != null)
            {
                newProduct.ProductCategories = new List<ProductCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new ProductCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newProduct.ProductCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Product>(
            newProduct,
            "Product",
            i => i.Name,
            i => i.Color,
            i => i.Price,
            i => i.Brand, 
            i => i.ReleaseDate,
            i => i.SellerID,
            i => i.Size))
            {
                _context.Product.Add(newProduct);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newProduct);
            return Page();
        }
    }
}
