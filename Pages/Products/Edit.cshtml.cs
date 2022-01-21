using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hirlea_Grigore2_Proiect.Data;
using Hirlea_Grigore2_Proiect.Models;

namespace Hirlea_Grigore2_Proiect.Pages.Products
{
    public class EditModel : ProductCategoriesPageModel
    {
        private readonly Hirlea_Grigore2_Proiect.Data.Hirlea_Grigore2_ProiectContext _context;

        public EditModel(Hirlea_Grigore2_Proiect.Data.Hirlea_Grigore2_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product = await _context.Product
                .Include(b => b.Storage)
                .Include(b => b.ProductCategories).ThenInclude(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Product == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Product);
            ViewData["StorageID"] = new SelectList(_context.Set<Storage>(), "ID", "StorageName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var productToUpdate = await _context.Product
                .Include(i => i.Storage)
                .Include(i => i.ProductCategories)
                .ThenInclude(i => i.Category)
                .FirstOrDefaultAsync(s => s.ID == id);
            if (productToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Product>(
            productToUpdate,
            "Product",
            i => i.Name, i => i.Description,
            i => i.Price, i => i.ExpireDate, i => i.Storage))
            {
                UpdateProductCategories(_context, selectedCategories, productToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateProductCategories(_context, selectedCategories, productToUpdate);
            PopulateAssignedCategoryData(_context, productToUpdate);
            return Page();
        }
    }
}
