using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebApp.Models
{
    public class Tool
    {
        public string Name { get; set; }

        [Range(1, 10)]
        public int SkillRating { get; set; }
        public string Category { get; set; }
    }
}
