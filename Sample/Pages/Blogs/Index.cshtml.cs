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
    public class IndexModel : PageModel
    {
        private readonly Sample.Data.Context.SampleContext _context;

        public IndexModel(Sample.Data.Context.SampleContext context)
        {
            _context = context;
        }

        public IList<Blog> Blog { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Blogs != null)
            {
                Blog = await _context.Blogs
                .Include(b => b.Author).ToListAsync();
            }
        }
    }
}
