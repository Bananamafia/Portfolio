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
    public class OverviewModel : PageModel
    {
        public OverviewModel(ILogger<OverviewModel> logger, JsonFileProjectService projectService)
        {
            _logger = logger;
            ProjectService = projectService;
        }

        private readonly ILogger<OverviewModel> _logger;
        public JsonFileProjectService ProjectService;
        public IEnumerable<Project> AllProjects { get; private set; }

        public List<Project> ProjectList { get; private set; }

        public HashSet<string> ProjectTopics { get; private set; } = new HashSet<string>();



        public void OnGet()
        {
            //AllProjects = ProjectService.GetProjects();
            SqlProjectDataService sqlProjectDataService = new SqlProjectDataService();
            ProjectList = sqlProjectDataService.allProjects(); //AllProjects.ToList();

            ProjectList.Sort((x, y) => DateTime.Compare(y.StartingDate, x.StartingDate));           

        }
    }
}