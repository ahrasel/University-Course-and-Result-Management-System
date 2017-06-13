using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models.EntityModel;

namespace UniversityManagementSystem.BLL
{
    public class AllocateClassroomManager
    {
        AllocateClassroomGateway _allocateClassroomGateway = new AllocateClassroomGateway();
        public List<ClassRoom> GetAllRooms()
        {
            return _allocateClassroomGateway.GetAllRooms();
        }

        public int SaveAllocateRoomInfo(AllocateClassroom allocateClassroom)
        {
            if (IsRoomAvailable(allocateClassroom.Day,allocateClassroom.FromTime,allocateClassroom.ToTime,int.Parse(allocateClassroom.RoomNo)))
            {
                 return _allocateClassroomGateway.SaveAllocateRoomInfo(allocateClassroom);    
            }

           throw new Exception("Room Is Not Available With This Time!!");
        }

        public object GetAllAllocatedClassroomAndSchedule(int departmentId)
        {
           var list= ConcateSchedule(_allocateClassroomGateway.GetAllAllocatedClassroomAndSchedule(departmentId));
           
            return list.ToList();
        }

        private List<AllocatedRooms> ConcateSchedule(List<AllocatedRooms> list)
        {
            var a = list;
            List<AllocatedRooms> mylist = new List<AllocatedRooms>();
            foreach (AllocatedRooms allocatedRooms in list)
            {

                var ll = a.FindAll(c => c.CourseCode == allocatedRooms.CourseCode);

                string schedule = "";
                foreach (AllocatedRooms s in ll)
                {
                    schedule += s.ScheduleInfo + "</br>";
                }
                mylist.Add(new AllocatedRooms()
                {
                    CourseName = allocatedRooms.CourseName,
                    CourseCode =allocatedRooms.CourseCode,
                    ScheduleInfo = schedule
                });
            }
            var selectedList = mylist.GroupBy(x => x.CourseCode).Select(y => y.First());
            
            return selectedList.ToList();
        }

        public int UnallocateAllClassRooms()
        {
            return _allocateClassroomGateway.UnallocateAllClassRooms();
        }


        private bool IsRoomAvailable(string day, string fromTime, string toTime,int roomNo)
        {
            List<string> l = GenarateArray();
            List<string> ls = new List<string>();

            int a = l.IndexOf(fromTime);
            int b= l.IndexOf(toTime);


            if (a>b)
            {
                throw new Exception("Please Chekout Your Input Time!!!");
            }
            else
            {
                List<MyTime> times = _allocateClassroomGateway.GetAllTimeByDayAndRoomNo(day, roomNo);

                if (times != null)
                {
                    foreach (MyTime time in times)
                    {
                        for (int i = l.IndexOf(time.FromDate); i <= l.IndexOf(time.ToDate); i++)
                        {
                            ls.Add(l[i]);
                        }
                    }


                    if (ls.Contains(fromTime))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }

                else
                {
                    return true;
                }
            }
        }


        private List<string> GenarateArray()
        {
            List<string> l = new List<string>();

            l.Add("12:00 AM");
            l.Add("12:15 AM");
            l.Add("12:30 AM");
            l.Add("12:45 AM");
        
            for (int i = 1; i <= 11; i++)
            {
                for (int j = 0; j <= 45; j += 15)
                {
                    l.Add(i.ToString("D2") + ":" + j.ToString("D2") + " AM");
                }
            }
            l.Add("12:00 PM");
            l.Add("12:15 PM");
            l.Add("12:30 PM");
            l.Add("12:45 PM");
            for (int i = 1; i <= 11; i++)
            {
                for (int j = 0; j <= 45; j += 15)
                {
                    l.Add(i.ToString("D2") + ":" + j.ToString("D2") + " PM");
                }
            }
            return l;
        }


    }
    public class MyTime
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}