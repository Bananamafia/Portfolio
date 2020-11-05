using System;
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
    public class ProjectDetailsModel : PageModel
    {
        public ProjectDetailsModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        private readonly ILogger<IndexModel> _logger;

        [BindProperty(SupportsGet = true)]
        public string ProjectId { get; set; }


        public Project selectedProject;
        public List<String> usedTechnologies;
        public List<String> tasks;

        public void OnGet()
        {
            selectedProject = ProjectDataService.GetSelectedProjet(ProjectId);
            usedTechnologies = ProjectDataService.SelectedProjectTechnologies(ProjectId);
            tasks = ProjectDataService.SelectedProjectTasks(ProjectId);
        }
    }
}