using Microsoft.Extensions.Configuration;
using PortfolioWebAppSinglePager.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PortfolioWebAppSinglePager.Services
{
    public class SqlDataService
    {
        private readonly static string connectionString = Startup.StaticConfig.GetConnectionString("DefaultConnection");
        private static SqlConnection connection = new SqlConnection(connectionString);

        static string sql;


        //Projects
        public static List<Project> GetAllProjects()
        {
            List<Project> projects = new List<Project>();
            sql = "SELECT * FROM ProjectsTable ORDER BY StartingDate DESC, Title";

            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    try
                    {
                        projects.Add(new Project
                        {
                            Id = (string)reader["ProjectId"],
                            Title = (string)reader["Title"],
                            MainTechnology = (string)reader["MainTechnology"],
                            IsInProgress = (bool)reader["IsInProgress"],
                            Image = reader["ImagePath"].ToString(),
                            Thumbnail = (string)reader["ThumbnailPath"],
                            StartingDate = (DateTime)(reader["StartingDate"]),
                            EndingDate = Convert.ToDateTime((reader["EndingDate"])),
                            CodeLink = reader["CodeLink"].ToString(),
                            Description = (string)reader["Description"]
                        });
                    }
                    catch
                    {
                        projects.Add(new Project
                        {
                            Id = (string)reader["ProjectId"],
                            Title = (string)reader["Title"],
                            MainTechnology = (string)reader["MainTechnology"],
                            IsInProgress = (bool)reader["IsInProgress"],
                            Image = reader["ImagePath"].ToString(),
                            Thumbnail = (string)reader["ThumbnailPath"],
                            StartingDate = (DateTime)(reader["StartingDate"]),
                            CodeLink = reader["CodeLink"].ToString(),
                            Description = (string)reader["Description"]
                        });
                    }
                }
            }

            connection.Close();
            return projects;
        }

        public static Project GetSelectedProjet(string ProjectId)
        {
            Project selectedProject = null;
            sql = $"SELECT * FROM ProjectsTable WHERE ProjectId = '{ProjectId}';";

            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    selectedProject = new Project()
                    {
                        Id = (string)reader["ProjectId"],
                        Title = (string)reader["Title"],
                        MainTechnology = (string)reader["MainTechnology"],
                        IsInProgress = (bool)reader["IsInProgress"],
                        Image = reader["ImagePath"].ToString(),
                        Thumbnail = (string)reader["ThumbnailPath"],
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
            sql = $"SELECT Tool FROM ProjectToolTable WHERE ProjectId = '{ProjectId}';";

            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    usedTechnologies.Add((string)reader["Tool"]);
                }
            }

            connection.Close();
            return usedTechnologies;
        }

        public static List<string> SelectedProjectTasks(string ProjectId)
        {
            List<String> task = new List<string>();
            sql = $"SELECT TaskDescription FROM ProjectTasksTable WHERE ProjectId = '{ProjectId}';";

            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    task.Add((string)reader["TaskDescription"]);
                }
            }

            connection.Close();
            return task;
        }

        //Tools
        public static List<Tool> GetAllTools()
        {
            List<Tool> tools = new List<Tool>();
            sql = "SELECT * FROM ToolsTable ORDER BY Rating DESC, Tool";

            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    tools.Add(new Tool
                    {
                        Name = (string)reader["Tool"],
                        ToolRating = (int)reader["Rating"],
                        Category = (string)reader["Category"]
                    });
                }
            }

            connection.Close();
            return tools;
        }

        public static void AddTool(Tool tool)
        {
            sql = $"INSERT INTO ToolsTable (Tool, Rating, Category) VALUES ('{tool.Name}', '{tool.ToolRating}', '{tool.Category}')";
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void DeleteTool(string tool)
        {
            sql = $"DELETE FROM ToolsTable WHERE Tool = {tool}";
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
