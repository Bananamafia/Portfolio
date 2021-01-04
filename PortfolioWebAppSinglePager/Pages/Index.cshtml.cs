using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PortfolioWebAppSinglePager.Models;
using PortfolioWebAppSinglePager.Services;

namespace PortfolioWebAppSinglePager.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        
        //Skillset
        public List<Tool> MyTools { get; set; } = SqlDataService.GetAllTools();


        //ProjectOverview
        public List<Project> MyProjects { get; set; } = SqlDataService.GetAllProjects();



        public void OnGet()
        {
            
        }
    }
}
