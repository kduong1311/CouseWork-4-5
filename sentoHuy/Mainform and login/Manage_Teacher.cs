using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mainform_and_login
{
    public partial class Manage_Teacher : Form
    {
        public Manage_Teacher()
        {
            InitializeComponent();
        }

        Admin currentAdmin = AuthManager.GetCurrentAdmin();
        private bool IsValidEmail(string email)
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

        private void btn_list_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = currentAdmin.getTeachers();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (txt_name.Text == "" || txt_email.Text == "" || txt_telephone.Text == "" || txt_salary.Text == "" || txt_id.Text == "")
            {
                MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = Convert.ToInt32(txt_id.Text);
            string name = txt_name.Text;
            string email = txt_email.Text;
            string telephone = txt_telephone.Text;
            double salary = Convert.ToDouble(txt_salary.Text);
            string subject1 = txt_sub1.Text;
            string subject2 = txt_sub2.Text;

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Enter valid format for email, please", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!(10000000 > salary && salary > 10))
            {
                MessageBox.Show("Salary have to in range 10 - 10.000.000", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (currentAdmin.Update_Teacher(id, name, email, telephone, salary, subject1, subject2))
            {
                btn_list_Click(null, null);
            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            txt_id.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_email.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_telephone.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_sub1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_sub2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txt_salary.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {

            DialogResult exit = MessageBox.Show("Do you want to Delete this Teacher", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exit == DialogResult.Yes)
            {
                if (txt_id.Text == "")
                {
                    MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int id = int.Parse(txt_id.Text);
                if (currentAdmin.RemoveTeacher(id))
                {
                    btn_list_Click(null, null);

                }
                btn_list_Click(null, null);
            }          
        }

        private void Manage_Load(object sender, EventArgs e)
        {
            if(currentAdmin != null)
            {
                lbl_loginUser.Text = currentAdmin.Name;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("Do you want to Logout", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exit == DialogResult.Yes)
            {
                login_form login = new login_form();
                login.Show();
                this.Close();
            }
        }

        private void btn_backHome_Click(object sender, EventArgs e)
        {
            Admin_home home = new Admin_home();
            home.Show();
            this.Close();
        }

        private void btn_all_Click(object sender, EventArgs e)
        {
            Admin_all all = new Admin_all();
            all.Show();
            this.Close();
        }

        private void btn_detail_Click(object sender, EventArgs e)
        {
            Admin_personal admin_info = new Admin_personal();
            admin_info.Show();
            this.Hide();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AddTeacher addTeacher = new AddTeacher();
            addTeacher.Show();
            this.Hide();
        }
    }
}
