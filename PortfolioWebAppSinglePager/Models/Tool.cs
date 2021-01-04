using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebAppSinglePager.Models
{
    public class Tool
    {
        [Column("Tool")]
        public string Name { get; set; }

        public int Rating { get; set; }
        public string Category { get; set; }
    }
}
