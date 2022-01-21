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
    public class DetailsModel : PageModel
    {
        private readonly Hirlea_Grigore2_Proiect.Data.Hirlea_Grigore2_ProiectContext _context;

        public DetailsModel(Hirlea_Grigore2_Proiect.Data.Hirlea_Grigore2_ProiectContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product.FirstOrDefaultAsync(m => m.ID == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
