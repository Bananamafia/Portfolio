using PortfolioWebAppSinglePager.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebAppSinglePager.Services
{
    public class SqlDataProvider
    {
        private static string connectionString = Startup.StaticConfig.GetConnectionString("DefaultConnection");
        static SqlConnection connection = new SqlConnection(connectionString);

        public static List<Project> BestProjectList()
        {
            List<Project> projects = new List<Project>();
            string sql = "SELECT * FROM ProjectsTable";

            connection.Open();


            SqlCommand command = new SqlCommand(sql, connection);


            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
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
            }

            connection.Close();

            return projects;
        }
    }
}
