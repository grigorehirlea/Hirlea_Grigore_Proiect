using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hirlea_Grigore2_Proiect.Data;
using Hirlea_Grigore2_Proiect.Models;

namespace Hirlea_Grigore2_Proiect.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly Hirlea_Grigore2_Proiect.Data.Hirlea_Grigore2_ProiectContext _context;

        public IndexModel(Hirlea_Grigore2_Proiect.Data.Hirlea_Grigore2_ProiectContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }
        public ProductData ProductD { get; set; }
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            ProductD = new ProductData();

            ProductD.Products = await _context.Product
                .Include(b => b.Storage)
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

     //   public async Task OnGetAsync()
      //  {
       //     Product = await _context.Product
        //        .Include(b => b.Storage)
         //       .ToListAsync();
        //}
    }
}
