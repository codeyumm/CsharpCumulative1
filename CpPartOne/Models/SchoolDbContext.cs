using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CpPartOne.Models
{
    public class SchoolDbContext 
    {
        // creating private propertiies for connection string
        // adding only get so it will be read only
        // using static so that we can use proprties wihtout any object creation

        private static string User { get { return "root"; } }
        private static string Password { get { return "root";  } }
        private static string Database { get { return "school"; } }
        private static string Server { get { return "localhost";  } }
        private static string Port { get { return "3306";  } }

        
        // using protected for connection string so other class can use it
        protected static string ConnectionString
        {
            get
            {
                return "server=" + Server 
                    + ";user=" + User 
                    + ";database=" + Database 
                    + ";port=" + Port 
                    + ";password=" + Password 
                    + "; convert zero datetime = True";
            }
        }

        // creating method which return the connection to database as a object

        /// <summary>
        /// returns object of mysqlconnection (connnection object)
        /// </summary>
        /// 
        /// <example>
        /// private SchoolDbContext SchoolDbContextObj = new SchoolDbContext();
        /// MySqlConnection con = SchoolDbContextObj.AccessDatabase();
        /// </example>
        /// 
        /// <return>
        /// MysqlConnection Object
        /// </return>
        /// 

        public MySqlConnection AccessDatabase()
        {
            // we are passing the connection string from which mysqlconnection get to know 
            // which server, database to connect on which port with credential
            // here it will connect to localhost on port 3306 on school db
            // returns the MySqlConnection object that we can use it further 

            return new MySqlConnection(ConnectionString);
        }

    }
}