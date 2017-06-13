using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models.EntityModel;

namespace UniversityManagementSystem.Controllers
{
    public class TeacherController : Controller
    {
        private DepartmentManager departmentManager = new DepartmentManager();
        private DesignationManager designationManager = new DesignationManager();
        private TeacherManager teacherManager = new TeacherManager();

        [HttpGet]
        public ActionResult SaveTeacher()
        {
            List<Designation> designations = designationManager.GetAllDesignation();
            List<Department> departments = departmentManager.GettAllDepartment();
            //new List<Department>()
            //{
            //    new Department {Id = 1,DepartmentName = "CSE"},
            //    new Department {Id = 2,DepartmentName = "EEE"},
            //    new Department {Id = 3,DepartmentName = "BBA"}
            //};
            ViewBag.Designations = designations;
            ViewBag.Departments = departments;

            return View();
        }
        [HttpPost]
        public ActionResult SaveTeacher(Teacher teacher)
        {
            string messege;
            try
            {
                int rowAffected = teacherManager.SaveTeacher(teacher);

                if (rowAffected > 0)
                {
                    messege = "Teacher Information Saved Successfully";
                }
                else
                {
                    messege = "Teacher Information Saved Failed";
                }
                ViewBag.a = messege;
            }
            catch (Exception e)
            {
                ViewBag.a = e.Message;
            }
            finally
            {
                List<Designation> designations = designationManager.GetAllDesignation();
                List<Department> departments = new List<Department>()
                 {
                new Department {Id = 1,DepartmentName = "CSE"},
                new Department {Id = 2,DepartmentName = "EEE"},
                new Department {Id = 3,DepartmentName = "BBA"}
                 };
                ViewBag.Designations = designations;
                ViewBag.Departments = departments;
            }
            
            return View();
        }
    }
}