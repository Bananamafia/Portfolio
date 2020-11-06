using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebAppSinglePager.Models
{
    public class Tool
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ToolRating { get; set; }
        public string Category { get; set; }
    }
}
