using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CpPartOne.Models
{
    public class Teacher
    {
        // field that defined teachers
        public int TeacherId;
        public string TeacherFname;
        public string TeacherLname;
        public string EmployeeNumber;
        public DateTime HireDate;
        public decimal Salary;

        // field not from teachers table but related to teacher
        public string ClassName;
    }
}