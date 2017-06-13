using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models.EntityModel;

namespace UniversityManagementSystem.BLL
{
    
    public class StudnetManager
    {
        StudentGateway studentGateway = new StudentGateway();

        public int SaveStudent(Student student)
        {
            if (IsEmailUnique(student.StudentEmail))
            {
                return studentGateway.SaveStudent(student);
            }

           throw new Exception("Email Must Be Unique");
        }

        public List<Student> GetAllStudent()
        {
            return studentGateway.GetAllStudent();
        }

        private bool IsEmailUnique(string email)
        {
            Student student = studentGateway.GetStudentByEmail(email);

            if (student==null)
            {
                return true;
            }
            return false;
        }

        public string GetRagistrationNo(Student student)
        {
            DepartmentManager departmentManager =new DepartmentManager();
            Department department=departmentManager.GetDeparmentById(student.StudentDepartmnetId);
            List<Student> students = studentGateway.GetAllStudent();
            int count=0;

            if (students!=null)
            {

                foreach (Student s in students)
                {
                    if (s.StudentDepartmnetId == student.StudentDepartmnetId && s.StudentRegistrationDate.Year == student.StudentRegistrationDate.Year)
                    {
                        count++;
                    }
                }
            }

            string regNo = department.DepartmentCode + "-" +student.StudentRegistrationDate.Year+ "-"+((++count).ToString("D3"));
            return regNo;
        }

        public int EnrolledCourse(int studentId, int courseId, DateTime enrolledDate)
        {
            return studentGateway.EnrolledCourse(studentId, courseId, enrolledDate);
        }
        public List<EnrolledCourse> GetStudentEnrolledCourseByStudentId(int studentId)
        {

            return studentGateway.GetStudentEnrolledCourseByStudentId(studentId);

            //throw new NotImplementedException();
        }

        public int SaveStudentResult(int studentId, int courseId, string gradeLetter)
        {
            return studentGateway.SaveStudentResult(studentId, courseId, gradeLetter);

        }

        public object GetStudentResultVyStudentId(int studentId)
        {
            return studentGateway.GetStudentResultVyStudentId(studentId);
        }
    }
}