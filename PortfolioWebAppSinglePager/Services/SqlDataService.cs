using PortfolioWebAppSinglePager.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebAppSinglePager.Services
{
    public class SqlDataService
    {
        private readonly static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Database=PersonalPortfolioWebsiteDB";
        private static SqlConnection connection = new SqlConnection(connectionString);

        static string sql;


        //Projects
        public static List<Project> GetAllProjects()
        {
            List<Project> projects = new List<Project>();
            sql = "SELECT * FROM ProjectsTable";

            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    projects.Add(new Project
                    {
                        Id = (string)reader["Id"],
                        Title = (string)reader["Title"],
                        MainTechnology = (string)reader["MainTechnology"],
                        Image = reader["Image"].ToString(),
                        Thumbnail = (string)reader["Thumbnail"],
                        StartingDate = (DateTime)(reader["StartingDate"]),
                        EndingDate = Convert.ToDateTime((reader["EndingDate"])),
                        CodeLink = reader["CodeLink"].ToString(),
                        Description = (string)reader["Description"]
                    });
                }
            }

            connection.Close();
            return projects;
        }

        public static Project GetSelectedProjet(string ProjectId)
        {
            Project selectedProject = null;
            sql = $"SELECT * FROM ProjectsTable WHERE Id = '{ProjectId}';";

            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    selectedProject = new Project()
                    {
                        Id = (string)reader["Id"],
                        Title = (string)reader["Title"],
                        MainTechnology = (string)reader["MainTechnology"],
                        Image = reader["Image"].ToString(),
                        Thumbnail = (string)reader["Thumbnail"],
                        StartingDate = (DateTime)(reader["StartingDate"]),
                        EndingDate = Convert.ToDateTime((reader["EndingDate"])),
                        CodeLink = reader["CodeLink"].ToString(),
                        Description = (string)reader["Description"]
                    };
                }
            }

            connection.Close();
            return selectedProject;
        }

        public static List<string> SelectedProjectTechnologies(string ProjectId)
        {
            List<String> usedTechnologies = new List<string>();
            sql = $"SELECT Technology FROM ProjectTechTable WHERE ProjectId = '{ProjectId}';";

            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    usedTechnologies.Add((string)reader["Technology"]);
                }
            }

            connection.Close();
            return usedTechnologies;
        }

        public static List<string> SelectedProjectTasks(string ProjectId)
        {
            List<String> task = new List<string>();
            sql = $"SELECT Task FROM ProjectTaskTable WHERE ProjectId = '{ProjectId}';";

            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    task.Add((string)reader["Task"]);
                }
            }

            connection.Close();
            return task;
        }


        //Skills
        public static List<Skill> GetAllSkills()
        {
            List<Skill> skills = new List<Skill>();
            sql = "SELECT * FROM SkillsetTable";

            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    skills.Add(new Skill
                    {
                        Name = (string)reader["Skill"],
                        SkillRating = (int)(reader["SkillRating"]),
                        Category = (string)reader["Category"]
                    });
                }
            }

            connection.Close();
            return skills;
        }

        //Tools
        public static List<Tool> GetAllTools()
        {
            List<Tool> tools = new List<Tool>();
            sql = "SELECT * FROM ToolsetTable";

            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    tools.Add(new Tool
                    {
                        Name = (string)reader["Tool"],
                        ToolRating = (int)(reader["Rating"]),
                        Category = (string)reader["Category"]
                    });
                }
            }

            connection.Close();
            return tools;
        }
    }
}
