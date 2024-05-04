using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Mainform_and_login
{
    public partial class Admin_all : Form
    {
        public Admin_all()
        {
            InitializeComponent();
        }
        DbConnect conn = new DbConnect();
        Admin currentAdmin = AuthManager.GetCurrentAdmin();




        private void button2_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT id, name, email, telephone, role FROM User_1 where role = 'teacher'", conn.GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            int count = dataGridView1.RowCount - 1;
            txt_count.Text = $"Members: {count.ToString()}";
        }


        private void search_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_searchfield.Text))
            {
                MessageBox.Show("Select 1 item, Please", "Error", MessageBoxButtons.OK);
                return;
            }
            string search_field = txt_searchfield.SelectedItem.ToString();
            string search_term = txt_search.Text;

            dataGridView1.DataSource = currentAdmin.SearchBy(search_field, search_term, "teacher");
            int count = dataGridView1.RowCount - 1;
            txt_count.Text = $"Members: {count.ToString()}";

        }

        private void btn_detail_Click(object sender, EventArgs e)
        {
            Manage_Teacher manage = new Manage_Teacher();
            manage.Show();
            this.Close();
        }

        private void btn_backHome_Click(object sender, EventArgs e)
        {
            Admin_home home = new Admin_home();
            home.Show();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("Do you want to Log Out", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exit == DialogResult.Yes)
            {
                login_form login = new login_form();
                login.Show();
                this.Close();
            }
        }

        private void Admin_all_Load(object sender, EventArgs e)
        {
            if (currentAdmin != null)
            {
                lbl_loginUser.Text = currentAdmin.Name;
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            Admin_personal admin_info = new Admin_personal();
            admin_info.Show();
            this.Hide();
        }
    }
}
