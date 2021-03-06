﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebAppSinglePager.Models
{
    public class Project
    {
        public string ProjectId { get; set; }
        public string Title { get; set; }
        public string MainTechnology { get; set; }

        public bool IsInProgress { get; set; }
        public bool IsNew
        {
            get { return DateTime.Today - EndingDate <= new TimeSpan(50, 0, 0, 0); }
        }

        public string ImagePath { get; set; }
        public string ThumbnailPath { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartingDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndingDate { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Url)]
        public string CodeLink { get; set; }
    }
}
