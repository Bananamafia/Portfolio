using PortfolioWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebApp.Services
{
    public class SqlProjectDataService
    {
        List<Project> selectedProjects = new List<Project>();

        static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Database=PersonalPortfolioWebsiteDB";
        SqlConnection connection = new SqlConnection(connectionString);
        string sql;


        public List<Project> AllProjects()
        {
            List<Project> allProjects = new List<Project>();
            sql = "SELECT * FROM ProjectsTable";

            connection.Open();

            SqlCommand command = new SqlCommand(sql, connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    allProjects.Add(new Project
                    {
                        Id = reader["Id"].ToString(),
                        Title = reader["Title"].ToString(),
                        MainTechnology = reader["MainTechnology"].ToString(),
                        Image = reader["Image"].ToString(),
                        Thumbnail = reader["Thumbnail"].ToString(),
                        StartingDate = System.Convert.ToDateTime(reader["StartingDate"]),
                        EndingDate = System.Convert.ToDateTime(reader["EndingDate"]),
                        CodeLink = reader["CodeLink"].ToString(),
                        Description = reader["Description"].ToString()
                    });
                }
            }

            connection.Close();
            return allProjects;
        }

        public Project SelectedProject(string ProjectId)
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
                        Id = reader["Id"].ToString(),
                        Title = reader["Title"].ToString(),
                        MainTechnology = reader["MainTechnology"].ToString(),
                        Image = reader["Image"].ToString(),
                        Thumbnail = reader["Thumbnail"].ToString(),
                        StartingDate = System.Convert.ToDateTime(reader["StartingDate"]),
                        EndingDate = System.Convert.ToDateTime(reader["EndingDate"]),
                        CodeLink = reader["CodeLink"].ToString(),
                        Description = reader["Description"].ToString()
                    };
                }
            }

            connection.Close();


            return selectedProject;
        }

        public List<string> UsedTechnologies(string ProjectId)
        {
            List<String> usedTechnologies = new List<string>();
            sql = $"SELECT Technology FROM ProjectTechTable WHERE ProjectId = '{ProjectId}';";

            connection.Open();

            SqlCommand command = new SqlCommand(sql, connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    usedTechnologies.Add(reader["Technology"].ToString());
                }
            }


            connection.Close();
            return usedTechnologies;
        }

        public List<string> ProjectTasks(string ProjectId)
        {
            List<String> task = new List<string>();
            sql = $"SELECT Task FROM ProjectTaskTable WHERE ProjectId = '{ProjectId}';";

            connection.Open();

            SqlCommand command = new SqlCommand(sql, connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    task.Add(reader["Task"].ToString());
                }
            }


            connection.Close();
            return task;
        }





    }
}
