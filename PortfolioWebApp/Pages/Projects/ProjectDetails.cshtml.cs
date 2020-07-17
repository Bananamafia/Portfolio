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

        [BindProperty(SupportsGet =true)]
        public string Id { get; set; }


        public Project selectedProject;

        public void OnGet()
        {
            AllProjects = ProjectService.GetProjects();
            List<Project> projects = AllProjects.ToList();
            
            selectedProject = projects.Find(x => x.Id == Id);


            if (selectedProject == null)
            {
                selectedProject = new Project() { Title = "Sample Project", Description = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.", StartingDate = new DateTime(1995, 12, 15), EndingDate = DateTime.Now, UsedTools = new string[] { "C#", "WPF", "Git" } };
            }
            else
            {
                return;
            }
        }
    }
}