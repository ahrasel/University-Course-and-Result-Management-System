using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models.EntityModel;

namespace UniversityManagementSystem.BLL
{
    public class TeacherManager
    {
        TeacherGatewaye teacherGatewaye = new TeacherGatewaye();
        public int SaveTeacher(Teacher teacher)
        {
            if (IsEmailAvailabale(teacher.TeacherEmail)==false)
            {
                return teacherGatewaye.SaveTeacher(teacher);
            }
            return 0;
        }

        protected bool IsEmailAvailabale(string email)
        {
            Teacher teacher = teacherGatewaye.GetTeaacherByEmail(email);
            if (teacher == null)
            {
                return false;
            }
            throw new Exception("Email Must Be Unique");
        }

        public List<Teacher> GetAllTeacher()
        {
            
            return teacherGatewaye.GetAllTeacher();
        }

        public int AssignCourseTeacher(int courseTeacherId,int courseCredit )
        {
            return teacherGatewaye.AssignCourseTeacher(courseTeacherId,courseCredit);
        }
    }
}