using System.Drawing;
using System.Windows.Forms;

namespace projectNT106
{
    partial class Login
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
            this.btnLogin = new GameProject.CustomControls.ButtonDesign();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBoxDesign2 = new GameProject.CustomControls.TextBoxDesign();
            this.textBoxDesign1 = new GameProject.CustomControls.TextBoxDesign();
            this.btnReturnHome = new GameProject.CustomControls.ButtonDesign();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.MediumSlateBlue;
            btnLogin.BackgroundColor = Color.MediumSlateBlue;
            btnLogin.BackgroundImageLayout = ImageLayout.Stretch;
            btnLogin.BorderColor = Color.PaleVioletRed;
            btnLogin.BorderRadius = 0;
            btnLogin.BorderSize = 0;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(74, 488);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(252, 50);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Login";
            btnLogin.TextColor = Color.White;
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(170, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "LOGIN";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(30, 360);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(345, 95);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(31, 249);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(344, 95);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
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
            this.textBoxDesign2.Location = new System.Drawing.Point(44, 379);
            this.textBoxDesign2.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDesign2.Multiline = false;
            this.textBoxDesign2.Name = "textBoxDesign2";
            this.textBoxDesign2.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxDesign2.PasswordChar = true;
            this.textBoxDesign2.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.textBoxDesign2.PlaceholderText = "Mật khẩu";
            this.textBoxDesign2.Size = new System.Drawing.Size(286, 36);
            this.textBoxDesign2.TabIndex = 9;
            this.textBoxDesign2.Texts = "";
            this.textBoxDesign2.UnderlinedStyle = false;
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
            this.textBoxDesign1.Location = new System.Drawing.Point(44, 268);
            this.textBoxDesign1.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDesign1.Multiline = false;
            this.textBoxDesign1.Name = "textBoxDesign1";
            this.textBoxDesign1.Padding = new System.Windows.Forms.Padding(7);
            this.textBoxDesign1.PasswordChar = false;
            this.textBoxDesign1.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.textBoxDesign1.PlaceholderText = "Tên đăng nhập";
            this.textBoxDesign1.Size = new System.Drawing.Size(286, 36);
            this.textBoxDesign1.TabIndex = 10;
            this.textBoxDesign1.Texts = "";
            this.textBoxDesign1.UnderlinedStyle = false;
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
            btnReturnHome.Location = new Point(74, 548);
            btnReturnHome.Name = "btnReturnHome";
            btnReturnHome.Size = new Size(252, 50);
            btnReturnHome.TabIndex = 11;
            btnReturnHome.Text = "Return home";
            btnReturnHome.TextColor = Color.White;
            btnReturnHome.UseVisualStyleBackColor = false;
            btnReturnHome.Click += btnReturnHome_Click;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(482, 673);
            this.Controls.Add(this.btnReturnHome);
            this.Controls.Add(this.textBoxDesign1);
            this.Controls.Add(this.textBoxDesign2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogin);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Login";
            this.Text = "Login";
            Load += Login_Load;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GameProject.CustomControls.ButtonDesign btnLogin;
        private Label label1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private GameProject.CustomControls.TextBoxDesign textBoxDesign2;
        private GameProject.CustomControls.TextBoxDesign textBoxDesign1;
        private GameProject.CustomControls.ButtonDesign btnReturnHome;
    }
}