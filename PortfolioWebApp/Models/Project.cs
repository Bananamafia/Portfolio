using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PortfolioWebApp.Models
{
    public class Project
    {
        public string Id { get; set; } = null;
        public string Title { get; set; } = "Sample Project";
        public string ShortTitle { get; set; } = "Sample Project";
        public string MainTechnology { get; set; } = "Sonstiges";

        public string Image { get; set; } = "/Images/SampleImage.png";
        public string Thumbnail { get; set; } = "/Images/Thumbnails/SampleImage.png";

        public DateTime StartingDate { get; set; } = new DateTime(1995, 12, 15);
        public DateTime EndingDate { get; set; } = DateTime.Now;

        public string Description { get; set; } = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.";
        public string CodeLink { get; set; } = null;
        public string[] UsedTools { get; set; }

    }
}
