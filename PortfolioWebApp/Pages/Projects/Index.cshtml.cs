using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PortfolioWebApp.Data;
using PortfolioWebApp.Models;

namespace PortfolioWebApp.Pages.Projects
{
    public class IndexModel : PageModel
    {
        private readonly PortfolioWebApp.Data.PortfolioWebAppContext _context;

        public IndexModel(PortfolioWebApp.Data.PortfolioWebAppContext context)
        {
            _context = context;
        }

        public IList<Project> Project { get;set; }

        public async Task OnGetAsync()
        {
            Project = await _context.Project.ToListAsync();
        }
    }
}
