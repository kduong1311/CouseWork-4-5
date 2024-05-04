using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Mainform_and_login
{
    //Create enum for 3 role 
    public enum Role
    {
        Admin,
        Teacher,
        Student
    }
    //Father class Person
    public class Person
    {
        private int id;
        private string name;
        private string telephone;
        private string email;

        private Role role;
        private string password;

        //Constructor of the class
        public Person(int id, string name, string telephone, string email, Role role, string password)
        {
            this.id = id;
            this.name = name;
            this.telephone = telephone;
            this.email = email;
            this.role = role;
            this.password = password;
        }

        //Properties for all attributes
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }

        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public Role Role
        {
            get { return role; }
            set { role = value; }
        }

        public int ID { get { return id; } set {  id = value; } }

        static public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        //check email availability
        static public bool CheckIfUserExists(string email, string role)
        {
        DbConnect conn = new DbConnect();
        // count all the row have email and role equal typed email and role
        string query = "SELECT COUNT(*) FROM User_1 WHERE email = @Email AND role = @Role";
        SqlCommand command = new SqlCommand(query, conn.GetConnection());
        command.Parameters.AddWithValue("@Email", email);
        command.Parameters.AddWithValue("@Role", role);

        conn.OpenConnect();
        int count = (int)command.ExecuteScalar();
        if (count != 0)
            {
                return false;
            }

        else
            {
                return true;
            }
        }

        //Create hash password function for encypt password
        static public string HashPassword(string password)
        {
            //using hashBytes funcion of c# to autumatic hash password
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashedBytes = sha256.ComputeHash(passwordBytes);
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    stringBuilder.Append(hashedBytes[i].ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }

        static public bool AddMember(string name, string email, string telephone, string role, string password)
        {
            DbConnect conn = new DbConnect();
            conn.OpenConnect();
            //use hashed password to insert into database
            string hashpassword = Person.HashPassword(password);
            string query = "INSERT INTO User_1 (name, email, telephone, role, password) VALUES (@Name, @Email, @Telephone, @Role, @Password)";
            SqlCommand cmd = new SqlCommand(query, conn.GetConnection());

            // Add parameters with values
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Telephone", telephone);
            cmd.Parameters.AddWithValue("@Role", role);
            cmd.Parameters.AddWithValue("@Password", hashpassword); // Consider hashing password before storing

            // Execute the query
            int rowsAffected = cmd.ExecuteNonQuery();
            //if any row in database have been afftected
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        static public object GetUser()
        {
            //get connection
            DbConnect conn = new DbConnect();
            conn.OpenConnect();
            //select the last user (Because id is identity)
            SqlCommand cmd = new SqlCommand("SELECT MAX(id) FROM User_1", conn.GetConnection());
            //get count by ExcuteScalar
            object user_id = cmd.ExecuteScalar();
            return user_id;
        }
        public bool UpdateProfile(int id, string name, string email, string telephone)
        {
            DbConnect conn = new DbConnect();
            //update profile infomation query 
            string query_1 = @"UPDATE User_1 SET name = @name, telephone = @telephone, email = @email WHERE id = @id";
            SqlCommand cmd = new SqlCommand(query_1, conn.GetConnection());
            //sign variable for fake variable in query
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@telephone", telephone);

            conn.OpenConnect();
            if (cmd.ExecuteNonQuery() == 1)
            {
                conn.CloseConnect();
                return true;
            }
            else
            {
                conn.CloseConnect();
                return false;
            }
        }

        //Function for get user information to display in personal page
        public SqlDataReader getInfo(int id)    
        {
            DbConnect conn = new DbConnect();
            conn.OpenConnect();
            SqlCommand cmd = new SqlCommand("Select * from User_1 where id = @id", conn.GetConnection());
            cmd.Parameters.AddWithValue("@id", id);

            return cmd.ExecuteReader();
        }

        // Search function for search user when listing all
        public DataTable SearchBy(string search_field, string search_term, string role)
        {
            DbConnect conn = new DbConnect();
            conn.OpenConnect();
            string sql_query = $"SELECT id, name, email, telephone, role FROM User_1 WHERE {search_field} LIKE @search_term AND role = '{role}'";
            SqlCommand cmd = new SqlCommand(sql_query, conn.GetConnection());
            //sign value for variable in sql query
            cmd.Parameters.AddWithValue("@search_term", "%" + search_term + "%");

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);
                return datatable;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }

    //Create class Student inheritance class Person
    public class Student : Person
    {
        //Two attribute is two list to save 2 previous subject and current subject
        private string[] TwoPreSubject = new string[2];

        private string[] TwoCurSubject = new string[2];

        //Constructor
        public Student(int id, string name, string email, string telephone, Role role, string password,
            string cursub1, string cursub2, string presub1, string presub2) : base(id, name, telephone, email, role, password)
        {
            this.TwoPreSubject[0] = presub1;
            this.TwoPreSubject[1] = presub2;

            this.TwoCurSubject[0] = cursub1;
            this.TwoCurSubject[1] = cursub2;
        }
        //Properties for all attributes
        public string Cursub1
        {
            get { return TwoCurSubject[0]; }
            set { TwoCurSubject[0] = value; }
        }
        public string Cursub2
        {
            get { return TwoCurSubject[1]; }
            set { TwoCurSubject[1] = value; }
        }

        public string Presub1
        {
            get { return TwoPreSubject[0]; }
            set { TwoPreSubject[0] = value; }
        }

        public string Presub2
        {
            get { return TwoPreSubject[1]; }
            set { TwoPreSubject[1] = value; }
        }
    }

    //Create class Teacher inheritance Person class
    public class Teacher : Person
    {
        private double salary;
        private string[] TwoSubject = new string[2];


        public Teacher(int id, string name, string email, string telephone, Role role, string password,
            double salary, string subject1, string subject2) : base(id, name, telephone, email, role, password)
        {
            this.salary = salary;
            this.TwoSubject[0] = subject1;
            this.TwoSubject[1] = subject2;
        }

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        public string[] Subject
        {
            get { return TwoSubject; }
            set { TwoSubject = value; }

        }

        public string Subject1
        {
            get { return Subject[0]; }
            set { Subject[0] = value; }
        }

        public string Subject2
        {
            get { return Subject[1]; }
            set { Subject[1] = value; }
        }

        
    }

    public class Admin : Person

    {
        private double salary;
        private int workType;
        private int workHours;

        public Admin(int id, string name, string email, string telephone, Role role, string password,
            double salary, int workType, int workHours) : base(id, name, telephone, email, role, password)
        {
            this.salary = salary ;
            this.workType = workType;
            this.workHours = workHours;
        }

        public double Salary
        {
            get  { return salary;}
            set { salary = value; }
        }

        public int WorkType
        {
            get { return workType;}
            set { workType = value; }
        }

        public int WorkHours
        {
            get { return workHours;}
            set { workHours = value; }
        }

        

        //Update all Teacher's information
        public bool Update_Teacher(int id, string name, string email, string telephone, double salary, string subject1, string subject2)
        {
            DbConnect conn = new DbConnect();
            //Two query for two table User_1 and Teacher
            string query_1 = @"UPDATE User_1 SET name = @name, telephone = @telephone, email = @email WHERE id = @id";
            SqlCommand cmd = new SqlCommand(query_1, conn.GetConnection());

            string query_2 = @"UPDATE Teacher SET salary = @salary, subject1 = @subject1, subject2 = @subject2 WHERE user_id = @id";
            SqlCommand cmd2 = new SqlCommand(query_2, conn.GetConnection());

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@telephone", telephone);

            cmd2.Parameters.AddWithValue("@salary", salary);
            cmd2.Parameters.AddWithValue("@subject1", subject1);
            cmd2.Parameters.AddWithValue("@subject2", subject2);
            cmd2.Parameters.AddWithValue("@id", id);


            conn.OpenConnect();
            //If both two table are affected
            if (cmd.ExecuteNonQuery() == 1 && cmd2.ExecuteNonQuery() == 1)
            {
                conn.CloseConnect();
                return true;
            }
            else
            {
                conn.CloseConnect();
                return false;
            }

        }

        //Remove teacher function
        //Because have the constraint so must be remove in the foreign table first
        //and then remove from Reference table
        public bool RemoveTeacher(int id)
        {
            //Query for delete data from foreign table
            DbConnect conn = new DbConnect();
            string query2 = @"DELETE FROM Teacher WHERE user_id = @id";

            SqlCommand cmd2 = new SqlCommand(query2, conn.GetConnection());

            cmd2.Parameters.AddWithValue("@id", id);

            conn.OpenConnect();
            if (cmd2.ExecuteNonQuery() == 1)
            {
                //After delete successfully, delete from user table
                string query = @"DELETE FROM User_1 WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
                cmd.Parameters.AddWithValue("@id", id);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    conn.CloseConnect();
                    return true;
                }

                else
                {
                    conn.CloseConnect();
                    return false;
                }
            }
            else
            {
                conn.CloseConnect();
                return false;
            }
        }

        public DataTable getTeachers()
        {
            DbConnect conn = new DbConnect();
            conn.OpenConnect();
            DataTable table = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT id, name , email, telephone, subject1, subject2, salary FROM User_1 INNER JOIN Teacher ON User_1.id = Teacher.user_id WHERE role = 'Teacher'", conn.GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(table);
            return table;
        }

        public DataTable getStudents()
        {
            DbConnect conn = new DbConnect();
            conn.OpenConnect();
            DataTable table = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT id, name , email, telephone, pre_subject1, pre_subject2, cur_subject1, cur_subject2 FROM User_1 INNER JOIN Student ON User_1.id = Student.user_id WHERE role = 'Student'", conn.GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(table);
            return table;
        }

        public bool Update_Student(int id, string name, string email, string telephone, string pre_sub1, string pre_sub2, string cur_sub1, string cur_sub2)
        {
            //get connection
            DbConnect conn = new DbConnect();
            // 2 Query for update into two table User_1 and Student
            string query_1 = @"UPDATE User_1 SET name = @name, telephone = @telephone, email = @email WHERE id = @id";
            SqlCommand cmd = new SqlCommand(query_1, conn.GetConnection());

            string query_2 = @"UPDATE Student SET cur_subject1 = @cur1, cur_subject2 = @cur2, pre_subject1 = @pre1, pre_subject2 = @pre2 WHERE user_id = @id";
            SqlCommand cmd2 = new SqlCommand(query_2, conn.GetConnection());

            //Sign value for all variables in query
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@telephone", telephone);

            cmd2.Parameters.AddWithValue("@id", id);
            cmd2.Parameters.AddWithValue("@cur1", cur_sub1);
            cmd2.Parameters.AddWithValue("@cur2", cur_sub2);
            cmd2.Parameters.AddWithValue("@pre1", pre_sub1);
            cmd2.Parameters.AddWithValue("@pre2", pre_sub2);


            conn.OpenConnect();
            if (cmd.ExecuteNonQuery() == 1 && cmd2.ExecuteNonQuery() == 1)
            {
                conn.CloseConnect();
                return true;
            }
            else
            {
                conn.CloseConnect();
                return false;
            }

        }


        public bool RemoveStudent(int id)
        {
            DbConnect conn = new DbConnect();
            string query2 = @"DELETE FROM Student WHERE user_id = @id";

            SqlCommand cmd2 = new SqlCommand(query2, conn.GetConnection());

            cmd2.Parameters.AddWithValue("@id", id);

            conn.OpenConnect();
            if (cmd2.ExecuteNonQuery() == 1)
            {
                string query = @"DELETE FROM User_1 WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
                cmd.Parameters.AddWithValue("@id", id);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    conn.CloseConnect();
                    return true;
                }

                else
                {
                    conn.CloseConnect();
                    return false;
                }
            }
            else
            {
                conn.CloseConnect();
                return false;
            }
        }
    }

    // Create class to manage login class
    public class AuthManager
    {
        private static Person currentPerson;
        private static Teacher currentTeacher;
        private static Student currentStudent;
        private static Admin currentAdmin;


        //Add current user when this user logged in to system
        public static void Login(Person user)
        {
            currentPerson = user;
        }

        public static void Login_teacher(Teacher teacher)
        {
            currentTeacher = teacher;
        }

        public static void Login_Student(Student student)
        {
            currentStudent = student;
        }

        public static void Login_Admin(Admin admin)
        {
            currentAdmin = admin;
        }

        //Clear current user when logged out
        public static void Logout()
        {
            currentPerson = null;
        }

        public static void Logout_teacher()
        {
            currentTeacher = null;
        }

        public static void Logout_student()
        {
            currentStudent = null;
        }

        public static void Logout_Admin()
        {
            currentAdmin = null;
        }

        //Get current user logged in to user their attributes and methods
        public static Person GetCurrentPerson()
        {
            return currentPerson;
        }

        public static Teacher GetCurrentTeacher()
        {
            return currentTeacher;
        }

        public static Student GetCurrentStudent()
        {
            return currentStudent;
        }

        public static Admin GetCurrentAdmin()
        {
            return currentAdmin;
        }
    }

}
