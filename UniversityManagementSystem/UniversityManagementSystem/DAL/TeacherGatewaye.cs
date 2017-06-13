using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystem.Models.EntityModel;

namespace UniversityManagementSystem.DAL
{
    public class TeacherGatewaye
    {

        private string connectionstring = WebConfigurationManager.ConnectionStrings["UniManagement"].ConnectionString;
        
        public Teacher GetTeaacherByEmail(string email)
        {

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM Teachers where TeacherEmail='" + email + "'";

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                return new Teacher()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    TeacherName = reader["TeacherName"].ToString(),
                    TeacherAddress = reader["TeacherAddress"].ToString(),
                    TeacherEmail = reader["TeacherEmail"].ToString(),
                    TeacherContactNo = reader["ContactNo"].ToString(),
                    DesignationId = reader["DesignationId"].ToString(),
                    DepartmentId = reader["DepartmentId"].ToString(),
                    TakenCredit = decimal.Parse(reader["TakenCredit"].ToString()),
                    RemainingCredit = decimal.Parse(reader["RemainingCredit"].ToString()),
                    TotalCreditTake = decimal.Parse(reader["TotalCreditTake"].ToString())
                   
                };
            }
            return null;
            //throw new NotImplementedException();
        }

        public int SaveTeacher(Teacher teacher)
        {
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "INSERT INTO Teachers VALUES('"+teacher.TeacherName+"','"+teacher.TeacherAddress+"','"+teacher.TeacherEmail+"','"+teacher.TeacherContactNo+"','"+teacher.DesignationId+"','"+teacher.DepartmentId+"','"+teacher.TakenCredit+"','"+ teacher.TakenCredit+ "','"+0+"')";

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            int rowAffecred = command.ExecuteNonQuery();

            return rowAffecred;

            //throw new NotImplementedException();
        }

       public List<Teacher> GetAllTeacher()
        {
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM Teachers";

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            List<Teacher> teachers = null;
            if (reader.HasRows)
            {
                teachers=new List<Teacher>();
                while (reader.Read())
                {
                    teachers.Add(new Teacher()
                    {
                        Id = int.Parse(reader["Id"].ToString()),
                        TeacherName = reader["TeacherName"].ToString(),
                        TeacherAddress = reader["TeacherAddress"].ToString(),
                        TeacherEmail = reader["TeacherEmail"].ToString(),
                        TeacherContactNo = reader["ContactNo"].ToString(),
                        DesignationId = reader["DesignationId"].ToString(),
                        DepartmentId = reader["DepartmentId"].ToString(),
                        TakenCredit = decimal.Parse(reader["TakenCredit"].ToString()),
                        RemainingCredit = decimal.Parse(reader["RemainingCredit"].ToString()),
                        TotalCreditTake = decimal.Parse(reader["TotalCreditTake"].ToString())
                    });
                }
            }
            return teachers;
        }

        public int AssignCourseTeacher(int courseTeacherId, int courseCredit)
        {
            Teacher teacher = GetteacherById(courseTeacherId);

            decimal r = teacher.RemainingCredit - courseCredit;
            decimal t = teacher.TotalCreditTake + courseCredit;

            if (teacher.RemainingCredit<0)
            {
                throw new Exception("Teacher credit limit reached");
               
            }
            else
            {
                SqlConnection connection = new SqlConnection(connectionstring);

                string query = "UPDATE Teachers SET RemainingCredit='" + r + "',TotalCreditTake='" + t + "' WHERE Id='"+courseTeacherId+"'";

                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                int rowAffecred = command.ExecuteNonQuery();

                return rowAffecred;
            }
            
        }

        public Teacher GetteacherById(int id)
        {
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM Teachers where Id='" + id + "'";

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                return new Teacher()
                {
                    TeacherName = reader["TeacherName"].ToString(),
                    TakenCredit = decimal.Parse(reader["TakenCredit"].ToString()),
                    RemainingCredit = decimal.Parse(reader["RemainingCredit"].ToString()),
                    TotalCreditTake = decimal.Parse(reader["TotalCreditTake"].ToString())

                };
            }
            return null;
        }

    }
}