using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using SchoolProject.Models;


namespace SchoolProject.Controllers
{
    public class SchoolClassDataController : ApiController
    {
        //The database context class that allow access to the MySql Database.
        private SchoolDbContext School = new SchoolDbContext();

        [HttpGet]
        public IEnumerable<SchoolClass> ListSchoolClasses()
        {
            //Create a connection
            MySqlConnection Conn = School.AccessDatabase();
            
            //Open the conection between the WebServer and database
            Conn.Open();

            //Establish a new command Query for the DB
            MySqlCommand cmd = Conn.CreateCommand();

            //Sql Query
            cmd.CommandText = "Select * from Classes";

            //Gather Results Set of Query into variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of School Classes
            List<SchoolClass> SchoolClasses = new List<SchoolClass>{};

            //Loop each row the Result Set
            while(ResultSet.Read())
            {
                
                //Access column information by the DB column name by Index
                int SchoolClassId = (int)ResultSet["classid"];
                string SchoolClassName = (string)ResultSet["classname"];
                string SchoolClassCode = (string)ResultSet["classcode"];
                string SchoolTeacherId = ResultSet["teacherid"].ToString();

                SchoolClass NewSchoolClass = new SchoolClass();

                NewSchoolClass.SchoolClassId = SchoolClassId;
                NewSchoolClass.SchoolClassName = SchoolClassName;
                NewSchoolClass.SchoolClassCode = SchoolClassCode;
                NewSchoolClass.SchoolTeacherId = SchoolTeacherId;
                
                //Add the School Class Name to the list
                SchoolClasses.Add(NewSchoolClass);
            }
            //Close the connection between the MySql Db and WebServer
            Conn.Close();
            //Return the final List of Classes Name
            return SchoolClasses;
        }

        [HttpGet]
        public SchoolClass SearchSchoolClass(int id)
        {
            SchoolClass NewSchoolClass = new SchoolClass();

            //Create a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the conection between the WebServer and database
            Conn.Open();

            //Establish a new command Query for the DB
            MySqlCommand cmd = Conn.CreateCommand();

            //Sql Query
            cmd.CommandText = "Select * from Classes where classid = "+id;

            //Gather Results Set of Query into variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                int SchoolClassId = (int)ResultSet["classid"];
                string SchoolClassName = (string)ResultSet["classname"];
                string SchoolClassCode = (string)ResultSet["classcode"];
                string SchoolTeacherId = ResultSet["teacherid"].ToString();

                
                NewSchoolClass.SchoolClassId = SchoolClassId;
                NewSchoolClass.SchoolClassName = SchoolClassName;
                NewSchoolClass.SchoolClassCode = SchoolClassCode;
                NewSchoolClass.SchoolTeacherId = SchoolTeacherId;
            }

            //Close the connection between MySql Db and WebServer
            Conn.Close();

            //Return information about the specific class
            return NewSchoolClass;
        }
    }
}
