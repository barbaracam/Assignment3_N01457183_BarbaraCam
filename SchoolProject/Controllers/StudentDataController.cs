using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolProject.Models;
using MySql.Data.MySqlClient;

namespace SchoolProject.Controllers
{
    public class StudentDataController : ApiController
    {
        private SchoolDbContext School = new SchoolDbContext();

        //This Controller Will access the student table of our school database.
        /// <summary>
        /// Returns a list of Students in the system
        /// </summary>
        /// <example>GET api/StudentData/ListStudent</example>
        /// <returns>
        /// A list of Student (first names and last names)
        /// </returns>

        [HttpGet]
        public IEnumerable<Student> ListStudents()
        {
            // Create a connection
            MySqlConnection Conn = School.AccessDatabase();

            // Create a connection between the server and the database
            Conn.Open();

            //Set a new command for the student database(query)
            MySqlCommand cmd = Conn.CreateCommand();

            // SQL for the student table
            cmd.CommandText = "Select * from Students";

            //Collect the data from our query and make it a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create a empty list of Students
            List<Student> Students = new List<Student>{};

            //Loop each row from the table
            while (ResultSet.Read())
            {
                //Acces column information by the column name as an index
                uint StudentId = (uint)ResultSet["Studentid"];
                string StudentFname = (string)ResultSet["Studentfname"];
                string StudentLname = (string)ResultSet["Studentlname"];
                string StudentNumber = (string)ResultSet["Studentnumber"];

                Student NewStudent = new Student();
                NewStudent.StudentId = StudentId;
                NewStudent.StudentFname = StudentFname;
                NewStudent.StudentLname = StudentLname;
                NewStudent.StudentNumber = StudentNumber;

                //Add the Student Name to the list
                Students.Add(NewStudent);
            }

            //Close connection between Database and Webserver
            Conn.Close();

            //Return the final List of Student Name
            return Students;
        }

        [HttpGet]
        public Student SearchStudent(uint id)
        {
            Student NewStudent = new Student();

            // Create a connection
            MySqlConnection Conn = School.AccessDatabase();

            // Create a connection between the server and the database
            Conn.Open();

            //Set a new command for the student database(query)
            MySqlCommand cmd = Conn.CreateCommand();

            // SQL for a student according the student id
            cmd.CommandText = "Select * from Students where studentid = " +id;

            //Collect the data from our query and make it a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Acces column information by the column name as an index
                uint StudentId = (uint)ResultSet["Studentid"];
                string StudentFname = (string)ResultSet["Studentfname"];
                string StudentLname = (string)ResultSet["Studentlname"];
                string StudentNumber = (string)ResultSet["Studentnumber"];

                NewStudent.StudentId = StudentId;
                NewStudent.StudentFname = StudentFname;
                NewStudent.StudentLname = StudentLname;
                NewStudent.StudentNumber = StudentNumber;

            }

            //Close the connection between MySql Db and WebServer
            Conn.Close();

            //Return information about the specific class
            return NewStudent;
        }

    }

}