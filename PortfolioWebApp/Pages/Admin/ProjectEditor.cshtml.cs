using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PortfolioWebApp.Models;
using PortfolioWebApp.Services;

namespace PortfolioWebApp.Pages.Projects
{
    public class ProjectEditor : PageModel
    {
        public ProjectEditor(ILogger<OverviewModel> logger)
        {
            _logger = logger;
        }

        private readonly ILogger<OverviewModel> _logger;

        SqlProjectDataService ProjectService = new SqlProjectDataService();

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }


        public Project selectedProject;
        public List<String> usedTechnologies;
        public List<String> tasks;

        public void OnGet()
        {
            selectedProject = ProjectService.SelectedProject(Id);
            usedTechnologies = ProjectService.UsedTechnologies(Id);
            tasks = ProjectService.ProjectTasks(Id);
        }
    }
}