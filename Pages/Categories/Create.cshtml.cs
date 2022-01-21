using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hirlea_Grigore2_Proiect.Data;
using Hirlea_Grigore2_Proiect.Models;

namespace Hirlea_Grigore2_Proiect.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly Hirlea_Grigore2_Proiect.Data.Hirlea_Grigore2_ProiectContext _context;

        public CreateModel(Hirlea_Grigore2_Proiect.Data.Hirlea_Grigore2_ProiectContext context)
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
