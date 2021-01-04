using Microsoft.Extensions.Configuration;
using PortfolioWebAppSinglePager.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;

namespace PortfolioWebAppSinglePager.Services
{
    public class SqlDataService
    {
        private readonly static string connectionString = Startup.StaticConfig.GetConnectionString("DefaultConnection");

        //Projects
        public static List<Project> GetAllProjects()
        {
            string sql = "SELECT * FROM ProjectsTable ORDER BY StartingDate DESC, Title";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Project>(sql).ToList();
            }
        }

        public static Project GetSelectedProjet(string ProjectId)
        {
            string sql = $"SELECT * FROM ProjectsTable WHERE ProjectId = '{ProjectId}';";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Project>(sql).Single();
            }
        }

        public static List<string> SelectedProjectTechnologies(string ProjectId)
        {
            string sql = $"SELECT Tool FROM ProjectToolTable WHERE ProjectId = '{ProjectId}';";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<string>(sql).ToList();
            }
        }

        public static List<string> SelectedProjectTasks(string ProjectId)
        {
            string sql = $"SELECT TaskDescription FROM ProjectTasksTable WHERE ProjectId = '{ProjectId}';";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<string>(sql).ToList();
            }
        }

        //Tools
        public static List<Tool> GetAllTools()
        {
            string sql = "SELECT Rating, Category, Tool AS Name FROM ToolsTable ORDER BY Rating DESC, Tool";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Tool>(sql).ToList();
            }
        }

        public static void AddTool(Tool tool)
        {
            string sql = $"INSERT INTO ToolsTable (Tool, Rating, Category) VALUES ('{tool.Name}', '{tool.Rating}', '{tool.Category}')";
            using (SqlConnection connection = new SqlConnection())
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }
        }

        public static void DeleteTool(string tool)
        {
            string sql = $"DELETE FROM ToolsTable WHERE Tool = {tool}";
            using (SqlConnection connection = new SqlConnection())
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
