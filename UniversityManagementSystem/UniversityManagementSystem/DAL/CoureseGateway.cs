using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystem.Models.EntityModel;

namespace UniversityManagementSystem.DAL
{
    public class CoureseGateway
    {
        private string connectionstring = WebConfigurationManager.ConnectionStrings["UniManagement"].ConnectionString;
        public Course GetCourse(string value)
        {
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM Courses where CourseCode='" + value+ "' or CourseName='" + value + "'";

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                return new Course()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    CourseCode = reader["CourseCode"].ToString(),
                    CourseName = reader["CourseName"].ToString(),
                    CourseCredit = decimal.Parse(reader["CourseCredit"].ToString()),
                    CourseDescription = reader["CourseDescription"].ToString(),
                    CourseDepartmentId = int.Parse(reader["CourseDepartmentId"].ToString()),
                    CourseSemesterId = int.Parse(reader["CourseSemesterId"].ToString()),
                    Assign = int.Parse(reader["Assign"].ToString())
                };
            }
            connection.Close();
            return null;
            //throw new NotImplementedException();
        }

        public int SaveCourse(Course course)
        {
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "INSERT INTO Courses ([CourseCode],[CourseName],[CourseCredit],[CourseDescription],[CourseDepartmentId],[CourseSemesterId] ,[CourseTeacherName],[Assign]) VALUES('" + course.CourseCode+"','"+course.CourseName+"','"+course.CourseCredit+"','"+course.CourseDescription+"','"+course.CourseDepartmentId+"','"+course.CourseSemesterId+"','Not Assigned Yet','"+0+"')";

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            int rowAffecred = command.ExecuteNonQuery();

            return rowAffecred;
            
        }

       public List<Course> GetAllCourse()
        {
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "SELECT * FROM Courses";

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            List<Course> courses = null;

            if (reader.HasRows)
            {
                courses=new List<Course>();
                while (reader.Read())
                {
                    courses.Add(new Course()
                    {
                        Id = int.Parse(reader["Id"].ToString()),
                        CourseCode = reader["CourseCode"].ToString(),
                        CourseName = reader["CourseName"].ToString(),
                        CourseCredit = decimal.Parse(reader["CourseCredit"].ToString()),
                        CourseDescription = reader["CourseDescription"].ToString(),
                        CourseDepartmentId = int.Parse(reader["CourseDepartmentId"].ToString()),
                        CourseSemesterId = int.Parse(reader["CourseSemesterId"].ToString()),
                        CourseTeacherName = reader["CourseTeacherName"].ToString(),
                        Assign = int.Parse(reader["Assign"].ToString())
                    });
                }
            }
            reader.Close();
            connection.Close();
            return courses;
        }

        public int AssignCourseTeacher(int courseId, int courseTeacherId)
        {
            TeacherGatewaye teacherGatewaye = new TeacherGatewaye();
            Teacher teacher = teacherGatewaye.GetteacherById(courseTeacherId);
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "UPDATE Courses SET CourseTeacherName='" + teacher.TeacherName+"', Assign='"+1+"' WHERE Id='"+courseId+"'";

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            int rowAffecred = command.ExecuteNonQuery();

            return rowAffecred;

        }

        public List<Course> GetAllCourseById(int departmentId)
        {
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = " select * from CourseAssignView where CourseDepartmentId='"+departmentId+"'";

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            List<Course> courses = null;

            if (reader.HasRows)
            {
                courses = new List<Course>();
                while (reader.Read())
                {
                    courses.Add(new Course()
                    {
                       
                        CourseCode = reader["CourseCode"].ToString(),
                        CourseName = reader["CourseName"].ToString(),
                        CourseTeacherName = reader["CourseTeacherName"].ToString(),
                        CourseSemesterName = reader["Semesters"].ToString()
                    });
                }
            }
            reader.Close();
            connection.Close();
            return courses;
        }

        public int UnassignAllCourses()
        {
            SqlConnection connection = new SqlConnection(connectionstring);

            string query1 = "UPDATE Courses SET CourseTeacherName='Not Assigned Yet',Assign=0";
            string query2 = "UPDATE Teachers SET Teachers.RemainingCredit = Teachers.TakenCredit FROM Teachers";

            connection.Open();
            SqlCommand command1 = new SqlCommand(query1, connection);
            int rowAffecred1 = command1.ExecuteNonQuery();

            SqlCommand command2 = new SqlCommand(query2, connection);

            int rowAffecred2 = command2.ExecuteNonQuery();

            return rowAffecred1;
        }
    }
}