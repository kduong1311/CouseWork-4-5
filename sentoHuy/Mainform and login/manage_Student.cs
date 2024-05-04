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
    public partial class manage_Student : Form
    {
        public manage_Student()
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

        private void manage_Student_Load(object sender, EventArgs e)
        {
            if (currentAdmin != null)
            {
                lbl_loginUser.Text = currentAdmin.Name;
            }
        }

        private void btn_list_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = currentAdmin.getStudents();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (txt_name.Text == "" || txt_email.Text == "" || txt_telephone.Text == "" || txt_id.Text == "")
            {
                MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = Convert.ToInt32(txt_id.Text);
            string name = txt_name.Text;
            string email = txt_email.Text;
            string telephone = txt_telephone.Text;
            string pre_subject1 = txt_presub1.Text;
            string pre_subject2 = txt_presub2.Text;
            string cur_subject1 = txt_cursub1.Text;
            string cur_subject2 = txt_cursub2.Text;

            

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Enter valid format for email, please", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (currentAdmin.Update_Student(id, name, email, telephone, pre_subject1, pre_subject2, cur_subject1, cur_subject2))
            {
                btn_list_Click(null, null);
            }
            btn_list_Click(null, null);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            txt_id.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_email.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_telephone.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_presub1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_presub2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txt_cursub1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txt_cursub2.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }
        private void btn_remove_Click_1(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("Do you want to Delete this Student", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exit == DialogResult.Yes)
            {
                if (txt_id.Text == "")
                {
                    MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int id = int.Parse(txt_id.Text);
                if (currentAdmin.RemoveStudent(id))
                {
                    btn_list_Click(null, null);

                }
                btn_list_Click(null, null);
            }
        }

        private void btn_all_Click(object sender, EventArgs e)
        {
            All_student allstu = new All_student();
            allstu.Show();
            this.Hide();
        }

        private void btn_backHome_Click(object sender, EventArgs e)
        {
            Admin_home admin_Home = new Admin_home();
            admin_Home.Show();
            this.Hide();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            Admin_personal admin_info = new Admin_personal();
            admin_info.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("Do you want to LogOut?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exit == DialogResult.Yes)
            {
                AuthManager.Logout_Admin();
                login_form login_Form = new login_form();
                login_Form.Show();
                this.Close();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btn_addstudent_Click(object sender, EventArgs e)
        {
            AddStudent addStudent = new AddStudent();
            addStudent.Show();
            this.Hide();
        }
    }

    public class DataEventArgs : EventArgs
    {
        public string Data { get; }

        public DataEventArgs(string data)
        {
            Data = data;
        }
    }
}
