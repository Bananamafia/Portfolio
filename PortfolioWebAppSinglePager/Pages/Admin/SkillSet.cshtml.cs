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
        public List<Skill> MySkills { get; set; }



        public void OnGet()
        {
            MySkills = Services.SkillDataService.AllSkills().OrderBy(o => o.Category).ToList();
        }
    }
}
