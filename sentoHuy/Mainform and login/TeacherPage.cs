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
    public partial class TeacherPage : Form
    {
        public TeacherPage()
        {
            InitializeComponent();
        }

        private void TeacherPage_Load(object sender, EventArgs e)
        {
            Teacher currenr_teacher = AuthManager.GetCurrentTeacher();
            if (currenr_teacher != null )
            {
                txt_salary.Text = currenr_teacher.Salary.ToString();
                txt_sub1.Text = currenr_teacher.Subject1;
                txt_sub2.Text = currenr_teacher.Subject2;
                btn_profile.Text = currenr_teacher.Name;
            }
        }

        private void btn_profile_Click(object sender, EventArgs e)
        {
            Teacher_profile teacher_Profile = new Teacher_profile();
            teacher_Profile.Show();
            this.Hide();
        }
    }
}
