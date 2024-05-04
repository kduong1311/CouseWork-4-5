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
    public partial class Student_Personal : Form
    {
        public Student_Personal()
        {
            InitializeComponent();
        }

        Student curstudent = AuthManager.GetCurrentStudent();
        private void Student_Personal_Load(object sender, EventArgs e)
        {
            if (curstudent != null)
            {
                txt_name.Text = curstudent.Name.ToString();
                txt_email.Text = curstudent.Email.ToString();
                txt_telephone.Text = curstudent.Telephone.ToString();
                txt_conPassword.PasswordChar = '*';
            }
        }

        private void btb_save_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("Do you want to Update your informations?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exit == DialogResult.Yes)
            {
                try
                {   if(curstudent != null)
                    {
                        if (txt_name.Text =="" || txt_email.Text ==""|| txt_telephone.Text =="" )
                        {
                            MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        int id = curstudent.ID;
                        string name = txt_name.Text;
                        string email = txt_email.Text;
                        string phone = txt_telephone.Text;

                        if (!(Person.CheckIfUserExists(email, "Student") || email == curstudent.Email))
                        {
                            MessageBox.Show("This email is available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;

                        }
                        if (Person.HashPassword(txt_conPassword.Text) == curstudent.Password.ToString())
                        {
                            if (curstudent.UpdateProfile(id, name, email, phone))
                            {
                                SqlDataReader reader = curstudent.getInfo(curstudent.ID);
                                while (reader.Read())
                                {
                                    txt_name.Text = reader["name"].ToString();
                                    txt_email.Text = reader["email"].ToString();
                                    txt_telephone.Text = reader["telephone"].ToString();
                                }

                                curstudent.Name = txt_name.Text.ToString();
                                curstudent.Email = txt_email.Text.ToString();
                                curstudent.Telephone = txt_telephone.Text.ToString();
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

        private void btn_logout_Click(object sender, EventArgs e)
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
            StudentPage page = new StudentPage();
            page.Show();
            this.Hide();
        }
    }
}
