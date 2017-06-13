using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models.EntityModel;

namespace UniversityManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        // GET: Department
        public ActionResult SaveDepartment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveDepartment(Department department)
        {
            string messege;
            try
            {
                int rowAffected = departmentManager.SaveDepartment(department);

                if (rowAffected>0)
                {
                    messege = "Deparment Save Successfully";
                }
                else
                {
                    messege = "Deparment Save Failed!";
                }

            }
            catch (Exception e)
            {
                messege = e.Message;
            }

            ViewBag.msg = messege;
            return View();
        }
        public ActionResult ShowAlldepartment()
        {
            ViewBag.Departments = departmentManager.GettAllDepartment();

            return View();
        }
    }
}