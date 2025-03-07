using RecruitmentApplication.Helpers;
using RecruitmentApplication.Services;
using System.Windows.Forms;

namespace RecruitmentApplication.UserInterface
{
    public partial class LoginForm : Form
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
            this.UsernameBox2 = new System.Windows.Forms.TextBox();
            this.PasswordBox2 = new System.Windows.Forms.TextBox();
            this.UsernameLabel2 = new System.Windows.Forms.Label();
            this.PasswordLabel2 = new System.Windows.Forms.Label();
            this.HeadingLabel2 = new System.Windows.Forms.Label();
            this.LogInButton2 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.CancelButton2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UsernameBox2
            // 
            this.UsernameBox2.Location = new System.Drawing.Point(40, 116);
            this.UsernameBox2.Margin = new System.Windows.Forms.Padding(4);
            this.UsernameBox2.Name = "UsernameBox2";
            this.UsernameBox2.Size = new System.Drawing.Size(224, 28);
            this.UsernameBox2.TabIndex = 0;
            // 
            // PasswordBox2
            // 
            this.PasswordBox2.Location = new System.Drawing.Point(40, 188);
            this.PasswordBox2.Margin = new System.Windows.Forms.Padding(4);
            this.PasswordBox2.Name = "PasswordBox2";
            this.PasswordBox2.PasswordChar = '*';
            this.PasswordBox2.Size = new System.Drawing.Size(224, 28);
            this.PasswordBox2.TabIndex = 1;
            // 
            // UsernameLabel2
            // 
            this.UsernameLabel2.AutoSize = true;
            this.UsernameLabel2.BackColor = System.Drawing.Color.Transparent;
            this.UsernameLabel2.Location = new System.Drawing.Point(40, 94);
            this.UsernameLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UsernameLabel2.Name = "UsernameLabel2";
            this.UsernameLabel2.Size = new System.Drawing.Size(137, 21);
            this.UsernameLabel2.TabIndex = 2;
            this.UsernameLabel2.Text = "UsernameLabel2";
            // 
            // PasswordLabel2
            // 
            this.PasswordLabel2.AutoSize = true;
            this.PasswordLabel2.BackColor = System.Drawing.Color.Transparent;
            this.PasswordLabel2.Location = new System.Drawing.Point(40, 166);
            this.PasswordLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PasswordLabel2.Name = "PasswordLabel2";
            this.PasswordLabel2.Size = new System.Drawing.Size(133, 21);
            this.PasswordLabel2.TabIndex = 3;
            this.PasswordLabel2.Text = "PasswordLabel2";
            // 
            // HeadingLabel2
            // 
            this.HeadingLabel2.AutoSize = true;
            this.HeadingLabel2.BackColor = System.Drawing.Color.Transparent;
            this.HeadingLabel2.Font = new System.Drawing.Font("Lato", 20.2F, System.Drawing.FontStyle.Bold);
            this.HeadingLabel2.Location = new System.Drawing.Point(11, 0);
            this.HeadingLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HeadingLabel2.Name = "HeadingLabel2";
            this.HeadingLabel2.Size = new System.Drawing.Size(213, 34);
            this.HeadingLabel2.TabIndex = 4;
            this.HeadingLabel2.Text = "HeadingLabel2";
            // 
            // LogInButton2
            // 
            this.LogInButton2.Location = new System.Drawing.Point(40, 262);
            this.LogInButton2.Name = "LogInButton2";
            this.LogInButton2.Size = new System.Drawing.Size(162, 52);
            this.LogInButton2.TabIndex = 5;
            this.LogInButton2.Text = "LogInButton2";
            this.LogInButton2.UseVisualStyleBackColor = true;
            this.LogInButton2.Click += new System.EventHandler(this.LogInButton2_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(308, 339);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(8, 8);
            this.button2.TabIndex = 6;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // CancelButton2
            // 
            this.CancelButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton2.Location = new System.Drawing.Point(234, 262);
            this.CancelButton2.Name = "CancelButton2";
            this.CancelButton2.Size = new System.Drawing.Size(162, 52);
            this.CancelButton2.TabIndex = 7;
            this.CancelButton2.Text = "CancelButton2";
            this.CancelButton2.UseVisualStyleBackColor = true;
            this.CancelButton2.Click += new System.EventHandler(this.CancelButton2_Click);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.LogInButton2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RecruitmentApplication.Properties.Resources.background;
            this.CancelButton = this.CancelButton2;
            this.ClientSize = new System.Drawing.Size(512, 513);
            this.Controls.Add(this.CancelButton2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.LogInButton2);
            this.Controls.Add(this.HeadingLabel2);
            this.Controls.Add(this.PasswordLabel2);
            this.Controls.Add(this.UsernameLabel2);
            this.Controls.Add(this.PasswordBox2);
            this.Controls.Add(this.UsernameBox2);
            this.Font = new System.Drawing.Font("Lato", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(512, 513);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(512, 513);
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox UsernameBox2;
        private TextBox PasswordBox2;
        private Label UsernameLabel2;
        private Label PasswordLabel2;
        private Label HeadingLabel2;
        private Button LogInButton2;
        private Button button2;
        private Button CancelButton2;
    }
}
