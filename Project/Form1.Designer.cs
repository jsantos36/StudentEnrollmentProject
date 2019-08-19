namespace Project
{
    partial class Form1
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
            this.passwordLabel = new System.Windows.Forms.Label();
            this.loginBtn = new System.Windows.Forms.Button();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.exitBtn = new System.Windows.Forms.Button();
            this.signUpLink = new System.Windows.Forms.LinkLabel();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.loginPagePanel = new System.Windows.Forms.Panel();
            this.signUpPagePanel = new System.Windows.Forms.Panel();
            this.confirmPassSUTextBox = new System.Windows.Forms.TextBox();
            this.confirmPassSULabel = new System.Windows.Forms.Label();
            this.backSUBtn = new System.Windows.Forms.Button();
            this.regSUBtn = new System.Windows.Forms.Button();
            this.femaleSURB = new System.Windows.Forms.RadioButton();
            this.maleSURB = new System.Windows.Forms.RadioButton();
            this.emailSUTextBox = new System.Windows.Forms.TextBox();
            this.lNameSUTextBox = new System.Windows.Forms.TextBox();
            this.fNameSUTextBox = new System.Windows.Forms.TextBox();
            this.passwordSUTextBox = new System.Windows.Forms.TextBox();
            this.usernameSUTextBox = new System.Windows.Forms.TextBox();
            this.genderSULabel = new System.Windows.Forms.Label();
            this.emailSULabel = new System.Windows.Forms.Label();
            this.lNameSULabel = new System.Windows.Forms.Label();
            this.fNameSULabel = new System.Windows.Forms.Label();
            this.passwordSULabel = new System.Windows.Forms.Label();
            this.usernameSULabel = new System.Windows.Forms.Label();
            this.loginPagePanel.SuspendLayout();
            this.signUpPagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(74, 97);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 1;
            this.passwordLabel.Text = "Password";
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(128, 131);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(48, 23);
            this.loginBtn.TabIndex = 2;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(128, 53);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(100, 20);
            this.usernameTextBox.TabIndex = 3;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(128, 94);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(100, 20);
            this.passwordTextBox.TabIndex = 4;
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(180, 131);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(48, 23);
            this.exitBtn.TabIndex = 5;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // signUpLink
            // 
            this.signUpLink.AutoSize = true;
            this.signUpLink.Location = new System.Drawing.Point(186, 166);
            this.signUpLink.Name = "signUpLink";
            this.signUpLink.Size = new System.Drawing.Size(42, 13);
            this.signUpLink.TabIndex = 6;
            this.signUpLink.TabStop = true;
            this.signUpLink.Text = "SignUp";
            this.signUpLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SignUpLink_LinkClicked);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(72, 56);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(55, 13);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Username";
            // 
            // loginPagePanel
            // 
            this.loginPagePanel.Controls.Add(this.exitBtn);
            this.loginPagePanel.Controls.Add(this.signUpLink);
            this.loginPagePanel.Controls.Add(this.usernameLabel);
            this.loginPagePanel.Controls.Add(this.passwordLabel);
            this.loginPagePanel.Controls.Add(this.passwordTextBox);
            this.loginPagePanel.Controls.Add(this.loginBtn);
            this.loginPagePanel.Controls.Add(this.usernameTextBox);
            this.loginPagePanel.Location = new System.Drawing.Point(441, 207);
            this.loginPagePanel.Name = "loginPagePanel";
            this.loginPagePanel.Size = new System.Drawing.Size(312, 219);
            this.loginPagePanel.TabIndex = 7;
            // 
            // signUpPagePanel
            // 
            this.signUpPagePanel.Controls.Add(this.confirmPassSUTextBox);
            this.signUpPagePanel.Controls.Add(this.confirmPassSULabel);
            this.signUpPagePanel.Controls.Add(this.backSUBtn);
            this.signUpPagePanel.Controls.Add(this.regSUBtn);
            this.signUpPagePanel.Controls.Add(this.femaleSURB);
            this.signUpPagePanel.Controls.Add(this.maleSURB);
            this.signUpPagePanel.Controls.Add(this.emailSUTextBox);
            this.signUpPagePanel.Controls.Add(this.lNameSUTextBox);
            this.signUpPagePanel.Controls.Add(this.fNameSUTextBox);
            this.signUpPagePanel.Controls.Add(this.passwordSUTextBox);
            this.signUpPagePanel.Controls.Add(this.usernameSUTextBox);
            this.signUpPagePanel.Controls.Add(this.genderSULabel);
            this.signUpPagePanel.Controls.Add(this.emailSULabel);
            this.signUpPagePanel.Controls.Add(this.lNameSULabel);
            this.signUpPagePanel.Controls.Add(this.fNameSULabel);
            this.signUpPagePanel.Controls.Add(this.passwordSULabel);
            this.signUpPagePanel.Controls.Add(this.usernameSULabel);
            this.signUpPagePanel.Location = new System.Drawing.Point(397, 69);
            this.signUpPagePanel.Name = "signUpPagePanel";
            this.signUpPagePanel.Size = new System.Drawing.Size(416, 493);
            this.signUpPagePanel.TabIndex = 8;
            // 
            // confirmPassSUTextBox
            // 
            this.confirmPassSUTextBox.Location = new System.Drawing.Point(165, 178);
            this.confirmPassSUTextBox.Name = "confirmPassSUTextBox";
            this.confirmPassSUTextBox.PasswordChar = '*';
            this.confirmPassSUTextBox.Size = new System.Drawing.Size(187, 20);
            this.confirmPassSUTextBox.TabIndex = 16;
            // 
            // confirmPassSULabel
            // 
            this.confirmPassSULabel.AutoSize = true;
            this.confirmPassSULabel.Location = new System.Drawing.Point(56, 185);
            this.confirmPassSULabel.Name = "confirmPassSULabel";
            this.confirmPassSULabel.Size = new System.Drawing.Size(91, 13);
            this.confirmPassSULabel.TabIndex = 15;
            this.confirmPassSULabel.Text = "Confirm Password";
            // 
            // backSUBtn
            // 
            this.backSUBtn.Location = new System.Drawing.Point(281, 384);
            this.backSUBtn.Name = "backSUBtn";
            this.backSUBtn.Size = new System.Drawing.Size(75, 24);
            this.backSUBtn.TabIndex = 14;
            this.backSUBtn.Text = "Back";
            this.backSUBtn.UseVisualStyleBackColor = true;
            this.backSUBtn.Click += new System.EventHandler(this.BackSUBtn_Click);
            // 
            // regSUBtn
            // 
            this.regSUBtn.Location = new System.Drawing.Point(200, 384);
            this.regSUBtn.Name = "regSUBtn";
            this.regSUBtn.Size = new System.Drawing.Size(75, 24);
            this.regSUBtn.TabIndex = 13;
            this.regSUBtn.Text = "Register";
            this.regSUBtn.UseVisualStyleBackColor = true;
            this.regSUBtn.Click += new System.EventHandler(this.RegSUBtn_Click);
            // 
            // femaleSURB
            // 
            this.femaleSURB.AutoSize = true;
            this.femaleSURB.Location = new System.Drawing.Point(219, 347);
            this.femaleSURB.Name = "femaleSURB";
            this.femaleSURB.Size = new System.Drawing.Size(59, 17);
            this.femaleSURB.TabIndex = 12;
            this.femaleSURB.TabStop = true;
            this.femaleSURB.Text = "Female";
            this.femaleSURB.UseVisualStyleBackColor = true;
            this.femaleSURB.CheckedChanged += new System.EventHandler(this.FemaleSURB_CheckedChanged);
            // 
            // maleSURB
            // 
            this.maleSURB.AutoSize = true;
            this.maleSURB.Location = new System.Drawing.Point(165, 347);
            this.maleSURB.Name = "maleSURB";
            this.maleSURB.Size = new System.Drawing.Size(48, 17);
            this.maleSURB.TabIndex = 11;
            this.maleSURB.TabStop = true;
            this.maleSURB.Text = "Male";
            this.maleSURB.UseVisualStyleBackColor = true;
            this.maleSURB.CheckedChanged += new System.EventHandler(this.MaleSURB_CheckedChanged);
            // 
            // emailSUTextBox
            // 
            this.emailSUTextBox.Location = new System.Drawing.Point(166, 304);
            this.emailSUTextBox.Name = "emailSUTextBox";
            this.emailSUTextBox.Size = new System.Drawing.Size(187, 20);
            this.emailSUTextBox.TabIndex = 10;
            // 
            // lNameSUTextBox
            // 
            this.lNameSUTextBox.Location = new System.Drawing.Point(166, 262);
            this.lNameSUTextBox.Name = "lNameSUTextBox";
            this.lNameSUTextBox.Size = new System.Drawing.Size(187, 20);
            this.lNameSUTextBox.TabIndex = 9;
            // 
            // fNameSUTextBox
            // 
            this.fNameSUTextBox.Location = new System.Drawing.Point(165, 222);
            this.fNameSUTextBox.Name = "fNameSUTextBox";
            this.fNameSUTextBox.Size = new System.Drawing.Size(187, 20);
            this.fNameSUTextBox.TabIndex = 8;
            // 
            // passwordSUTextBox
            // 
            this.passwordSUTextBox.Location = new System.Drawing.Point(165, 138);
            this.passwordSUTextBox.Name = "passwordSUTextBox";
            this.passwordSUTextBox.PasswordChar = '*';
            this.passwordSUTextBox.Size = new System.Drawing.Size(187, 20);
            this.passwordSUTextBox.TabIndex = 7;
            // 
            // usernameSUTextBox
            // 
            this.usernameSUTextBox.Location = new System.Drawing.Point(165, 98);
            this.usernameSUTextBox.Name = "usernameSUTextBox";
            this.usernameSUTextBox.Size = new System.Drawing.Size(187, 20);
            this.usernameSUTextBox.TabIndex = 6;
            // 
            // genderSULabel
            // 
            this.genderSULabel.AutoSize = true;
            this.genderSULabel.Location = new System.Drawing.Point(58, 349);
            this.genderSULabel.Name = "genderSULabel";
            this.genderSULabel.Size = new System.Drawing.Size(42, 13);
            this.genderSULabel.TabIndex = 5;
            this.genderSULabel.Text = "Gender";
            // 
            // emailSULabel
            // 
            this.emailSULabel.AutoSize = true;
            this.emailSULabel.Location = new System.Drawing.Point(58, 309);
            this.emailSULabel.Name = "emailSULabel";
            this.emailSULabel.Size = new System.Drawing.Size(32, 13);
            this.emailSULabel.TabIndex = 4;
            this.emailSULabel.Text = "Email";
            // 
            // lNameSULabel
            // 
            this.lNameSULabel.AutoSize = true;
            this.lNameSULabel.Location = new System.Drawing.Point(58, 269);
            this.lNameSULabel.Name = "lNameSULabel";
            this.lNameSULabel.Size = new System.Drawing.Size(58, 13);
            this.lNameSULabel.TabIndex = 3;
            this.lNameSULabel.Text = "Last Name";
            // 
            // fNameSULabel
            // 
            this.fNameSULabel.AutoSize = true;
            this.fNameSULabel.Location = new System.Drawing.Point(58, 229);
            this.fNameSULabel.Name = "fNameSULabel";
            this.fNameSULabel.Size = new System.Drawing.Size(57, 13);
            this.fNameSULabel.TabIndex = 2;
            this.fNameSULabel.Text = "First Name";
            // 
            // passwordSULabel
            // 
            this.passwordSULabel.AutoSize = true;
            this.passwordSULabel.Location = new System.Drawing.Point(58, 145);
            this.passwordSULabel.Name = "passwordSULabel";
            this.passwordSULabel.Size = new System.Drawing.Size(53, 13);
            this.passwordSULabel.TabIndex = 1;
            this.passwordSULabel.Text = "Password";
            // 
            // usernameSULabel
            // 
            this.usernameSULabel.AutoSize = true;
            this.usernameSULabel.Location = new System.Drawing.Point(56, 105);
            this.usernameSULabel.Name = "usernameSULabel";
            this.usernameSULabel.Size = new System.Drawing.Size(55, 13);
            this.usernameSULabel.TabIndex = 0;
            this.usernameSULabel.Text = "Username";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 637);
            this.Controls.Add(this.signUpPagePanel);
            this.Controls.Add(this.loginPagePanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.loginPagePanel.ResumeLayout(false);
            this.loginPagePanel.PerformLayout();
            this.signUpPagePanel.ResumeLayout(false);
            this.signUpPagePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.LinkLabel signUpLink;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Panel loginPagePanel;
        private System.Windows.Forms.Panel signUpPagePanel;
        private System.Windows.Forms.TextBox emailSUTextBox;
        private System.Windows.Forms.TextBox lNameSUTextBox;
        private System.Windows.Forms.TextBox fNameSUTextBox;
        private System.Windows.Forms.TextBox passwordSUTextBox;
        private System.Windows.Forms.TextBox usernameSUTextBox;
        private System.Windows.Forms.Label genderSULabel;
        private System.Windows.Forms.Label emailSULabel;
        private System.Windows.Forms.Label lNameSULabel;
        private System.Windows.Forms.Label fNameSULabel;
        private System.Windows.Forms.Label passwordSULabel;
        private System.Windows.Forms.Label usernameSULabel;
        private System.Windows.Forms.RadioButton femaleSURB;
        private System.Windows.Forms.RadioButton maleSURB;
        private System.Windows.Forms.Button backSUBtn;
        private System.Windows.Forms.Button regSUBtn;
        private System.Windows.Forms.TextBox confirmPassSUTextBox;
        private System.Windows.Forms.Label confirmPassSULabel;
    }
}

