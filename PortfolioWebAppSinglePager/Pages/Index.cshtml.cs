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
        public List<Skill> MySkills { get; set; } = SkillDataService.AllSkills();
        public SortedSet<string> SkillCategories { get; set; } = SkillDataService.SkillCategories();

        public List<Tool> MyTools { get; set; } = ToolDataService.AllTools();


        //ProjectOverview
        public List<Project> MyProjects { get; set; } = ProjectDataService.AllProjects();



        public void OnGet()
        {

        }
    }
}
