using CpPartOne.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CpPartOne.Controllers
{
    public class StudentDataController : ApiController
    {
        // SchoolDbContext to connect with database
        SchoolDbContext SchoolDbContextObj = new SchoolDbContext();

        [HttpGet]
        [Route("api/StudentData/ListStudent")]

        /// controller to access student data
        /// 
        /// <summary>
        /// Returns a list of student
        /// </summary>
        /// <example>GET api/StudentData/ListStudent</example>
        /// <returns>
        /// A list of student
        /// </returns>
 
        public IEnumerable<Student> ListStudent()
        {
            // MySqlConnection object which we get from SchoolDbContext to connect database
            MySqlConnection Conn = SchoolDbContextObj.AccessDatabase();

            // open the connection
            Conn.Open();

            // we need create a command to execute sql query
            MySqlCommand cmd = Conn.CreateCommand();

            // assigning text to command for query
            cmd.CommandText = "SELECT * FROM students;";

            // executing command and storing the result in resultset
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            // making enumerable object of student model
            // so we can store multiple student's data 
            List<Student> students = new List <Student>{ };

            // reading result from resultset
            while( ResultSet.Read())
            {
                /// studentid studentfname    studentlname studentnumber   enroldate
          
                // for the database we can get to know about datatypes
                // in db studntId is unsigned int so using uint here
                uint studentId = (uint)ResultSet["studentid"];
                string firstName = ResultSet["studentfname"].ToString();
                string lastName = ResultSet["studentlname"].ToString();
                string studentNumber = ResultSet["studentnumber"].ToString();
                DateTime enrolDate = (DateTime)ResultSet["enroldate"];

                // creating new student object to store the data
                Student newStudent = new Student();

                // assigning newStudent object's variable with the data that we got from table
                newStudent.StudentId = studentId;
                newStudent.StudentFirstName = firstName;
                newStudent.StudentLastName = lastName;
                newStudent.StudentNumber = studentNumber;
                newStudent.StudentEnrollDate = enrolDate;

                // adding newStudent object in student list
                students.Add(newStudent);
            }

            return students;
        }

        /// controller to access specific student data by an id of student
        /// 
        /// <summary>
        /// Returns a student of a givent id
        /// </summary>
        /// <example>GET api/showstudent/{id}</example>
        /// <returns>
        /// A student object containing info 
        /// </returns>

        [HttpGet]
        [Route("api/studentdata/showstudent/{id}")]

        public Student ShowStudent(uint id)
        {
            // getting mysqlconnection object to open the connection with db
            MySqlConnection Conn = SchoolDbContextObj.AccessDatabase();

            // open the connection
            Conn.Open();

            // creating command object for query
            MySqlCommand cmd = Conn.CreateCommand();

            // writing query for command
            cmd.CommandText = "SELECT * FROM students WHERE studentid = @key;";

            // sanitizing id for query
            cmd.Parameters.AddWithValue("@key", id);
            cmd.Prepare();

            // result set to store the data
            // executing query
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            // creating student object to store data
            Student student = new Student();

            while( ResultSet.Read())
            {
                // storing data in student object

                student.StudentFirstName = ResultSet["studentfname"].ToString();
                student.StudentLastName = ResultSet["studentlname"].ToString();
                student.StudentNumber = ResultSet["studentnumber"].ToString();
                student.StudentEnrollDate = (DateTime)ResultSet["enroldate"];

            }

            // return student object to controller
            return student;
        }

        [HttpGet]
        [Route("api/studentdata/searchStudent/{searchKey}")]
        public IEnumerable<Student> SearchStudent(string searchInput)
        {
            // connection object
            MySqlConnection Conn = SchoolDbContextObj.AccessDatabase();


            // open the connection
            Conn.Open();

            // creating command for query
            MySqlCommand cmd = Conn.CreateCommand();

            // writing query in command object
            cmd.CommandText = 
                "SELECT * FROM students WHERE studentfname LIKE @key OR studentlname LIKE @key;";

            // sanitizing the query
            // cmd.Parameters.AddWithValue("@key", "%" + SearchKey + "%");
            cmd.Parameters.AddWithValue("@key", "%" + searchInput + "%");
            cmd.Prepare();

            // we need datareader object to store the result of query
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            // getting data from result set
            List<Student> studentList = new List<Student> { };
            while ( ResultSet.Read())
            {
                uint studentId = (uint)ResultSet["studentid"];
                string firstName = ResultSet["studentfname"].ToString();
                string lastName = ResultSet["studentlname"].ToString();
                string studentNumber = ResultSet["studentnumber"].ToString();
                DateTime enrolDate = (DateTime)ResultSet["enroldate"];

                // creating new student object to store the data
                Student newStudent = new Student();

                // assigning newStudent object's variable with the data that we got from table
                newStudent.StudentId = studentId;
                newStudent.StudentFirstName = firstName;
                newStudent.StudentLastName = lastName;
                newStudent.StudentNumber = studentNumber;
                newStudent.StudentEnrollDate = enrolDate;

                // adding newStudent object in student list
                studentList.Add(newStudent);

            }
            return studentList;

        }
    }
}
