using Microsoft.AspNetCore.Hosting;
using PortfolioWebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PortfolioWebApp.Services
{
    public class JsonFileProjectService
    {
        public JsonFileProjectService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "projects.json"); }
        }

        public IEnumerable<Project> GetProjects()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Project[]>(jsonFileReader.ReadToEnd(), new JsonSerializerOptions { });
            }
        }
    }
}
