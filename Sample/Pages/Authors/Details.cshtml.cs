using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sample.Data.Context;
using Sample.Data.Models;

namespace Sample.Pages.Authors
{
    public class DetailsModel : PageModel
    {
        private readonly Sample.Data.Context.SampleContext _context;

        public DetailsModel(Sample.Data.Context.SampleContext context)
        {
            _context = context;
        }

      public Author Author { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var author = await _context.Authors
                .Include(b=>b.Blogs)
                    .ThenInclude(p=>p.Posts)
                .FirstOrDefaultAsync(m => m.AuthorId == id);
            if (author == null)
            {
                return NotFound();
            }
            else 
            {
                Author = author;
            }
            return Page();
        }
    }
}
