using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CpPartOne.Models
{
    public class Student
    {
        // columns in student table in db
        // studentid studentfname    studentlname studentnumber   enroldate
        // making model so that we can easily store data from result set

        public uint StudentId;
        public string StudentFirstName;
        public string StudentLastName;
        public string StudentNumber;
        public DateTime StudentEnrollDate;

    }
}