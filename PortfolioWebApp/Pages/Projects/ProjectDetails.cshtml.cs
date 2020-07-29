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
    public class ProjectDetailsModel : PageModel
    {
        public ProjectDetailsModel(ILogger<OverviewModel> logger, JsonFileProjectService projectService)
        {
            _logger = logger;
            ProjectService = projectService;
        }

        private readonly ILogger<OverviewModel> _logger;
        public JsonFileProjectService ProjectService;
        public IEnumerable<Project> AllProjects { get; private set; }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }


        public Project selectedProject;
        public List<String> usedTechnologies;
        public List<String> tasks;

        public void OnGet()
        {
            SqlProjectDataService sqlProjectDataService = new SqlProjectDataService();

            selectedProject = sqlProjectDataService.SelectedProject(Id);
            usedTechnologies = sqlProjectDataService.UsedTechnologies(Id);
            tasks = sqlProjectDataService.ProjectTasks(Id);


            //AllProjects = ProjectService.GetProjects();
            //List<Project> projects = AllProjects.ToList();

            //selectedProject = projects.Find(x => x.Id == Id);

        }
    }
}