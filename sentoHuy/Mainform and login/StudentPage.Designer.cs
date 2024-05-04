namespace Mainform_and_login
{
    partial class StudentPage
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_presub1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableAdapterManager1 = new Mainform_and_login._CourseWork_6_4DataSetTableAdapters.TableAdapterManager();
            this.btn_profile = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_presub2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_cursub2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txt_cursub1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("UTM Azuki", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(345, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(480, 99);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student Page";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.txt_presub1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(94, 219);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(416, 152);
            this.panel1.TabIndex = 1;
            // 
            // txt_presub1
            // 
            this.txt_presub1.AutoSize = true;
            this.txt_presub1.Font = new System.Drawing.Font("UTM Androgyne", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_presub1.Location = new System.Drawing.Point(108, 90);
            this.txt_presub1.Name = "txt_presub1";
            this.txt_presub1.Size = new System.Drawing.Size(102, 43);
            this.txt_presub1.TabIndex = 1;
            this.txt_presub1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("UTM Androgyne", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 43);
            this.label2.TabIndex = 0;
            this.label2.Text = "Previous_subject1\r\n";
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.AdminTableAdapter = null;
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.StudentTableAdapter = null;
            this.tableAdapterManager1.TeacherTableAdapter = null;
            this.tableAdapterManager1.UpdateOrder = Mainform_and_login._CourseWork_6_4DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager1.User_1TableAdapter = null;
            // 
            // btn_profile
            // 
            this.btn_profile.Font = new System.Drawing.Font("UTM Androgyne", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_profile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_profile.Location = new System.Drawing.Point(904, 25);
            this.btn_profile.Name = "btn_profile";
            this.btn_profile.Size = new System.Drawing.Size(254, 63);
            this.btn_profile.TabIndex = 3;
            this.btn_profile.Text = "Profile";
            this.btn_profile.UseVisualStyleBackColor = true;
            this.btn_profile.Click += new System.EventHandler(this.btn_profile_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.pictureBox1.Image = global::Mainform_and_login.Properties.Resources.me2;
            this.pictureBox1.Location = new System.Drawing.Point(904, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(68, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Mainform_and_login.Properties.Resources.Official_logo_of_Greenwich_Vietnam;
            this.pictureBox2.Location = new System.Drawing.Point(12, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(362, 166);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.txt_presub2);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(94, 425);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(416, 152);
            this.panel2.TabIndex = 2;
            // 
            // txt_presub2
            // 
            this.txt_presub2.AutoSize = true;
            this.txt_presub2.Font = new System.Drawing.Font("UTM Androgyne", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_presub2.Location = new System.Drawing.Point(108, 92);
            this.txt_presub2.Name = "txt_presub2";
            this.txt_presub2.Size = new System.Drawing.Size(102, 43);
            this.txt_presub2.TabIndex = 1;
            this.txt_presub2.Text = "Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("UTM Androgyne", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(65, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(278, 43);
            this.label5.TabIndex = 0;
            this.label5.Text = "Previous_subject2";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.txt_cursub2);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(670, 425);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(390, 152);
            this.panel3.TabIndex = 4;
            // 
            // txt_cursub2
            // 
            this.txt_cursub2.AutoSize = true;
            this.txt_cursub2.Font = new System.Drawing.Font("UTM Androgyne", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cursub2.Location = new System.Drawing.Point(108, 92);
            this.txt_cursub2.Name = "txt_cursub2";
            this.txt_cursub2.Size = new System.Drawing.Size(102, 43);
            this.txt_cursub2.TabIndex = 1;
            this.txt_cursub2.Text = "Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("UTM Androgyne", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(66, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(267, 43);
            this.label7.TabIndex = 0;
            this.label7.Text = "Current_subject2";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel4.Controls.Add(this.txt_cursub1);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Location = new System.Drawing.Point(670, 219);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(390, 152);
            this.panel4.TabIndex = 3;
            // 
            // txt_cursub1
            // 
            this.txt_cursub1.AutoSize = true;
            this.txt_cursub1.Font = new System.Drawing.Font("UTM Androgyne", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cursub1.Location = new System.Drawing.Point(108, 90);
            this.txt_cursub1.Name = "txt_cursub1";
            this.txt_cursub1.Size = new System.Drawing.Size(102, 43);
            this.txt_cursub1.TabIndex = 1;
            this.txt_cursub1.Text = "Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("UTM Androgyne", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(66, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(264, 43);
            this.label9.TabIndex = 0;
            this.label9.Text = "Current_subject1\r\n";
            // 
            // StudentPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1170, 619);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_profile);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Snow;
            this.Name = "StudentPage";
            this.Text = "Student";
            this.Load += new System.EventHandler(this.Student_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private _CourseWork_6_4DataSetTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.Button btn_profile;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txt_presub1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label txt_presub2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label txt_cursub2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label txt_cursub1;
        private System.Windows.Forms.Label label9;
    }
}