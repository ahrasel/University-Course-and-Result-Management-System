using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models.EntityModel;

namespace UniversityManagementSystem.BLL
{
    public class DepartmentManager
    {
        DepartmentGatewaye gateway = new DepartmentGatewaye();

        internal int SaveDepartment(Department dept)
        {

            if (IsDepartmentExist(dept) > 0)
            {
                throw new Exception("This Department is Already Exist");
            }
            return gateway.SaveDepartment(dept);
        }

        internal int IsDepartmentExist(Department dept)
        {
            int count = gateway.IsDepartmentExist(dept);
            return count;
        }

        public List<Department> GettAllDepartment()
        {
            return gateway.GettAllDepartment();
        }

        public Department GetDeparmentById(int id)
        {
            return gateway.GetDeparmentById(id);
        }
    }
}