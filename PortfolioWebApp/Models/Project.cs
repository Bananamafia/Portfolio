﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PortfolioWebApp.Models
{
    public class Project
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string MainTechnology { get; set; }

        public string Image { get; set; }
        public string Thumbnail { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartingDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndingDate { get; set; }

        public string Description { get; set; }
        public string[] Functions { get; set; }

        [DataType(DataType.Url)]
        public string CodeLink { get; set; }
        public string[] UsedTools { get; set; }


    }
}
