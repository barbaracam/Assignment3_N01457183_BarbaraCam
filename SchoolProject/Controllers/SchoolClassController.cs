using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using SchoolProject.Models;

namespace SchoolProject.Controllers
{
    public class SchoolClassController : Controller
    {
        // GET: SchoolClass
        public ActionResult Index()
        {
            return View();
        }

        //Get: /SchoolClasses/List
        public ActionResult List()
        {
            SchoolClassDataController controller = new SchoolClassDataController();
            IEnumerable<SchoolClass>SchoolClasses = controller.ListSchoolClasses();
            return View(SchoolClasses);
        }

        //Get : SchoolClasses/Show/{id}
        public ActionResult Show(int id)
        {
            SchoolClassDataController controller = new SchoolClassDataController();
            SchoolClass NewSchoolClass = controller.SearchSchoolClass(id);
            
            return View(NewSchoolClass);
        }


    }
}