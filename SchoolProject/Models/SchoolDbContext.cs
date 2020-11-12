using MySql.Data.MySqlClient;

namespace SchoolProject.Models
{
    public class SchoolDbContext
    {

         
        //Only the SchoolDbContext class can use them.
        
        private static string User { get { return "root"; } }
        private static string Password { get { return "root"; } }
        private static string Database { get { return "school"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3306"; } }

        //Connection String in Order to connect to the database

        protected static string ConnectionString
        {
            get
            {
                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password;
            }
        }

        /// Method to get the database
        /// <summary>
        /// Return a connection to the blog database
        /// </summary>
        /// <example> private SchoolDbContext School = New SchoolDbContext();
        /// MySqlConnection Conn = Blog.AccessDatabase();
        /// </example>
        /// <returns>MySqlConnection Object</returns>

        public MySqlConnection AccessDatabase()
        {
            //Initiating the MySqlConnection Class to create an object
            //The objects is a specific connection to our school database port 3306
            return new MySqlConnection(ConnectionString);
        }

    }
}