using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sample.Data.Context;
using Sample.Data.Models;

namespace Sample.Pages.Blogs
{
    public class DetailsModel : PageModel
    {
        private readonly Sample.Data.Context.SampleContext _context;

        public DetailsModel(Sample.Data.Context.SampleContext context)
        {
            _context = context;
        }

      public Blog Blog { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Blogs == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs.FirstOrDefaultAsync(m => m.BlogId == id);
            if (blog == null)
            {
                return NotFound();
            }
            else 
            {
                Blog = blog;
            }
            return Page();
        }
    }
}
