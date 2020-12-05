using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolProject.Models;
using System.Diagnostics;

namespace SchoolProject.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        // GET: Teacher/List
        public ActionResult List(string SearchKey = null)
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers(SearchKey);
            return View(Teachers);
        }

        //GET : /Teacher/Show/{id}
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher SelectedTeacher = controller.SearchTeacher(id);


            return View(SelectedTeacher);

        }

        //GET : /Teacher/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.SearchTeacher(id);


            return View(NewTeacher);

        }

        //Post : /Teacher/Delete/{id}

        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);
            return RedirectToAction("List");
        }

        //Get : /Teacher/New
        public ActionResult Add()
        {
            return View();
        }

        //Post : /Teacher/Create
        [HttpPost]
        public ActionResult Create(string TeacherFname, string TeacherLname, DateTime TeacherHireDate, decimal TeacherSalary)
        {
            //Identify the information provided from the forms

            Debug.WriteLine("The access to the create method");
            Debug.WriteLine(TeacherFname);
            Debug.WriteLine(TeacherLname);
            Debug.WriteLine(TeacherHireDate);
            Debug.WriteLine(TeacherSalary);

            if (TeacherFname == "") return RedirectToAction("Add");
            if (TeacherLname == "") return RedirectToAction("Add");
            

            Teacher NewTeacher = new Teacher();
            NewTeacher.TeacherFname = TeacherFname;
            NewTeacher.TeacherLname = TeacherLname;
            NewTeacher.TeacherHireDate = TeacherHireDate;
            NewTeacher.TeacherSalary = TeacherSalary;

            TeacherDataController controller = new TeacherDataController();
            controller.AddTeacher(NewTeacher);

            return RedirectToAction("List");
        }


        /// <summary>
        /// Dynamically "Teacher Update"
        /// </summary>
        /// <param name="id">Get The information from the databse through the Teacher ID</param>
        /// <returns>Dynamic Teacher date with the current information and ask for new information</returns>
        /// <example> Get : /Teacher/Update/{id}</example>


        public ActionResult Update(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher SelectedTeacher = controller.SearchTeacher(id);
            return View(SelectedTeacher);
        }

        /// <summary>
        /// Receives a a Post request, updating the teachers values.
        /// </summary>
        /// <param name="id">Id of the Teacher to update</param>
        /// <param name="TeacherFname">New values for the First Name to be updated</param>
        /// <param name="TeacherLname">New values for the Last Name to be updated</param>
        /// <param name="TeacherHireDate">New values for the Teacher Hire Date to be updated</param>
        /// <param name="TeacherSalary">New values for the Teacher Salary to be updated</param>
        /// <returns>Dynamic Teacher date with the current information and ask for new information</returns>
        /// <example>
        /// Post : /Teacher/Update/20
        /// FORM DATA / POST DATA/ REQUEST BODY
        /// {
        /// "TeacherFname":"Barbara"
        /// "TeacherLname":"Cam"
        /// "TeacherHireDate":""
        /// "TeacherSalary":"20.22"
        /// }
        /// </example>
        [HttpPost]
        public ActionResult Update(int id, string TeacherFname, string TeacherLname, DateTime TeacherHireDate, decimal TeacherSalary)
        {
            if (TeacherFname == "") return RedirectToAction("Update");
            if (TeacherLname == "") return RedirectToAction("Update");

            Teacher TeacherInfo = new Teacher();
            TeacherInfo.TeacherFname = TeacherFname;
            TeacherInfo.TeacherLname = TeacherLname;
            TeacherInfo.TeacherHireDate = TeacherHireDate;
            TeacherInfo.TeacherSalary = TeacherSalary;

            TeacherDataController controller = new TeacherDataController();
            controller.UpdateTeacher(id,TeacherInfo);

            return RedirectToAction("Show/" + id);
        }





    }
}