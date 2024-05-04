using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mainform_and_login
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }
        
        private void btn_login_Click(object sender, EventArgs e)
        {
            login_form login = new login_form();
            login.Show();
            this.Hide();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            // Connect to the database
            DbConnect conn = new DbConnect();
            conn.OpenConnect();
            //Get data from textbox is typed by user
            string name = txt_name.Text.Trim();
            string email = txt_email.Text.Trim();
            string telephone = txt_telephone.Text.Trim();
            string role_1 = txt_role.SelectedItem?.ToString(); 
            string password = txt_password1.Text;
            string password2 = txt_password2.Text;

            //Empty checking, If required text boxes are left blank, the system will report an error
            //return will prevent further execution of the remaining lines of code
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(telephone) || string.IsNullOrEmpty(role_1)
                || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Check the email format, if the email is entered in the wrong format, an error will be reported
            if (!(Person.IsValidEmail(email)))
            {
                MessageBox.Show("Enter valid format for email, please", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //CHeck confirm password == password to sign up
            if (password != password2)
            {
                MessageBox.Show("Confirmation password is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                //Check email availability, if have one in database, It will prevent sign up
                if (Person.CheckIfUserExists(email, role_1))
                {
                    string hashpassword = Person.HashPassword(password);
                    string query = "INSERT INTO User_1 (Name, Email, Telephone, Role, Password) VALUES (@Name, @Email, @Telephone, @Role, @Password)";
                    SqlCommand cmd = new SqlCommand(query, conn.GetConnection());

                    // Add parameters with values
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Telephone", telephone);
                    cmd.Parameters.AddWithValue("@Role", role_1);
                    cmd.Parameters.AddWithValue("@Password", hashpassword); // Consider hashing password before storing

                    // Execute the query
                    int rowsAffected = cmd.ExecuteNonQuery();
                    //If add new user successfully
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Registration successful! Back to Login page to Login");
                        txt_name.Clear();
                        txt_email.Clear();
                        txt_telephone.Clear();
                        txt_password1.Clear();
                        txt_password2.Clear();

                        //Get the user just registered
                        int id = Convert.ToInt32(Admin.GetUser());
                        //Insert the infomation for this users in their table for each role
                        //Because normal user cannot self set the education information so system auto insert the empty string
                        if (role_1 == "Teacher")
                        {
                            SqlCommand cmd3 = new SqlCommand("INSERT INTO Teacher (salary, subject1, subject2, user_id) values (0, '', '',@id)", conn.GetConnection());
                            cmd3.Parameters.AddWithValue("@id", id);
                            cmd3.ExecuteNonQuery();
                        }

                        if (role_1 == "Student")
                        {
                            SqlCommand cmd3 = new SqlCommand("INSERT INTO Student (user_id) values (@id)", conn.GetConnection());
                            cmd3.Parameters.AddWithValue("@id", id);
                            cmd3.ExecuteNonQuery();
                        }

                    }
                    //If no any row have affected
                    else
                    {
                        MessageBox.Show("Registration failed. Please try again.");
                    }
                }

                else
                {
                    MessageBox.Show($"Email: {email} is Available");
                }


                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Registration error: " + ex.Message);
            }
            finally
            {
                conn.CloseConnect();
            }
        }
        
        //show password 
        private void btn_showPass_CheckedChanged(object sender, EventArgs e)
        {
            txt_password2.UseSystemPasswordChar= !btn_showPass.Checked;
            txt_password1.UseSystemPasswordChar = !btn_showPass.Checked;
        }

        private void exit_x_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
