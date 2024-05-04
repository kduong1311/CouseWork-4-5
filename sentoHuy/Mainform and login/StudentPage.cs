using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mainform_and_login
{
    public partial class StudentPage : Form
    {
        public StudentPage()
        {
            InitializeComponent();
        }
        private void Student_Load(object sender, EventArgs e)
        {
            //get login_teacher to use the attributes methods
            Student current_student = AuthManager.GetCurrentStudent();
            if (current_student != null)
            {
                txt_cursub1.Text = current_student.Cursub1;
                txt_cursub2.Text = current_student.Cursub2;
                txt_presub1.Text = current_student.Presub1;
                txt_presub2.Text = current_student.Presub2;
                btn_profile.Text = current_student.Name;
            }
        }

        private void btn_profile_Click(object sender, EventArgs e)
        {
            Student_Personal page = new Student_Personal();
            page.Show();
            this.Close();
        }

    }
}
