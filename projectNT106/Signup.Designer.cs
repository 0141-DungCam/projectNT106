﻿using System.Drawing;
using System.Windows.Forms;

namespace projectNT106
{
    partial class Signup
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
            this.btnReturnHome = new GameProject.CustomControls.ButtonDesign();
            this.textBoxDesign1 = new GameProject.CustomControls.TextBoxDesign();
            this.textBoxDesign2 = new GameProject.CustomControls.TextBoxDesign();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSignup = new GameProject.CustomControls.ButtonDesign();
            this.textBoxDesign3 = new GameProject.CustomControls.TextBoxDesign();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReturnHome
            // 
            btnReturnHome.BackColor = Color.MediumSlateBlue;
            btnReturnHome.BackgroundColor = Color.MediumSlateBlue;
            btnReturnHome.BackgroundImageLayout = ImageLayout.Stretch;
            btnReturnHome.BorderColor = Color.PaleVioletRed;
            btnReturnHome.BorderRadius = 0;
            btnReturnHome.BorderSize = 0;
            btnReturnHome.FlatAppearance.BorderSize = 0;
            btnReturnHome.FlatStyle = FlatStyle.Flat;
            btnReturnHome.ForeColor = Color.White;
            btnReturnHome.Location = new Point(85, 548);
            btnReturnHome.Name = "btnReturnHome";
            btnReturnHome.Size = new Size(252, 50);
            btnReturnHome.TabIndex = 18;
            btnReturnHome.Text = "Return home";
            btnReturnHome.TextColor = Color.White;
            btnReturnHome.UseVisualStyleBackColor = false;
            btnReturnHome.Click += btnReturnHome_Click;
            // 
            // textBoxDesign1
            // 
            this.textBoxDesign1.BackColor = System.Drawing.Color.Moccasin;
            this.textBoxDesign1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.textBoxDesign1.BorderColor = System.Drawing.Color.Transparent;
            this.textBoxDesign1.BorderFocusColor = System.Drawing.Color.Transparent;
            this.textBoxDesign1.BorderRadius = 0;
            this.textBoxDesign1.BorderSize = 1;
            this.textBoxDesign1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.textBoxDesign1.ForeColor = System.Drawing.Color.Black;
            this.textBoxDesign1.Location = new System.Drawing.Point(51, 180);
            this.textBoxDesign1.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDesign1.Multiline = false;
            this.textBoxDesign1.Name = "textBoxDesign1";
            this.textBoxDesign1.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxDesign1.PasswordChar = false;
            this.textBoxDesign1.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.textBoxDesign1.PlaceholderText = "Tên đăng nhập";
            this.textBoxDesign1.Size = new System.Drawing.Size(286, 36);
            this.textBoxDesign1.TabIndex = 17;
            this.textBoxDesign1.Texts = "";
            this.textBoxDesign1.UnderlinedStyle = false;
            // 
            // textBoxDesign2
            // 
            this.textBoxDesign2.BackColor = System.Drawing.Color.Moccasin;
            this.textBoxDesign2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.textBoxDesign2.BorderColor = System.Drawing.Color.Transparent;
            this.textBoxDesign2.BorderFocusColor = System.Drawing.Color.Transparent;
            this.textBoxDesign2.BorderRadius = 0;
            this.textBoxDesign2.BorderSize = 1;
            this.textBoxDesign2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.textBoxDesign2.ForeColor = System.Drawing.Color.Black;
            this.textBoxDesign2.Location = new System.Drawing.Point(51, 281);
            this.textBoxDesign2.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDesign2.Multiline = false;
            this.textBoxDesign2.Name = "textBoxDesign2";
            this.textBoxDesign2.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxDesign2.PasswordChar = true;
            this.textBoxDesign2.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.textBoxDesign2.PlaceholderText = "Mật khẩu";
            this.textBoxDesign2.Size = new System.Drawing.Size(286, 36);
            this.textBoxDesign2.TabIndex = 16;
            this.textBoxDesign2.Texts = "";
            this.textBoxDesign2.UnderlinedStyle = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(38, 161);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(344, 95);
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(37, 262);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(345, 95);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(170, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "SIGN UP";
            // 
            // btnSignup
            // 
            this.btnSignup.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnSignup.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnSignup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSignup.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnSignup.BorderRadius = 0;
            this.btnSignup.BorderSize = 0;
            this.btnSignup.FlatAppearance.BorderSize = 0;
            this.btnSignup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignup.ForeColor = System.Drawing.Color.White;
            this.btnSignup.Location = new System.Drawing.Point(85, 488);
            this.btnSignup.Name = "btnSignup";
            this.btnSignup.Size = new System.Drawing.Size(252, 50);
            this.btnSignup.TabIndex = 12;
            this.btnSignup.Text = "Sign up";
            Load += Signup_Load;
            this.btnSignup.TextColor = System.Drawing.Color.White;
            this.btnSignup.UseVisualStyleBackColor = false;
            btnSignup.Click += btnSignup_Click;
            // 
            // textBoxDesign3
            // 
            this.textBoxDesign3.BackColor = System.Drawing.Color.Moccasin;
            this.textBoxDesign3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.textBoxDesign3.BorderColor = System.Drawing.Color.Transparent;
            this.textBoxDesign3.BorderFocusColor = System.Drawing.Color.Transparent;
            this.textBoxDesign3.BorderRadius = 0;
            this.textBoxDesign3.BorderSize = 1;
            this.textBoxDesign3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.textBoxDesign3.ForeColor = System.Drawing.Color.Black;
            this.textBoxDesign3.Location = new System.Drawing.Point(50, 382);
            this.textBoxDesign3.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDesign3.Multiline = false;
            this.textBoxDesign3.Name = "textBoxDesign3";
            this.textBoxDesign3.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxDesign3.PasswordChar = true;
            this.textBoxDesign3.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.textBoxDesign3.PlaceholderText = "Nhập lại mật khẩu";
            this.textBoxDesign3.Size = new System.Drawing.Size(286, 36);
            this.textBoxDesign3.TabIndex = 20;
            this.textBoxDesign3.Texts = "";
            this.textBoxDesign3.UnderlinedStyle = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(37, 363);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(344, 95);
            this.pictureBox3.TabIndex = 19;
            this.pictureBox3.TabStop = false;
            // 
            // Signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(482, 673);
            this.Controls.Add(this.textBoxDesign3);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btnReturnHome);
            this.Controls.Add(this.textBoxDesign1);
            this.Controls.Add(this.textBoxDesign2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSignup);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Signup";
            this.Text = "Signup";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GameProject.CustomControls.ButtonDesign btnReturnHome;
        private GameProject.CustomControls.TextBoxDesign textBoxDesign1;
        private GameProject.CustomControls.TextBoxDesign textBoxDesign2;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label label1;
        private GameProject.CustomControls.ButtonDesign btnSignup;
        private GameProject.CustomControls.TextBoxDesign textBoxDesign3;
        private PictureBox pictureBox3;
    }
}