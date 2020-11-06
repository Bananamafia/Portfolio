using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortfolioWebAppSinglePager.Models;

namespace PortfolioWebAppSinglePager.Pages.Admin
{
    public class SkillSetModel : PageModel
    {
        public List<Tool> MyTools { get; set; }

        public void OnGet()
        {
            MyTools = Services.ToolDataService.AllTools().OrderBy(o => o.Category).ToList();
        }

        public void OnPostDeleteSkill()
        {

        }
    }
}
