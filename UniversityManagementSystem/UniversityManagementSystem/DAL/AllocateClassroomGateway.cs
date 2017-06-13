using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models.EntityModel;

namespace UniversityManagementSystem.DAL
{
    public class AllocateClassroomGateway
    {
        private string connectionstring = WebConfigurationManager.ConnectionStrings["UniManagement"].ConnectionString;

        public List<ClassRoom> GetAllRooms()
        {
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = " select * from Rooms";

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            List<ClassRoom> list = null;

            if (reader.HasRows)
            {
                list = new List<ClassRoom>();
                while (reader.Read())
                {
                    list.Add(new ClassRoom() { Id = int.Parse(reader["Id"].ToString()), RoomNo = reader["RoomNo"].ToString() });
                }
            }
            reader.Close();
            connection.Close();
            
            return list;

        }

        public int SaveAllocateRoomInfo(AllocateClassroom allocateClassroom)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = "INSERT INTO AllocatedRooms VALUES('" + allocateClassroom.CourseId+"','"+allocateClassroom.RoomNo+"','"+allocateClassroom.Day+"','"+allocateClassroom.FromTime+"','"+allocateClassroom.ToTime+"')";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }

        public List<AllocatedRooms> GetAllAllocatedClassroomAndSchedule(int departmentId)
        {
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "select * from AllocatedRoomsView where CourseDepartmentId='"+departmentId+"'";

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            //var list = new[]
            //{
            //  //  new {CourseCode = "", CourseName = "", Day = "", FromTime = "", ToTime = "", CourseDepartmentId = ""}
            //    new {CourseCode = "", CourseName = "",RoomNo="",Day = "", FromTime = "", ToTime = ""}

            //}.ToList();

            List<AllocatedRooms> al = new List<AllocatedRooms>();

            al.Add(new AllocatedRooms()
            {
                CourseCode = "No Data Found",
                CourseName = "No Data Found",
                ScheduleInfo = "No Data Found"
            });


            if (reader.HasRows)
            {
               
                while (reader.Read())
                {

                    al.Add(new AllocatedRooms()
                    {
                        CourseCode = reader["CourseCode"].ToString(),
                        CourseName = reader["CourseName"].ToString(),
                        ScheduleInfo = "R. No: " + reader["RoomNo"] + ", " + reader["Day"] + ", " + reader["FromTime"] + " - " + reader["ToTime"]
                    });


                }
            }
            reader.Close();
            connection.Close();

            if (al.Count > 1)
            {
                if (al.Any(a => a.CourseCode == "No Data Found"))
                {
                    al.RemoveAt(0);
                }
            }


            return al;

        }


        public int UnallocateAllClassRooms()
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = "DELETE FROM AllocatedRooms";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }

        public List<MyTime> GetAllTimeByDayAndRoomNo(string day, int roomNo)
        {
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "select AllocatedRooms.FromTime,AllocatedRooms.ToTime from AllocatedRooms where Day='"+day+"' AND RoomNo='"+roomNo+"'";

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();
            List<MyTime> times = null;

            if (reader.HasRows)
            {
                times = new List<MyTime>();
                while (reader.Read())
                {
                    times.Add(new MyTime() {FromDate = reader["FromTime"].ToString(), ToDate = reader["ToTime"].ToString()});

                }
            }
            reader.Close();
            connection.Close();

            return times;

        }
    }

    public class AllocatedRooms
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string ScheduleInfo { get; set; }
    }
}