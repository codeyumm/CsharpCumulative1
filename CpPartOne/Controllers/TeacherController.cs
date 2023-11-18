using CpPartOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CpPartOne.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        // GET: Teacher/list
        public ActionResult List()
        {
            TeachersDataController dataController = new TeachersDataController();
            IEnumerable<Teacher> teachersList = dataController.ListTeachers();

            return View(teachersList);
        }

        // GET: Teacher/show/{id}
        public ActionResult Show(int id)
        {
           
            TeachersDataController dataController = new TeachersDataController();
            Teacher teacher = dataController.FindTeacher(id);

            return View(teacher);
        }
    }
}