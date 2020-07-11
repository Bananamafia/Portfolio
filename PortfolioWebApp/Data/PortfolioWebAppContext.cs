using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortfolioWebApp.Models;

namespace PortfolioWebApp.Data
{
    public class PortfolioWebAppContext : DbContext
    {
        public PortfolioWebAppContext (DbContextOptions<PortfolioWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<PortfolioWebApp.Models.Project> Project { get; set; }
    }
}
