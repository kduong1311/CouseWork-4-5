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
    public partial class All_student : Form
    {
        public All_student()
        {
            InitializeComponent();
        }
        DbConnect conn = new DbConnect();
        Admin currentAdmin = AuthManager.GetCurrentAdmin();


        private void btn_loading_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT id, name, email, telephone, role FROM User_1 where role = 'Student'", conn.GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            int count = dataGridView1.RowCount - 1;
            txt_count.Text = $"Members: {count.ToString()}";
        }

        private void search_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txt_searchfield.Text))
            {
                MessageBox.Show("Select 1 item, Please", "Error", MessageBoxButtons.OK);
                return;
            }
            string search_field = txt_searchfield.SelectedItem.ToString();
            string search_term = txt_search.Text;

            dataGridView1.DataSource = currentAdmin.SearchBy(search_field, search_term, "Student");

            int count = dataGridView1.RowCount - 1;
            txt_count.Text = $"Members: {count.ToString()}";
        }

        private void All_student_Load(object sender, EventArgs e)
        {
            if (currentAdmin != null)
            {
                lbl_loginUser.Text = currentAdmin.Name;
            }
        }

        private void btn_backHome_Click(object sender, EventArgs e)
        {
            Admin_home admin_Home = new Admin_home();
            admin_Home.Show();
            this.Hide();
        }

        private void btn_detail_Click(object sender, EventArgs e)
        {
            manage_Student manage_Student = new manage_Student();
            manage_Student.Show();
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
    }
}
