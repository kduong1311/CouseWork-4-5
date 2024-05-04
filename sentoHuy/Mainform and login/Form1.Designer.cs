namespace Mainform_and_login
{
    partial class login_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_email = new System.Windows.Forms.Label();
            this.lbl_password = new System.Windows.Forms.Label();
            this.txt_loginEmail = new System.Windows.Forms.TextBox();
            this.txt_loginPassword = new System.Windows.Forms.TextBox();
            this.lbl_welcome = new System.Windows.Forms.Label();
            this.btn_login = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_regis = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_showPass = new System.Windows.Forms.CheckBox();
            this.txt_role = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_email.ForeColor = System.Drawing.Color.Blue;
            this.lbl_email.Location = new System.Drawing.Point(468, 110);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(85, 32);
            this.lbl_email.TabIndex = 0;
            this.lbl_email.Text = "Email";
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_password.ForeColor = System.Drawing.Color.Blue;
            this.lbl_password.Location = new System.Drawing.Point(470, 221);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(129, 32);
            this.lbl_password.TabIndex = 1;
            this.lbl_password.Text = "Password";
            // 
            // txt_loginEmail
            // 
            this.txt_loginEmail.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_loginEmail.Location = new System.Drawing.Point(474, 155);
            this.txt_loginEmail.Name = "txt_loginEmail";
            this.txt_loginEmail.Size = new System.Drawing.Size(330, 42);
            this.txt_loginEmail.TabIndex = 2;
            // 
            // txt_loginPassword
            // 
            this.txt_loginPassword.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_loginPassword.Location = new System.Drawing.Point(474, 271);
            this.txt_loginPassword.Name = "txt_loginPassword";
            this.txt_loginPassword.Size = new System.Drawing.Size(330, 42);
            this.txt_loginPassword.TabIndex = 3;
            this.txt_loginPassword.UseSystemPasswordChar = true;
            // 
            // lbl_welcome
            // 
            this.lbl_welcome.AutoSize = true;
            this.lbl_welcome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbl_welcome.Font = new System.Drawing.Font("News706 BT", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_welcome.Location = new System.Drawing.Point(60, 24);
            this.lbl_welcome.Name = "lbl_welcome";
            this.lbl_welcome.Size = new System.Drawing.Size(295, 72);
            this.lbl_welcome.TabIndex = 4;
            this.lbl_welcome.Text = "Welcome";
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_login.Font = new System.Drawing.Font("VNI-Bandit", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_login.Location = new System.Drawing.Point(527, 446);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(233, 69);
            this.btn_login.TabIndex = 5;
            this.btn_login.Text = "Log - in";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_exit.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_exit.Location = new System.Drawing.Point(741, 540);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(111, 37);
            this.btn_exit.TabIndex = 6;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Stencil", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(498, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 47);
            this.label1.TabIndex = 7;
            this.label1.Text = "Login Account";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Mainform_and_login.Properties.Resources.pngtree_cartoon_cute_elementary_school_season_promotion_background_picture_image_1142596;
            this.pictureBox1.Location = new System.Drawing.Point(0, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(441, 587);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btn_regis
            // 
            this.btn_regis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_regis.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_regis.Location = new System.Drawing.Point(26, 537);
            this.btn_regis.Name = "btn_regis";
            this.btn_regis.Size = new System.Drawing.Size(380, 40);
            this.btn_regis.TabIndex = 9;
            this.btn_regis.Text = "Create an account";
            this.btn_regis.UseVisualStyleBackColor = false;
            this.btn_regis.Click += new System.EventHandler(this.btn_regis_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(568, 334);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 10;
            // 
            // btn_showPass
            // 
            this.btn_showPass.AutoSize = true;
            this.btn_showPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_showPass.Location = new System.Drawing.Point(474, 334);
            this.btn_showPass.Name = "btn_showPass";
            this.btn_showPass.Size = new System.Drawing.Size(188, 29);
            this.btn_showPass.TabIndex = 11;
            this.btn_showPass.Text = "Show Password";
            this.btn_showPass.UseVisualStyleBackColor = true;
            this.btn_showPass.CheckedChanged += new System.EventHandler(this.btn_showPass_CheckedChanged);
            // 
            // txt_role
            // 
            this.txt_role.Font = new System.Drawing.Font(".VnArial", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_role.FormattingEnabled = true;
            this.txt_role.Items.AddRange(new object[] {
            "Student",
            "Admin",
            "Teacher"});
            this.txt_role.Location = new System.Drawing.Point(476, 381);
            this.txt_role.Name = "txt_role";
            this.txt_role.Size = new System.Drawing.Size(330, 35);
            this.txt_role.TabIndex = 12;
            // 
            // login_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(864, 589);
            this.Controls.Add(this.txt_role);
            this.Controls.Add(this.btn_showPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_regis);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.lbl_welcome);
            this.Controls.Add(this.txt_loginPassword);
            this.Controls.Add(this.txt_loginEmail);
            this.Controls.Add(this.lbl_password);
            this.Controls.Add(this.lbl_email);
            this.Controls.Add(this.pictureBox1);
            this.Name = "login_form";
            this.Text = "Log In";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.TextBox txt_loginEmail;
        private System.Windows.Forms.TextBox txt_loginPassword;
        private System.Windows.Forms.Label lbl_welcome;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_regis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox btn_showPass;
        private System.Windows.Forms.ComboBox txt_role;
    }
}

