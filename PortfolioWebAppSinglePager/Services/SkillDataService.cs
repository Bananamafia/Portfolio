using PortfolioWebAppSinglePager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebAppSinglePager.Services
{
    public class SkillDataService
    {
        public static List<Skill> AllSkills()
        {
            return SqlDataService.GetAllSkills().OrderByDescending(o => o.SkillRating).ToList();
        }

        public static SortedSet<string> SkillCategories()
        {
            SortedSet<string> categories = new SortedSet<string>();

            foreach (var skill in AllSkills())
            {
                categories.Add(skill.Category);
            }

            return categories;
        }
    }
}
