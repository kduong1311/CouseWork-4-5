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
    public partial class Teacher_profile : Form
    {
        public Teacher_profile()
        {
            InitializeComponent();
        }
        Teacher currTeacher = AuthManager.GetCurrentTeacher();

        private void Teacher_profile_Load(object sender, EventArgs e)
        {
            if (currTeacher != null)
            {
                txt_name.Text = currTeacher.Name.ToString();
                txt_email.Text = currTeacher.Email.ToString();
                txt_telephone.Text = currTeacher.Telephone.ToString();
                txt_conPassword.PasswordChar = '*';
            }
        }

        private void btb_save_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("Do you want to Update your informations?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exit == DialogResult.Yes)
            {
                try
                {
                    if (currTeacher != null)
                    {
                        if (txt_name.Text == "" || txt_email.Text == "" || txt_telephone.Text == "")
                        {
                            MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        int id = currTeacher.ID;
                        string name = txt_name.Text;
                        string email = txt_email.Text;
                        string phone = txt_telephone.Text;

                        if (!(Person.CheckIfUserExists(email, "Teacher") || email == currTeacher.Email))
                        {
                            MessageBox.Show("This email is available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;

                        }
                        if (Person.HashPassword(txt_conPassword.Text) == currTeacher.Password.ToString())
                        {
                            if (currTeacher.UpdateProfile(id, name, email, phone))
                            {
                                SqlDataReader reader = currTeacher.getInfo(currTeacher.ID);
                                while (reader.Read())
                                {
                                    txt_name.Text = reader["name"].ToString();
                                    txt_email.Text = reader["email"].ToString();
                                    txt_telephone.Text = reader["telephone"].ToString();
                                }

                                currTeacher.Name = txt_name.Text.ToString();
                                currTeacher.Email = txt_email.Text.ToString();
                                currTeacher.Telephone = txt_telephone.Text.ToString();

                            }
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Confirm password!");
                        }
                    }      
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("Do you want to LogOut?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exit == DialogResult.Yes)
            {
                AuthManager.Logout_teacher();
                login_form login_Form = new login_form();
                login_Form.Show();
                this.Close();
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            TeacherPage page = new TeacherPage();
            page.Show();
            this.Hide();
        }
    }
}
