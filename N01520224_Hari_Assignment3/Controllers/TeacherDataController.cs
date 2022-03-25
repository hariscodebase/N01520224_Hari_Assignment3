using MySql.Data.MySqlClient;
using N01520224_Hari_Assignment3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace N01520224_Hari_Assignment3.Controllers
{
    public class TeacherDataController : ApiController
    {
        private SchoolDbContext School = new SchoolDbContext();


        [HttpGet]
        public List<Teacher> ListTeachers()
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "select * from teachers";

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Authors
            List<Teacher> Teachers = new List<Teacher> { };

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFName = ResultSet["teacherfname"].ToString();
                string TeacherLName = ResultSet["teacherlname"].ToString();
                string TeacherHireDate = ResultSet["hiredate"].ToString();
                string TeacherSalary = ResultSet["salary"].ToString();


                Teacher NewTeacher = new Teacher();
                NewTeacher.Id = TeacherId;
                NewTeacher.FName = TeacherFName;
                NewTeacher.LName = TeacherLName;
                NewTeacher.HireDate = TeacherHireDate;
                NewTeacher.Salary = TeacherSalary;

                //Add the Author Name to the List
                Teachers.Add(NewTeacher);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of author names
            return Teachers;
        }


        /// <summary>
        /// Finds an author in the system given an ID
        /// </summary>
        /// <param name="id">The author primary key</param>
        /// <returns>An author object</returns>
        [HttpGet]
        [Route("api/teacherdata/findclasses/{id}")]
        public List<string> FindClasses(int id)
        {
            List<string> ClassNames = new List<string> { };

            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "SELECT * FROM classes c JOIN teachers t ON c.teacherid = t.teacherid WHERE c.teacherid = " + id;

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {

                //Access Column information by the DB column name as an index
                string ClassName = ResultSet["classname"].ToString();

                ClassNames.Add(ClassName);

            }


            return ClassNames;
        }



    }
}
