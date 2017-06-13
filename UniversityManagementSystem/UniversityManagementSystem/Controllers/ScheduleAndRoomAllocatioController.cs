using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models.EntityModel;

namespace UniversityManagementSystem.Controllers
{
    public class ScheduleAndRoomAllocatioController : Controller
    {
        DepartmentManager _departmentManager = new DepartmentManager();
        CourseManager _courseManager = new CourseManager();
        AllocateClassroomManager _allocateClassroomManager = new AllocateClassroomManager();
        // GET: ScheduleAndRoomAllocatio
        public ActionResult AllocateClassroom()
        {

            ViewBag.Departments = _departmentManager.GettAllDepartment();
            ViewBag.Rooms = _allocateClassroomManager.GetAllRooms();
            return View();
        }
        [HttpPost]
        public ActionResult AllocateClassroom(AllocateClassroom allocateClassroom)
        {
            
            try
            {
               
                if (ModelState.IsValid)
                {
                    string msg;
                    int rowAffceted = _allocateClassroomManager.SaveAllocateRoomInfo(allocateClassroom);

                    msg = rowAffceted > 0 ? "Course Saved Successfully" : "Course Saved Failed";

                    ViewBag.msg = msg;
                }
                else
                {
                    ViewBag.msg = "Student Information is Not valid";
                }
                
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
            }
            finally
            {
                ViewBag.Rooms = _allocateClassroomManager.GetAllRooms();
                ViewBag.Departments = _departmentManager.GettAllDepartment();
            }
            
          

            return View();
        }


        public ActionResult ViewClassScheduleAndRoomAllocation()
        {
            ViewBag.Departments = _departmentManager.GettAllDepartment();
            
            return View();
        }
        //[HttpPost]
        //public ActionResult ViewClassScheduleAndRoomAllocation(int departmentId)
        //{
        //    ViewBag.Departments = _departmentManager.GettAllDepartment();

           
        //    return View();
        //}


        public ActionResult UnassignAllClassrooms()
        {
            return View();
        }


        public JsonResult GetAllCourseBydepartmentId(int departId)
        {
            var course = _courseManager.GetAllCourse().Where(c=>c.CourseDepartmentId==departId);
            return Json(course, JsonRequestBehavior.AllowGet);
        }


        public JsonResult AllAllocatedClassroomByDeptId(int departmentId)
        {
            var allocatedroomsandschedule = _allocateClassroomManager.GetAllAllocatedClassroomAndSchedule(departmentId);
            return Json(allocatedroomsandschedule, JsonRequestBehavior.AllowGet);
        }


        //public JsonResult DisableTimePickertime(string dayCode,int roomId)
        //{

        //    string a = "'[['1:00am', '2:00am'],['3:00am', '4:01am']]'";

        //    return Json(a, JsonRequestBehavior.AllowGet);
        //}



        public JsonResult UnalloceteAllClassroom()
        {
            int unallocateClassrooms = _allocateClassroomManager.UnallocateAllClassRooms();

            return Json(unallocateClassrooms, JsonRequestBehavior.AllowGet);
        }



    }
}