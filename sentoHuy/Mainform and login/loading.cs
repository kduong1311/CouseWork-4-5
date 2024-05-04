using System;
using System.Windows.Forms;

namespace Mainform_and_login
{
    public partial class loading : Form
    {
        public loading()
        {
            InitializeComponent();
        }

        private void loading_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 3;

            if (panel2.Width >= 568)
            {
                timer1.Stop();
                login_form login_Form = new login_form();
                login_Form.Show();
                this.Hide();
            }
            
        }
    }
}
