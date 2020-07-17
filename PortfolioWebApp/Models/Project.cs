using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebApp.Models
{
    public class Project
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public string Description { get; set; }
        public string[] UsedTools { get; set; }


    }
}
