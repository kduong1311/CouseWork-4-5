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
    public partial class Admin_personal : Form
    {
        public Admin_personal()
        {
            InitializeComponent();
        }

        DbConnect conn = new DbConnect();
        Admin currentAdmin = AuthManager.GetCurrentAdmin();

        private void Admin_personal_Load(object sender, EventArgs e)
        {
            
            if (currentAdmin != null)
            {
                txt_password.PasswordChar = '*';
                lbl_name.Text = currentAdmin.Name;
                txt_email.Text = currentAdmin.Email;
                txt_telephone.Text = currentAdmin.Telephone;
                txt_name.Text = currentAdmin.Name;
                lbl_salary.Text = $"{currentAdmin.Salary.ToString()} $";
                lbl_workhours.Text = $"{currentAdmin.WorkHours.ToString()}";
                int type = Convert.ToInt32(currentAdmin.WorkType.ToString());
                if (type == 1)
                {
                    lbl_wordtype.Text = "Full Time";
                    return;
                }

                else if (type == 0)
                {
                    lbl_wordtype.Text = "Part Time";
                    return;
                }             
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        { 
            if (currentAdmin != null)
            {
                if (txt_name.Text == "" || txt_email.Text == "" || txt_telephone.Text == "")
                {
                    MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string name = txt_name.Text;
                string email = txt_email.Text;
                string phone = txt_telephone.Text;
                int id = Convert.ToInt32(currentAdmin.ID);

                if (!(Person.CheckIfUserExists(email, "Admin") || email == currentAdmin.Email))
                {
                    MessageBox.Show("This email is available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                if (Person.HashPassword(txt_password.Text) == currentAdmin.Password)
                {
                    if (currentAdmin.UpdateProfile(id, name, email, phone))
                    {
                        MessageBox.Show("Update successfully", "Update", MessageBoxButtons.OK);
                        SqlDataReader reader = currentAdmin.getInfo(id);
                        while (reader.Read())
                        {
                            txt_name.Text = reader["name"].ToString();
                            txt_email.Text = reader["email"].ToString();
                            txt_telephone.Text = reader["telephone"].ToString();

                            currentAdmin.Name = reader["name"].ToString();
                            currentAdmin.Email = reader["email"].ToString();
                            currentAdmin.Telephone = reader["telephone"].ToString();
                            lbl_name.Text = reader["name"].ToString();
                            txt_password.Clear();
                        }
                    }
                }

                else
                {
                        MessageBox.Show("Invalid Confirm Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_name.Clear();
            txt_password.Clear();
            txt_telephone.Clear();
            txt_email.Clear();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Manage_Teacher manage = new Manage_Teacher();
            manage.Show();
            this.Hide();
        }
    }
}
