using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models.EntityModel
{
    public class EnrolledCourse
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Select Course")]
        public int CourseId { get; set; }
        [Required]
        [Display(Name = "Student Reg. No.")]
        public Student SelectStudent { get; set; }
        public int StudentId { get; set; }

        [Required]
        public DateTime EnrollDate { get; set; }
        public string CourseGrade { get; set; }


    }
}