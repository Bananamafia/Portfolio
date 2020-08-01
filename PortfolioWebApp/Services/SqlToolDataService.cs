using PortfolioWebApp.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebApp.Services
{
    public class SqlToolDataService
    {
        List<Tool> allTools = new List<Tool>();

        static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Database=PersonalPortfolioWebsiteDB";
        SqlConnection connection = new SqlConnection(connectionString);
        string sql;


        public List<Tool> AllTools()
        {
            sql = "SELECT * FROM ToolsetTable";
            
            connection.Open();

            SqlCommand command = new SqlCommand(sql, connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    allTools.Add(new Tool { 
                        Name = reader["Tool"].ToString(), 
                        SkillRating = Convert.ToInt32(reader["SkillRating"]), 
                        Category = reader["Category"].ToString() 
                    });
                }
            }


            connection.Close();
            return allTools;
        }
    }
}
