using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortfolioWebApp.Models;

namespace PortfolioWebApp.Pages
{
    public class ProjektübersichtModel : PageModel
    {
        public List<Project> AllProjects = new List<Project>();

        public void AddSeedProjects()
        {
            AllProjects.Add(new Project { Title = "Conway's Game of Life", Description = "Simulation eines Zellpopulationsprozesses nach den Regeln von Conways Spiel des Lebens.", StartingDate = new DateTime(2020, 06, 01), EndingDate = new DateTime(2020, 07, 01), UsedTools = new string[] { "C#", "WPF", "Git" } });
            AllProjects.Add(new Project { Title = "Digital Contact Manager", Description = "Digitales Adressbuch mit der Funktion Kontakte zu erstellen, bearbeiten, löschen und zu filtern.", UsedTools = new string[] { "C#", "WPF" } });
            AllProjects.Add(new Project { Title = "Konsolenanwendungen", Description = "Kleinere Konsolenanwendungen, die dazu dienten, mathematische Probleme auf ProjectEuler.com zu lösen.", UsedTools = new string[] { "C#" } });
        }


        //public Project AnotherProject = new Project() { Title = "nur ein kleines Beispiel" };


        public void OnGet()
        {
            AddSeedProjects();


        }
    }
}