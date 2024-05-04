using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace Mainform_and_login
{
    internal class DbConnect
    {
        //Create sqlconnecttion with connection string
        static string currentDirectory = Path.Combine(Directory.GetCurrentDirectory(), "..", "..");
        static string fullPath = Path.GetFullPath(currentDirectory);
        static public string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={fullPath}\Database1.mdf;Integrated Security=True;";
        SqlConnection sqlconn = new SqlConnection(connectionString);
        //SqlConnection sqlconn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\OneDrive\\Greenwich-SUBJECTS\\2024\\App - Dev - COMP 1551\\CWcodefile - Copy\\Mainform and login\\Database1.mdf\";Integrated Security=True");
        public SqlConnection GetConnection()
        {
            return sqlconn;
        }
        //Open connect if state is close
        public void OpenConnect()
        {
            if (sqlconn.State != ConnectionState.Open)
            {
                sqlconn.Open();
            }
        }
        //Close connect if state is open
        public void CloseConnect()
        {
            if(sqlconn.State != ConnectionState.Closed)
            { sqlconn.Close(); }
        }
    }
}
