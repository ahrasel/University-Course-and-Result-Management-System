using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystem.Models.EntityModel;

namespace UniversityManagementSystem.DAL
{
    public class SemesterGatewaye
    {
        private string connectionstring = WebConfigurationManager.ConnectionStrings["UniManagement"].ConnectionString;
        public List<Semester> GetAllSemester()
        {
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM Semesters";

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            List < Semester > semesters = null;

            if (reader.HasRows)
            {
                semesters = new List<Semester>();
                while (reader.Read())
                {
                    semesters.Add(new Semester() {Id = int.Parse(reader["Id"].ToString()),Semesters = reader["Semesters"].ToString()});
                }
                
            }
            return semesters;
        }
    }
}