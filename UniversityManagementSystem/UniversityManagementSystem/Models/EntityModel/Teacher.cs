using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models.EntityModel
{
    public class Teacher
    {
        public int Id { get; set; }
        public string TeacherName { get; set; }
        public string TeacherAddress { get; set; }
        public string TeacherEmail { get; set; }
        public string TeacherContactNo { get; set; }
        public string DesignationId { get; set; }
        public string DepartmentId { get; set; }
        public decimal TakenCredit { get; set; }
        public decimal RemainingCredit { get; set; }
        public decimal TotalCreditTake { get; set; }
    }
}