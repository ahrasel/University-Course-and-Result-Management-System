using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models.EntityModel;

namespace UniversityManagementSystem.BLL
{
    public class DesignationManager
    {
       private DesignationGatewaye designationGatewaye = new DesignationGatewaye();
        public List<Designation> GetAllDesignation()
        {

            return designationGatewaye.GetAllDesignation();
            //throw new NotImplementedException();
        }
    }
}