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
    // this controller we will use to interact with the database
    // to get the data from the database and will pass it to the another controller
    public class TeachersDataController : ApiController
    {
        // database context to connect with database
        private SchoolDbContext SchoolDbContextObj = new SchoolDbContext();


        // controller to access teachers table in school database
        /// <summary>
        /// Returns a list of teachers
        /// </summary>
        /// <example>GET api/TeachersData/ListTeachers</example>
        /// <returns>
        /// A list of teachers (teacherid teacherfname teacherlname employeenumber hiredate salary)
        /// </returns>

        [HttpGet]
        [Route("api/teachersdata/listteachers")]
        public IEnumerable<Teacher> ListTeachers()
        {
            // MySqlConnection object from schooldbcontext accessdatabase method
            MySqlConnection Conn = SchoolDbContextObj.AccessDatabase();

            // open the connection to datbase server
            Conn.Open();

            // creating query to execute on the database
            MySqlCommand cmd = Conn.CreateCommand();

            // SQL query for the command
            cmd.CommandText = "SELECT * FROM teachers";

            // we need result set to store the result from the executed query
            // executing query and storing result in result set
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            // creating empty list of teachers 
            List<Teacher> TeachersList = new List<Teacher> { };

            while (ResultSet.Read())
            {
                // table col name from db. just for refrence
                // teacherid teacherfname teacherlname employeenumber hiredate salary
                // getting values from each result into variable

                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFirstName = ResultSet["teacherfname"].ToString();
                string TeacherLastName = ResultSet["teacherlname"].ToString();
                string EmployeeNumber = ResultSet["employeenumber"].ToString();
                DateTime HireDate = (DateTime)ResultSet["hiredate"];
                decimal Salary = Convert.ToDecimal(ResultSet["salary"]);


                // creating object of teacher to add it in TeachersInfo list
                Teacher newTeacher = new Teacher();

                // assigning value to newTeacher object
                newTeacher.TeacherId = TeacherId;
                newTeacher.TeacherFname = TeacherFirstName;
                newTeacher.TeacherLname = TeacherLastName;
                newTeacher.EmployeeNumber = EmployeeNumber;
                newTeacher.HireDate = HireDate;
                newTeacher.Salary = Salary;

                // adding newTeacher object into list of TeachersList
                TeachersList.Add(newTeacher);

            }



            // closing the connection to database
            Conn.Close();

            // returning list of all teachers
            return TeachersList;
        }



        /// <summary>
        /// returns teacher object based on given id
        /// </summary>
        /// <param name="id">id of teacher</param>
        /// <example>GET api/TeachersData/ListTeachers/FindTeacher/{id}</example>
        /// <returns>Teachers object with info of teacher with given id</returns>
        /// <example>GET api/TeachersData/ListTeachers/FindTeacher/3</example>
        /// <returns>T3822015-08-22T00:00:0060.22Linda3Chan</returns>

        [HttpGet]
        [Route("api/teachersdata/listteachers/findteacher/{id}")]
        public Teacher FindTeacher(int id)
        {
            
            // Mysql connection object from context to acess school db
            MySqlConnection Conn = SchoolDbContextObj.AccessDatabase();

            // open connection
            Conn.Open();

            // creating command for query
            MySqlCommand cmd = Conn.CreateCommand();

            // writing SQL query in command object
            cmd.CommandText = "SELECT * FROM teachers WHERE teacherid =" + id;

            // after executing we need result set to store result 
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            // creating teacher object to store data
            Teacher teacher = new Teacher();

            // now extracting data from result set
            while ( ResultSet.Read())
            {
                // creating variable to store data
                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFirstName = ResultSet["teacherfname"].ToString();
                string TeacherLastName = ResultSet["teacherlname"].ToString();
                string EmployeeNumber = ResultSet["employeenumber"].ToString();
                DateTime HireDate = (DateTime)ResultSet["hiredate"];
                decimal Salary = Convert.ToDecimal(ResultSet["salary"]);

                

                // assigning values to object
                teacher.TeacherId = TeacherId;
                teacher.TeacherFname = TeacherFirstName;
                teacher.TeacherLname = TeacherLastName;
                teacher.EmployeeNumber = EmployeeNumber;
                teacher.HireDate = HireDate;
                teacher.Salary = Salary;

            }

            // we have to close the connection and again open it to execute ExecuteReader
            Conn.Close();

            Conn.Open();

            // changing text command in cmd to get subject taught by teacher
            cmd.CommandText = "SELECT classname FROM classes WHERE teacherid = @key;";

            // sanitizing id for query
            cmd.Parameters.AddWithValue("@key", id);
            cmd.Prepare();

            // executing the query and storing the result in resultset
            ResultSet = cmd.ExecuteReader();


            while (ResultSet.Read())
            {
                // variables to store data from result set
                string className = ResultSet["classname"].ToString();

                teacher.ClassName = className;
            }

            //closing the connection
            Conn.Close();

            // return the teacher object

            return teacher;

        }

    }
}
