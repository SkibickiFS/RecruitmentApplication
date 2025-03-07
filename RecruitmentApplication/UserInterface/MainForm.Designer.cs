namespace RecruitmentApplication.UserInterface
{
    partial class MainForm
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
            this.linkedinLink = new System.Windows.Forms.LinkLabel();
            this.HeadingLabel1 = new System.Windows.Forms.Label();
            this.LoginButton1 = new System.Windows.Forms.Button();
            this.InstButton1 = new System.Windows.Forms.Button();
            this.DocButton1 = new System.Windows.Forms.Button();
            this.FlagButton1 = new System.Windows.Forms.Button();
            this.LangLabel1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // linkedinLink
            // 
            this.linkedinLink.AutoSize = true;
            this.linkedinLink.Font = new System.Drawing.Font("Lato", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linkedinLink.Location = new System.Drawing.Point(375, 482);
            this.linkedinLink.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkedinLink.Name = "linkedinLink";
            this.linkedinLink.Size = new System.Drawing.Size(151, 25);
            this.linkedinLink.TabIndex = 0;
            this.linkedinLink.TabStop = true;
            this.linkedinLink.Text = "Marcin Skibicki";
            this.linkedinLink.Click += new System.EventHandler(this.linkedinLink_Click);
            // 
            // HeadingLabel1
            // 
            this.HeadingLabel1.AutoSize = true;
            this.HeadingLabel1.BackColor = System.Drawing.Color.Transparent;
            this.HeadingLabel1.Font = new System.Drawing.Font("Lato", 20.2F, System.Drawing.FontStyle.Bold);
            this.HeadingLabel1.Location = new System.Drawing.Point(13, 0);
            this.HeadingLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HeadingLabel1.Name = "HeadingLabel1";
            this.HeadingLabel1.Size = new System.Drawing.Size(162, 49);
            this.HeadingLabel1.TabIndex = 1;
            this.HeadingLabel1.Text = "Header";
            this.HeadingLabel1.UseMnemonic = false;
            // 
            // LoginButton1
            // 
            this.LoginButton1.Location = new System.Drawing.Point(20, 94);
            this.LoginButton1.Name = "LoginButton1";
            this.LoginButton1.Size = new System.Drawing.Size(162, 52);
            this.LoginButton1.TabIndex = 2;
            this.LoginButton1.Text = "Login";
            this.LoginButton1.UseVisualStyleBackColor = true;
            this.LoginButton1.Click += new System.EventHandler(this.LoginButton1_Click);
            // 
            // InstButton1
            // 
            this.InstButton1.Location = new System.Drawing.Point(20, 168);
            this.InstButton1.Name = "InstButton1";
            this.InstButton1.Size = new System.Drawing.Size(162, 52);
            this.InstButton1.TabIndex = 3;
            this.InstButton1.Text = "InstText";
            this.InstButton1.UseVisualStyleBackColor = true;
            this.InstButton1.Click += new System.EventHandler(this.InstButton1_Click);
            // 
            // DocButton1
            // 
            this.DocButton1.Location = new System.Drawing.Point(20, 241);
            this.DocButton1.Name = "DocButton1";
            this.DocButton1.Size = new System.Drawing.Size(162, 52);
            this.DocButton1.TabIndex = 4;
            this.DocButton1.Text = "Doc";
            this.DocButton1.UseVisualStyleBackColor = true;
            this.DocButton1.Click += new System.EventHandler(this.DocButton1_Click);
            // 
            // FlagButton1
            // 
            this.FlagButton1.BackgroundImage = global::RecruitmentApplication.Properties.Resources.Flag_UK;
            this.FlagButton1.Location = new System.Drawing.Point(20, 451);
            this.FlagButton1.Name = "FlagButton1";
            this.FlagButton1.Size = new System.Drawing.Size(66, 49);
            this.FlagButton1.TabIndex = 5;
            this.FlagButton1.UseVisualStyleBackColor = true;
            this.FlagButton1.Click += new System.EventHandler(this.FlagButton1_Click);
            // 
            // LangLabel1
            // 
            this.LangLabel1.AutoSize = true;
            this.LangLabel1.BackColor = System.Drawing.Color.Transparent;
            this.LangLabel1.Location = new System.Drawing.Point(16, 418);
            this.LangLabel1.Name = "LangLabel1";
            this.LangLabel1.Size = new System.Drawing.Size(167, 25);
            this.LangLabel1.TabIndex = 6;
            this.LangLabel1.Text = "ChangeLangText";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(512, 513);
            this.panel1.TabIndex = 7;
            this.panel1.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RecruitmentApplication.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(507, 503);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LangLabel1);
            this.Controls.Add(this.FlagButton1);
            this.Controls.Add(this.DocButton1);
            this.Controls.Add(this.InstButton1);
            this.Controls.Add(this.LoginButton1);
            this.Controls.Add(this.HeadingLabel1);
            this.Controls.Add(this.linkedinLink);
            this.Font = new System.Drawing.Font("Lato", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(529, 559);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkedinLink;
        private System.Windows.Forms.Label HeadingLabel1;
        private System.Windows.Forms.Button LoginButton1;
        private System.Windows.Forms.Button InstButton1;
        private System.Windows.Forms.Button DocButton1;
        private System.Windows.Forms.Button FlagButton1;
        private System.Windows.Forms.Label LangLabel1;
        internal System.Windows.Forms.Panel panel1;
    }
}