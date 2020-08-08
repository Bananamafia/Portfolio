using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebAppSinglePager.Models
{
    public class Skill
    {
        public string Name { get; set; }

        [Range(1, 5)]
        public int SkillRating { get; set; }
        public string Category { get; set; }
    }
}
