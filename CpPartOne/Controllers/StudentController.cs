using CpPartOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CpPartOne.Controllers
{
    public class StudentController : Controller
    {
        // GET: StudentData
        public ActionResult Index()
        {
            return View();
        }

        // GET Student/list
        public ActionResult List()
        {
            // creating object of studentdatacontroller to access methods from data controller
            StudentDataController controller = new StudentDataController();

            // storing return value of ListStudent() method which is list of students
            IEnumerable<Student> studentList = controller.ListStudent();

            // passing the student list to view
            return View(studentList);
        }

        // for search functionality
        // GET Student/list/searchKey
        public ActionResult SearchList(string searchInput)
        {
            // creating object of studentdatacontroller to access methods from data controller
            StudentDataController controller = new StudentDataController();

            // storing return value of ListStudent() method which is list of students
            IEnumerable<Student> studentList = controller.SearchStudent(searchInput);

            // passing the student list to view
            return View(studentList);
        }


        /// for detailed information about student
        // GET Student/show/{id}

        public ActionResult Show(uint id)
        {
            

            // creating object of studentdatacontroller to access methods from data controller
            StudentDataController controller = new StudentDataController();
            Student student = controller.ShowStudent(id);

            return View(student);
        }
    }
}