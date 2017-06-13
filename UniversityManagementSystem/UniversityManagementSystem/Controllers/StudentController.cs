using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models.EntityModel;

namespace UniversityManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private DepartmentManager departmentManager = new DepartmentManager();
        private StudnetManager studnetManager = new StudnetManager();
        public ActionResult Register()
        {
            ViewBag.Departments = new SelectList(departmentManager.GettAllDepartment(),"Id", "DepartmentCode");
            return View();
        }
        [HttpPost]
        public ActionResult Register(Student student)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    student.StudentRegNo = studnetManager.GetRagistrationNo(student);
                    int rowAffected = studnetManager.SaveStudent(student);
                    if (rowAffected>0)
                    {
                        msg = "Student Saved Successfully";
                        ModelState.Clear();
                    }
                    else
                    {
                        msg = "Student Saved Failed!";
                    }
                    
                }
                else
                {
                    msg = "Student Information Is Not Valid";
                }
                
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            finally
            {
                
                ViewBag.Departments = new SelectList(departmentManager.GettAllDepartment(), "Id", "DepartmentCode");
                
            }
            ViewBag.msg = msg;
            return View();
        }

        public ActionResult Enrollcourse()
        {
            ViewBag.Students = studnetManager.GetAllStudent();

            return View();
        }
        [HttpPost]
        public ActionResult Enrollcourse(int studentId, int courseId, DateTime enrolledDate)
        {


            string msg;

            try
            {

                int rowAffceted = studnetManager.EnrolledCourse(studentId, courseId, enrolledDate);

                if (rowAffceted > 0)
                {
                    msg = "Course Enrolled Successfully";
                }
                else
                {
                    msg = "Course Enrolled Faield!";
                }
                ViewBag.msg = msg;
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
            }

            finally
            {
                 ViewBag.Students = studnetManager.GetAllStudent();

            }
            

            return View();
        }


        public ActionResult SaveStudentResult()
        {
            ViewBag.Students = studnetManager.GetAllStudent();
            
            return View();
        }

        [HttpPost]
        public ActionResult SaveStudentResult(int studentId, int courseId,string gradeLetter)
        {

            string msg;

            try
            {

                int rowAffceted = studnetManager.SaveStudentResult(studentId, courseId, gradeLetter);

                if (rowAffceted > 0)
                {
                    msg = "Result Save Successfully";
                }
                else
                {
                    msg = "Result Save Faield!";
                }
                ViewBag.msg = msg;
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
            }

            finally
            {
                ViewBag.Students = studnetManager.GetAllStudent();

            }


            ViewBag.Students = studnetManager.GetAllStudent();



            return View();
        }


        public ActionResult ViewResult()
        {
            ViewBag.Students = studnetManager.GetAllStudent();
            return View();
        }



        public JsonResult StudentDetails(int studentId)
        {
            var selectStudent = studnetManager.GetAllStudent().Find(a => a.StudentId == studentId);
            var department = departmentManager.GetDeparmentById(selectStudent.StudentDepartmnetId);
            var result = new { Name = selectStudent.StudentName, Email = selectStudent.StudentEmail, Department = department.DepartmentName };

            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetAllCourse(int studentId)
        {
            CourseManager courseManager = new CourseManager();

            var studentEnrooledCourse = studnetManager.GetStudentEnrolledCourseByStudentId(studentId);
            var selectStudent = studnetManager.GetAllStudent().Find(a => a.StudentId == studentId);
            var courses = courseManager.GetAllCourse().Where(c => c.CourseDepartmentId == selectStudent.StudentDepartmnetId);


            if (studentEnrooledCourse == null) return Json(courses, JsonRequestBehavior.AllowGet);
            {
                var course = courses.Where(c => !studentEnrooledCourse.Exists(a => a.CourseId == c.Id)).ToList();
                return Json(course, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetAllCourseForSaveGrade(int studentId)
        {
            CourseManager courseManager = new CourseManager();
            if (studnetManager.GetStudentEnrolledCourseByStudentId(studentId)!=null)
            {
                 var studentEnrooledCourse = studnetManager.GetStudentEnrolledCourseByStudentId(studentId).Where(c => c.CourseGrade == "Not Graded Yet");

                 var courses = courseManager.GetAllCourse().Where(a => studentEnrooledCourse.Any(x => x.CourseId == a.Id));
                return Json(courses, JsonRequestBehavior.AllowGet);
            }

            return Json(null, JsonRequestBehavior.AllowGet);

        }

        public JsonResult ShowStudentResultByStudentId(int studentId)
        {
            var courses = studnetManager.GetStudentResultVyStudentId(studentId);
            return Json(courses, JsonRequestBehavior.AllowGet);
        }


    }
}