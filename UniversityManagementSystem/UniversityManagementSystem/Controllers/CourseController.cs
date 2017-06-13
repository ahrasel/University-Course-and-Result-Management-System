using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models.EntityModel;

namespace UniversityManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        
       private DepartmentManager departmentManager = new DepartmentManager();
       private SemesterManager semesterManager = new SemesterManager();
       private CourseManager courseManager = new CourseManager();
       private  TeacherManager teacherManager = new TeacherManager();
        [HttpGet]
        public ActionResult CourseSetup()
        {
          
            ViewBag.Semesetrs = semesterManager.GetAllSemester();
            ViewBag.Departments = departmentManager.GettAllDepartment();

            
            return View();
        }
        
        public ActionResult CourseSetup(Course course)
        {

            string messege;
            try
            {
                int rowAffected = courseManager.SaveCourse(course);

                messege = rowAffected>0 ? "Course Saved Successfully" : "Course Saved Failed";
                ViewBag.a = messege;
            }
            catch (Exception e)
            {
                ViewBag.a = e.Message;
            }
            finally
            {
                ViewBag.Semesetrs = semesterManager.GetAllSemester();
                ViewBag.Departments = departmentManager.GettAllDepartment();
            }

            return View();

        }


        public ActionResult Courseassigntoteacher()
        {
            ViewBag.Departments = departmentManager.GettAllDepartment();
            return View();
        }
        [HttpPost]       
        public ActionResult Courseassigntoteacher(int courseTeacherId, int courseId ,int courseCredit)
        {
            string msg; 
            try
            {
                int assigntCourseTeacher = courseManager.AssignCourseTeacher(courseId,courseTeacherId);
                int teacherInfoUpdate = teacherManager.AssignCourseTeacher(courseTeacherId, courseCredit);

                if (assigntCourseTeacher>0&&teacherInfoUpdate>0)
                {
                    msg = "Course Assignd Successfully";
                }
                else
                {
                    msg = "Course Assignd Failed!";
                }
                ViewBag.msg = msg;

            }
            
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
            }
            finally
            {

                ViewBag.Departments = departmentManager.GettAllDepartment();
            }

            

            return View();
        }


        public ActionResult ShowAllCourse()
        {
            ViewBag.Departments = departmentManager.GettAllDepartment();
            return View();
        }
        //[HttpPost]
        //public ActionResult ShowAllCourse(int departmentId)
        //{

        //    try
        //    {
        //        ViewBag.Courses = courseManager.GetAllCourseById(departmentId);
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    finally
        //    {
        //        ViewBag.Departments = departmentManager.GettAllDepartment();
        //    }

        //    return View();
        //}

        public ActionResult UnassignAllCourse()
        {
            return View();
        }

     

        public JsonResult GetTeacherByDepartmentId(int departmentId)
        {
            var allTeacher = teacherManager.GetAllTeacher();
            var selectedTeacher = allTeacher.Where(a => int.Parse(a.DepartmentId) == departmentId);

            return Json(selectedTeacher, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ShowTeacherInfo(int teacherId)
        {
            var allTeacher = teacherManager.GetAllTeacher();
            var selectedTeacher = allTeacher.Where(a => a.Id == teacherId);
            return Json(selectedTeacher, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseByDepartmentId(int departmentId)
        {
            var allCourse = courseManager.GetAllCourse();
            var selectedCourse = allCourse.Where(a => a.CourseDepartmentId == departmentId&& a.Assign == 0);


            return Json(selectedCourse, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ShowCourseInfo(int courseId)
        {
            var allCourse = courseManager.GetAllCourse();
            var selectedCourse = allCourse.Where(a => a.Id == courseId && a.Assign == 0);
            return Json(selectedCourse, JsonRequestBehavior.AllowGet);
        }


        public JsonResult ShowCourseStatics(int departmentId)
        {
            var courses = courseManager.GetAllCourseById(departmentId);

            return Json(courses,JsonRequestBehavior.AllowGet);
        }

        public JsonResult UnassignAllCourses()
        {
            int unassignCourses = courseManager.UnassignAllCourses();

            return Json(unassignCourses, JsonRequestBehavior.AllowGet);
        }

    }
}   