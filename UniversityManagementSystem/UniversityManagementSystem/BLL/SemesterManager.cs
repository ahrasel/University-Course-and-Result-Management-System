using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models.EntityModel;

namespace UniversityManagementSystem.BLL
{
    public class SemesterManager
    {
       private SemesterGatewaye semesterGatewaye = new SemesterGatewaye();
        public List<Semester> GetAllSemester()
        {
            return semesterGatewaye.GetAllSemester();
        }
    }
}