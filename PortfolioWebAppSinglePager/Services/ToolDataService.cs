using PortfolioWebAppSinglePager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebAppSinglePager.Services
{
    public class ToolDataService
    {
        public static List<Tool> AllTools()
        {
            return SqlDataService.GetAllTools().OrderByDescending(o => o.ToolRating).ToList();
        }
    }
}
