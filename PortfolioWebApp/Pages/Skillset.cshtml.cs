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
    public class SkillsetModel : PageModel
    {

        public List<Skill> MySkills;
        public SortedSet<string> SkillCategories;

        public void OnGet()
        {
            SqlSkillDataService sqlToolDataService = new SqlSkillDataService();
            MySkills = sqlToolDataService.GetAllTools();


            MySkills = MySkills.OrderByDescending(o => o.SkillRating).ToList();

            SkillCategories = new SortedSet<string>();

            foreach (var tool in MySkills)
            {
                SkillCategories.Add(tool.Category);
            }

        }
    }
}