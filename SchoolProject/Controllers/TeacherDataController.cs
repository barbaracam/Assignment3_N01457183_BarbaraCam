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
    public class TeacherDataController : ApiController
    {   //The database context to access MySql
        private SchoolDbContext School = new SchoolDbContext();
        ///This controller will access the Teacher table from the school database
        /// <summary>
        /// Return a list of Teachers in the System
        /// </summary>
        /// <example>Get api/TeacherData/ListTeachers</example>
        /// <returns>A list of teachers (last name and first name)</returns>

        [HttpGet]
        [Route("api/TeacherData/ListTeachers/{SearchKey?}")]
        public IEnumerable<Teacher> ListTeachers(string Searchkey = null)
        {
            // Create a connection
            MySqlConnection Conn = School.AccessDatabase();

            // Create a connection between the server and the database
            Conn.Open(); 
            
            //Set a new command for the teacher database(query)
            MySqlCommand cmd = Conn.CreateCommand();

            // SQL for the teachers table
            cmd.CommandText = "SELECT * from teachers where lower(teacherfname) like lower(@key) or lower(teacherlname) like lower(@key) or lower (concat(teacherfname, ' ', teacherlname)) like lower(@key) or (salary) like (@key) or(hiredate) like (@key)";
            cmd.Parameters.AddWithValue("@key", "%" + Searchkey + "%");
            cmd.Prepare();

            //Collect the data from our query and make it a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();  

            //Create a empty list of Teachers
            List<Teacher> Teachers = new List<Teacher>{};
                
            //Loop each row from the table
            while (ResultSet.Read())
            {
                //Acces column information by the column name as an index
                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFname = (string)ResultSet["teacherfname"];
                string TeacherLname = (string)ResultSet["teacherlname"];
                DateTime TeacherHireDate = (DateTime)ResultSet["hiredate"];
                decimal TeacherSalary = (decimal)ResultSet["salary"];
                    //New instation of the teacher class
                Teacher NewTeacher = new Teacher();
                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.TeacherHireDate = TeacherHireDate;
                NewTeacher.TeacherSalary = TeacherSalary;

                //Add the Teacher Name to the list
                Teachers.Add(NewTeacher); 
            }

            //Close connection between Database and Webserver
            Conn.Close();
            //Return the final list of teacher names
            return Teachers;
        }
        [HttpGet]
        public Teacher SearchTeacher(int id)
        {
            Teacher NewTeacher = new Teacher();

            // Create a connection
            MySqlConnection Conn = School.AccessDatabase();

            // Create a connection between the server and the database
            Conn.Open();

            //Set a new command for the teacher database(query)
            MySqlCommand cmd = Conn.CreateCommand();

            // SQL for the teachers table by an specific id
            cmd.CommandText = "SELECT * from teachers where teacherid = " +id;

            //Collect the data from our query and make it a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Acces information by id(index)
                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFname = (string)ResultSet["teacherfname"];
                string TeacherLname = (string)ResultSet["teacherlname"];
                DateTime TeacherHireDate = (DateTime)ResultSet["hiredate"];
                Decimal TeacherSalary = (decimal)ResultSet["salary"];

                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.TeacherHireDate = TeacherHireDate;
                NewTeacher.TeacherSalary = TeacherSalary;

            }
            //Close the connection between MySql Db and WebServer
            Conn.Close();

            return NewTeacher;
            //Return information about the specific teacher
        }



    }

}
