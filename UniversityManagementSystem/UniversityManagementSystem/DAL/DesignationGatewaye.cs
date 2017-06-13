using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystem.Models.EntityModel;

namespace UniversityManagementSystem.DAL
{
    public class DesignationGatewaye
    {
        private string connectionstring = WebConfigurationManager.ConnectionStrings["UniManagement"].ConnectionString;

        public List<Designation> GetAllDesignation()
        {
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM Designations";

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            List<Designation> designations = null;

            if (reader.HasRows)
            {
                designations = new List<Designation>();
                while (reader.Read())
                {
                    designations.Add(new Designation() { Id = int.Parse(reader["Id"].ToString()), DesignationName = reader["DesignationName"].ToString() });
                }

            }
            return designations;
        }
    }
}