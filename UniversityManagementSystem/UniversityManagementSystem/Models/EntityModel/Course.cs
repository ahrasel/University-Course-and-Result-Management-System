using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models.EntityModel
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public decimal CourseCredit { get; set; }
        public string CourseDescription { get; set; }
        public int CourseDepartmentId { get; set; }
        public int CourseSemesterId { get; set; } 
        public string CourseTeacherName { get; set; }    
        public int Assign { get; set; }    
        public string CourseSemesterName { get; set; }    

    }
}