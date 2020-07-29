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


        public List<Project> allProjects()
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









    }
}
