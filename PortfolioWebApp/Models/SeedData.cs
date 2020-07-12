using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PortfolioWebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PortfolioWebAppContext(serviceProvider.GetRequiredService<DbContextOptions<PortfolioWebAppContext>>()))
            {
                if (context.Project.Any())
                {
                    return;
                }
                else
                {
                    context.Project.AddRange(
                        new Project
                        {
                            Title = "Conway's Game of Life",
                            StartDate = DateTime.Parse("2020-06-01"),
                            EndDate = DateTime.Parse("2020-07-01"),
                            Description = "Created a simulation of population of cells with the rules of 'Conway's Game of Life'"
                        },

                        new Project
                        {
                            Title = "Digital Contact Book",
                            StartDate = DateTime.Parse("2020-04-01"),
                            EndDate = DateTime.Parse("2020-05-01"),
                            Description = "Created a contact Book in WPF, which can add, cdit, celete and filter contacts."
                        });

                    context.SaveChanges();
                }
            }
        }
    }
}
