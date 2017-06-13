using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystem.Models.EntityModel;

namespace UniversityManagementSystem.DAL
{

    public class DepartmentGatewaye
    {
        private string connectionstring = WebConfigurationManager.ConnectionStrings["UniManagement"].ConnectionString;


        internal int SaveDepartment(Department dept)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = "INSERT INTO Departments VALUES('" + dept.DepartmentCode + "','" + dept.DepartmentName + "')";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;

        }

        internal int IsDepartmentExist(Department dept)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = "SELECT count(*) FROM Departments Where DepartmentCode='" + dept.DepartmentCode +
                           "' or DepartmentName='" + dept.DepartmentName + "'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int Count = (int) command.ExecuteScalar();
            connection.Close();
            return Count;
        }

        public List<Department> GettAllDepartment()
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = "SELECT * FROM Departments";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();
            List<Department> departments = null;
            if (reader.HasRows)
            {
                departments = new List<Department>();
                while (reader.Read())
                {
                    departments.Add(new Department()
                    {
                        Id = int.Parse(reader["Id"].ToString()),
                        DepartmentCode = reader["DepartmentCode"].ToString(),
                        DepartmentName = reader["DepartmentName"].ToString()

                    });

                }

            }
            return departments;

        }


        public Department GetDeparmentById(int id)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = "SELECT * FROM Departments WHERE Id='" + id + "'";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                return new Department()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    DepartmentCode = reader["DepartmentCode"].ToString(),
                    DepartmentName = reader["DepartmentName"].ToString()

                };
            }
            return null;

        }
    }
}