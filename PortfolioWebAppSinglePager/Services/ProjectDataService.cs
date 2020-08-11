using PortfolioWebAppSinglePager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebAppSinglePager.Services
{
    public class ProjectDataService : SqlDataService
    {
        public static List<Project> AllProjects()
        {
            List<Project> projects = SqlDataService.GetAllProjects();

            projects.Sort((x, y) => DateTime.Compare(y.StartingDate, x.StartingDate));

            return projects;
        }
    }
}
