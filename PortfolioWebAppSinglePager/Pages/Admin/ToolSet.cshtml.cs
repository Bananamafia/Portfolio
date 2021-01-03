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

        [BindProperty]
        public Tool MyTool { get; set; }

        private void RefreshTools()
        {
            MyTools = Services.ToolDataService.AllTools().OrderBy(o => o.Category).ToList();

        }

        public void OnGet()
        {
            RefreshTools();
        }

        public void OnPostAddNewTool()
        {
            Services.SqlDataService.AddTool(MyTool);
            RefreshTools(); 
        }

        public void OnPostDeleteTool()
        {
            Services.SqlDataService.DeleteTool(MyTool.Name);
            RefreshTools();
        }
    }
}
