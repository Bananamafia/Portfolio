using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortfolioWebApp.Models;
using PortfolioWebApp.Services;

namespace PortfolioWebApp.Pages
{
    public class ToolsetModel : PageModel
    {

        public List<Tool> MyTools;
        public HashSet<string> ToolCategories;

    public void OnGet()
        {
            SqlToolDataService sqlToolDataService = new SqlToolDataService();
            MyTools = sqlToolDataService.GetAllTools();

            ToolCategories = new HashSet<string>();

            foreach (var tool in MyTools)
            {
                ToolCategories.Add(tool.Category);
            }
        }
    }
}