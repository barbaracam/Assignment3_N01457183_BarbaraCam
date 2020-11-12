using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolProject.Models
{
    public class Teacher
    {
        //The properties in this class define the Teacher Information
        //Using the convention of capital letter in Objects

        public int TeacherId;
        public string TeacherFname;
        public string TeacherLname;
        public DateTime TeacherHireDate;
        public decimal TeacherSalary;

    }
}