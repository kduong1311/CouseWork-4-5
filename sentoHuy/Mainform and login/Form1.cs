using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Mainform_and_login._CourseWork_6_4DataSet;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Mainform_and_login
{
    public partial class login_form : Form
    {
        
        public login_form()
        {
            InitializeComponent();
        }

        DbConnect conn = new DbConnect();
        //Exit function
        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("Do you want to exit the application", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exit == DialogResult.Yes)
            {
                Application.Exit();

            }
        }
        //Show password function
        private void btn_showPass_CheckedChanged(object sender, EventArgs e)
        {
            txt_loginPassword.UseSystemPasswordChar = !btn_showPass.Checked;
        }

        private void btn_regis_Click(object sender, EventArgs e)
        {
            //foward to registration Page
            Registration createAccount = new Registration();
            createAccount.Show();
            this.Hide();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            //Get data from textbox
            string email = txt_loginEmail.Text;
            string password = txt_loginPassword.Text;
            string role = txt_role.SelectedItem?.ToString();
            string hashpassword = Person.HashPassword(password);
            //check if user did not choose any role
            if (string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Select one role, Please!!", "Error", MessageBoxButtons.OK);
                return;
            }

            try
            {
                conn.OpenConnect();
                //Check email vs password and role in database
                string query = "SELECT COUNT(*) FROM User_1 WHERE email = @email AND password = @password AND role = @role";
                SqlCommand command = new SqlCommand(query, conn.GetConnection());
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", hashpassword);
                command.Parameters.AddWithValue("@role", role);


                int count = (int)command.ExecuteScalar();
                //If login information is valid
                if (count > 0)
                {
                    //Get information from database for each login user and create new object
                    if (role == "Teacher") 
                    {
                        SqlCommand cmd2 = new SqlCommand("SELECT user_id, name, " +
                            "email, telephone, role, password, salary, subject1, subject2 FROM User_1 Inner join Teacher on Teacher.user_id = User_1.id WHERE email = @email AND role = 'Teacher'", conn.GetConnection());
                        cmd2.Parameters.AddWithValue("@email", email);
                        SqlDataReader reader1 = cmd2.ExecuteReader();
                        while (reader1.Read())
                        {
                            int id = Convert.ToInt32(reader1["user_id"].ToString());
                            string name = reader1["name"].ToString();
                            string email1 = reader1["email"].ToString();
                            string telephone = reader1["telephone"].ToString();
                            string role1 = reader1["role"].ToString();
                            string password1 = reader1["password"].ToString();
                            double salary = Convert.ToDouble(reader1["salary"]);
                            string sub1 = reader1["subject1"].ToString();
                            string sub2 = reader1["subject2"].ToString();
                            Role userRole = (Role)Enum.Parse(typeof(Role), role1);

                            //Create Teacher object after get datafrom database, add to AuthManager class
                            Teacher teacher_login = new Teacher(id, name, email1, telephone, userRole, password1, salary, sub1, sub2);
                            AuthManager.Login_teacher(teacher_login);
                            //forward to Teacher Page
                            TeacherPage teacherPage = new TeacherPage();
                            teacherPage.Show();
                            this.Hide();
                        }
                    }

                    if (role == "Student")
                    {
                        SqlCommand cmd2 = new SqlCommand("SELECT user_id, name, " +
                            "email, telephone, role, password, pre_subject1, pre_subject2, cur_subject1, cur_subject2 FROM User_1 Inner join Student on Student.user_id = User_1.id WHERE email = @email AND role = 'Student'", conn.GetConnection());
                        cmd2.Parameters.AddWithValue("@email", email);
                        SqlDataReader reader1 = cmd2.ExecuteReader();
                        while (reader1.Read())
                        {
                            int id = Convert.ToInt32(reader1["user_id"].ToString());
                            string name = reader1["name"].ToString();
                            string email1 = reader1["email"].ToString();
                            string telephone = reader1["telephone"].ToString();
                            string role1 = reader1["role"].ToString();
                            string password1 = reader1["password"].ToString();
                            string pre_subject1 = reader1["pre_subject1"].ToString();
                            string pre_subject2 = reader1["pre_subject2"].ToString();
                            string cur_subject1 = reader1["cur_subject1"].ToString();
                            string cur_subject2 = reader1["cur_subject2"].ToString();

                            Role userRole = (Role)Enum.Parse(typeof(Role), role1);
                            //Get data from data base and create a new Student object and add to AuthManager class
                            Student student_login = new Student(id, name, email1, telephone, userRole, password1, cur_subject1,cur_subject2, pre_subject1, pre_subject2);
                            AuthManager.Login_Student(student_login);
                            StudentPage student = new StudentPage();
                            student.Show();
                            this.Hide();
                        }
                    }

                    if (role == "Admin")
                    {
                        SqlCommand cmd2 = new SqlCommand("SELECT user_id, name, " +
                            "email, telephone, role, password, salary, workType, worHours FROM User_1 Inner join Admin on Admin.user_id = User_1.id WHERE email = @email AND role = 'Admin'", conn.GetConnection());
                        cmd2.Parameters.AddWithValue("@email", email);
                        SqlDataReader reader1 = cmd2.ExecuteReader();
                        while (reader1.Read())
                        {
                            int id = Convert.ToInt32(reader1["user_id"].ToString());
                            string name = reader1["name"].ToString();
                            string email1 = reader1["email"].ToString();
                            string telephone = reader1["telephone"].ToString();
                            string role1 = reader1["role"].ToString();
                            string password1 = reader1["password"].ToString();
                            int workType = (int)reader1["workType"];
                            int workHourse = (int)reader1["worHours"];
                            double salary = Convert.ToDouble(reader1["salary"]);

                            Role userRole = (Role)Enum.Parse(typeof(Role), role1);

                            Admin admin_login = new Admin(id, name, email1, telephone, userRole, password1, salary, workType, workHourse);
                            AuthManager.Login_Admin(admin_login);

                            Admin_home admin_home = new Admin_home();
                            admin_home.Show();
                            this.Hide();
                        }
                    }

                }

                else
                {
                    //Invalid email or Password
                    MessageBox.Show("Invalid email or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_loginEmail.Focus();
                }
               
            }

            catch(Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

            finally
            {
                conn.CloseConnect();
            }
        }

    }
}
