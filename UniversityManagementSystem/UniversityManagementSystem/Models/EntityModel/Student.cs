using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models.EntityModel
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentRegNo { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string StudentName { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string StudentEmail { get; set; }
        [Required]
        [Display(Name = "Contact No.")]
        public string StudentContactNo { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string StudentAddress { get; set; }
        [Required]
        [Display(Name = "Date")]
        public DateTime StudentRegistrationDate { get; set; }
        [Required]
        [Display(Name = "Department")]
        public int StudentDepartmnetId { get; set; }
     
        [Display(Name = "Enroll Date")]
        public DateTime StudentCourseEnrollDate { get; set; }
       
        [Display(Name = "Course")]
        public List<Course> StudentCourses { get; set; }
    }
}