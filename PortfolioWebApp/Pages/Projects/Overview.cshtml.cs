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
        public OverviewModel(ILogger<OverviewModel> logger)
        {
            _logger = logger;
        }

        private readonly ILogger<OverviewModel> _logger;

        public SqlProjectDataService ProjectService = new SqlProjectDataService();

        public List<Project> ProjectList { get; private set; }


        public void OnGet()
        {
            ProjectList = ProjectService.AllProjects();

            ProjectList.Sort((x, y) => DateTime.Compare(y.StartingDate, x.StartingDate));
        }
    }
}