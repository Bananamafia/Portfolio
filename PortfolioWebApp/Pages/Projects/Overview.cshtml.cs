using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PortfolioWebApp.Models;
using PortfolioWebApp.Services;

namespace PortfolioWebApp.Pages.Projects
{
    public class OverviewModel : PageModel
    {
        public OverviewModel(ILogger<OverviewModel> logger, JsonFileProjectService projectService)
        {
            _logger = logger;
            ProjectService = projectService;
        }

        private readonly ILogger<OverviewModel> _logger;
        public JsonFileProjectService ProjectService;
        public IEnumerable<Project> AllProjects { get; private set; }

        public List<Project> ProjectList { get; private set; }

        public HashSet<string> ProjectTopics { get; private set; } = new HashSet<string>();


        //public void AddSampleData()
        //{
        //    AllProjects.Add(new Project { ID = 4, Title = "fdgsdfgsfgh", Description = "Kleinere Konsolenanwendungen, die dazu dienten, mathematische Probleme auf ProjectEuler.com zu lösen.", UsedTools = new string[] { "C#" } });
        //    AllProjects.Add(new Project { ID = 5, Title = "dhgfdgherzertzu", Description = "Kleinere Konsolenanwendungen, die dazu dienten, mathematische Probleme auregheöfgggggggggggggmn ggggggggggggggggggggggggweorhgeöorhgeorghöweorg kerljmgfhwerchtoiwertghiwoerkhtmgiwueori ktgmbweurighmweuriuigchmwbeuzriulgickhwmeb riugcilwehrogiucoiwlerhmgohi uocwerhgbciwuerlighwoirltgjhwoutiguvhwutigov iwjrtpguvwoeirtöjgpwielighmwrohötoghijwnrm oiguiwejhrtgiowierjhgpowierhmgpwoeöirughpweorugomwiuer tpowertgpowertgoviwmehpgoiwerhgipuowehrpgiuwehguwi werthowerhgpovuwehrpguwherpgohweprighwiuehrguiwherogihweüoijf ProjectEuler.com zu lösen.", UsedTools = new string[] { "C#" } });
        //    AllProjects.Add(new Project { ID = 6, Title = "Konsolenanwendungen", Description = "Kleinere Konsolena.", UsedTools = new string[] { "C#" } });
        //    AllProjects.Add(new Project { ID = 7, Title = "Konsolenanwendungen", Description = "Kleinere Konsoroehgwer efoghew ef9ehf eüfoighepigjwe e0ofghrüoightEuler.com zu lösen.", UsedTools = new string[] { "C#" } });
        //    AllProjects.Add(new Project { ID = 8, Title = "Konsolenanwendungen", Description = "Kleinere Konsolenanwendungen, die dazu dienten, mathematische Probleme auf ProjectEuler.com zu lösen.", UsedTools = new string[] { "C#" } });
        //    AllProjects.Add(new Project { ID = 9, Title = "Konsolenanwendungen", Description = "Kleinere Konsolenanwendungen, die dProbleme auf ProjectEuler.com zu lösen.", UsedTools = new string[] { "C#" } });

        //}

        public void OnGet()
        {
            AllProjects = ProjectService.GetProjects();
            ProjectList = AllProjects.ToList();

            ProjectList.Sort((x, y) => DateTime.Compare(y.StartingDate, x.StartingDate));


            foreach (var project in ProjectList)
            {
                ProjectTopics.Add(project.Topic);
            }
        }
    }
}