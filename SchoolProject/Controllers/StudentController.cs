using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolProject.Models;
using MySql.Data.MySqlClient;

namespace SchoolProject.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Student/List
        public ActionResult List()
        {
            StudentDataController controller = new StudentDataController();
            IEnumerable<Student> Students = controller.ListStudents();
            return View(Students);
        }

        //GET : /Student/Show/{id}
        public ActionResult Show(uint id)
        {
            StudentDataController controller = new StudentDataController();
            Student NewStudent = controller.SearchStudent(id);

            return View(NewStudent);

        }
    }
}