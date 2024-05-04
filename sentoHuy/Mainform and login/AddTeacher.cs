﻿using System;
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
    public partial class AddTeacher : Form
    {
        public AddTeacher()
        {
            InitializeComponent();
        }

        Admin currentAdmin = AuthManager.GetCurrentAdmin();
        private void btb_save_Click(object sender, EventArgs e)
        {
            DbConnect conn = new DbConnect();
            conn.OpenConnect();
            string name = txt_name.Text.Trim();
            string email = txt_email.Text.Trim();
            string telephone = txt_telephone.Text.Trim();
            string password = txt_password.Text;
            string role = "Teacher";

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(telephone)
                || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!(Person.IsValidEmail(email)))
            {
                MessageBox.Show("Enter valid format for email, please", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Person.CheckIfUserExists(email, role))
            {
                if (Person.AddMember(name, email, telephone, role, password))
                {
                    MessageBox.Show($"Adding Successfully: Teacher: {name} ");
                    txt_name.Clear();
                    txt_email.Clear();
                    txt_telephone.Clear();
                    txt_password.Clear();

                    int id = Convert.ToInt32(Admin.GetUser());
                    SqlCommand cmd3 = new SqlCommand("INSERT INTO Teacher (salary, subject1, subject2, user_id) values (0, '', '',@id)", conn.GetConnection());
                    cmd3.Parameters.AddWithValue("@id", id);
                    cmd3.ExecuteNonQuery();
                }

                else
                {
                    MessageBox.Show("Add Teacher Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("This email is available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_all_Click(object sender, EventArgs e)
        {
            Admin_all all = new Admin_all();
            all.Show();
            this.Close();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("Do you want to Logout", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exit == DialogResult.Yes)
            {
                login_form login = new login_form();
                login.Show();
                this.Close();
            }
        }

        private void AddTeacher_Load(object sender, EventArgs e)
        {
            if (currentAdmin != null)
            {
                lbl_name.Text = currentAdmin.Name;
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_name.Clear();
            txt_email.Clear();
            txt_telephone.Clear();
            txt_password.Clear();
        }

        private void btn_mangage_Click(object sender, EventArgs e)
        {
            Manage_Teacher manage_Teacher = new Manage_Teacher();
            manage_Teacher.Show();
            this.Hide();
        }

        private void btn_backHome_Click_1(object sender, EventArgs e)
        {
            Admin_home home = new Admin_home();
            home.Show();
            this.Close();
        }
    }
}