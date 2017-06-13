using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;
using UniversityManagementSystem.Models.EntityModel;

namespace UniversityManagementSystem.BLL
{
    
    public class CourseManager
    {
        CoureseGateway coureseGateway = new CoureseGateway();
        public int SaveCourse(Course course)
        {
            if (IsCodeAvailabale(course.CourseCode) == false && IsNameAvailabale(course.CourseName) == false)
            {
                return coureseGateway.SaveCourse(course);
            }
            else
            {
                throw new Exception("Name And Code Must Be Unique");
            }
        }

       public List<Course> GetAllCourse()
       {
           return coureseGateway.GetAllCourse();
       }


        private bool IsNameAvailabale(string name)
        {
            Course course = coureseGateway.GetCourse(name);

            if (course == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        private bool IsCodeAvailabale(string code)
        {
            Course course = coureseGateway.GetCourse(code);

            if (course == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int AssignCourseTeacher(int courseId, int courseTeacherId)
        {
            return coureseGateway.AssignCourseTeacher(courseId,courseTeacherId);
        }

        public List<Course> GetAllCourseById(int departmentId)
        {
            return coureseGateway.GetAllCourseById(departmentId);
        }

        public int UnassignAllCourses()
        {
            return coureseGateway.UnassignAllCourses();
        }
    }
}