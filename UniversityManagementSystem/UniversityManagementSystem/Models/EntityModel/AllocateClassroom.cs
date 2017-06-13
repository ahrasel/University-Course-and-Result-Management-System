using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models.EntityModel
{
    public class AllocateClassroom
    {
        public int Id { get; set; }
        [Required]
        public int CourseId  { get; set; }
        [Required]
        public string RoomNo  { get; set; }
        [Required]
        public string Day  { get; set; }
        [Required]
        public string FromTime  { get; set; }
        [Required]
        public string ToTime  { get; set; }
        
    }
}