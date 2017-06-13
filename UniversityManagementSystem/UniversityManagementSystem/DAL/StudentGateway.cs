using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystem.Models.EntityModel;

namespace UniversityManagementSystem.DAL
{
    public class StudentGateway
    {
        private string connectionstring = WebConfigurationManager.ConnectionStrings["UniManagement"].ConnectionString;

        public int SaveStudent(Student student)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            string query =
                "INSERT INTO Students ([StudentRegNo],[StudentName],[StudentEmail],[StudentContactNo],[StudentAddress],[StudentRegistrationDate],[StudentDepartmnetId]) VALUES('" +
                student.StudentRegNo + "','" + student.StudentName + "','" + student.StudentEmail + "','" +
                student.StudentContactNo + "','" + student.StudentAddress + "','" + student.StudentRegistrationDate +
                "','" + student.StudentDepartmnetId + "')";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }

        public Student GetStudentByEmail(string email)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = "SELECT * FROM Students WHERE StudentEmail='" + email + "'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            Student student = null;

            if (reader.HasRows)
            {
                student = new Student();
                reader.Read();
                student.StudentId = int.Parse(reader["StudentId"].ToString());
                student.StudentRegNo = reader["StudentRegNo"].ToString();
                student.StudentName = reader["StudentName"].ToString();
                student.StudentEmail = reader["StudentEmail"].ToString();
                student.StudentContactNo = reader["StudentContactNo"].ToString();
                student.StudentAddress = reader["StudentAddress"].ToString();
                student.StudentRegistrationDate = DateTime.Parse(reader["StudentRegistrationDate"].ToString());
                student.StudentDepartmnetId = int.Parse(reader["StudentDepartmnetId"].ToString());


            }
            connection.Close();
            return student;
        }

        public List<Student> GetAllStudent()
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = "SELECT * FROM Students";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<Student> students = null;

            if (reader.HasRows)
            {
                students = new List<Student>();
                while (reader.Read())
                {
                    students.Add(new Student()
                    {
                        StudentId = int.Parse(reader["StudentId"].ToString()),
                        StudentRegNo = reader["StudentRegNo"].ToString(),
                        StudentName = reader["StudentName"].ToString(),
                        StudentEmail = reader["StudentEmail"].ToString(),
                        StudentContactNo = reader["StudentContactNo"].ToString(),
                        StudentAddress = reader["StudentAddress"].ToString(),
                        StudentRegistrationDate = DateTime.Parse(reader["StudentRegistrationDate"].ToString()),
                        StudentDepartmnetId = int.Parse(reader["StudentDepartmnetId"].ToString())

                    });
                }
            }
            connection.Close();
            return students;
        }

        public int EnrolledCourse(int studentId, int courseId, DateTime enrolledDate)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = "INSERT INTO CoureseEnrolled ([CourseId],[StudentId],[EnrollDate],[CourseGrade]) VALUES('" +
                           courseId + "','" + studentId + "','" + enrolledDate + "','Not Graded Yet')";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }


        public List<EnrolledCourse> GetStudentEnrolledCourseByStudentId(int studentId)
        {
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = " select * from CoureseEnrolled where StudentId='" + studentId + "'";

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            List<EnrolledCourse> enrolledCourses = null;

            if (reader.HasRows)
            {
                enrolledCourses = new List<EnrolledCourse>();
                while (reader.Read())
                {
                    enrolledCourses.Add(new EnrolledCourse()
                    {

                        Id = int.Parse(reader["Id"].ToString()),
                        CourseId = int.Parse(reader["CourseId"].ToString()),
                        StudentId = int.Parse(reader["StudentId"].ToString()),
                        EnrollDate = DateTime.Parse(reader["EnrollDate"].ToString()),
                        CourseGrade = reader["CourseGrade"].ToString(),

                    });
                }
            }
            reader.Close();
            connection.Close();
            return enrolledCourses;

            //throw new NotImplementedException();
        }


        public int SaveStudentResult(int studentId, int courseId, string gradeLetter)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = "UPDATE CoureseEnrolled SET  CourseGrade='" + gradeLetter + "' WHERE CourseId='" + courseId +
                           "' AND StudentId='" + studentId + "'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }

        public object GetStudentResultVyStudentId(int studentId)
        {
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = " select * from StudentResultView where StudentId='" + studentId + "'";

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            var list = new[] {new {Name = "", Code = "", Grade = ""}}.ToList();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    list.Add(new { Name = reader["CourseName"].ToString(), Code = reader["CourseCode"].ToString(), Grade = reader["CourseGrade"].ToString() });
                }
            }
            reader.Close();
            connection.Close();
            list.RemoveAt(0);
            return list;

        }
    }
}