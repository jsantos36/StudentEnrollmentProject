using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project
{
    public partial class Form1 : Form
    {
        private string gender;
        private string studentNumber;
        SqlConnection mySQLConnection = new SqlConnection(@"Data Source=DESKTOP-M4EARNV\JONMSSQLSERVER;Initial Catalog=JONMSSQLSERVER-DB01;Persist Security Info=True;User ID=sa;Password=Rantaro60!");
        CleanUp cleanUp = new CleanUp();
        SQLConnectionQueries sqlQueries = new SQLConnectionQueries();
        public Form1()
        {
            InitializeComponent();
            loginPagePanel.Visible = true;
            signUpPagePanel.Visible = false;
            enrollmentPanel.Visible = false;
        }

        private void SignUpLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            usernameTextBox.Clear();
            passwordTextBox.Clear();
            loginPagePanel.Visible = false;
            signUpPagePanel.Visible = true;
        }

        private void BackSUBtn_Click(object sender, EventArgs e)
        {
            usernameSUTextBox.Clear();
            passwordSUTextBox.Clear();
            confirmPassSUTextBox.Clear();
            fNameSUTextBox.Clear();
            lNameSUTextBox.Clear();
            emailSUTextBox.Clear();
            maleSURB.Checked = false;
            femaleSURB.Checked = false;
            loginPagePanel.Visible = true;
            signUpPagePanel.Visible = false;
        }

        private void MaleSURB_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }

        private void FemaleSURB_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
        }

        private void RegSUBtn_Click(object sender, EventArgs e)
        {
            if (cleanUp.MatchField(passwordSUTextBox.Text, confirmPassSUTextBox.Text))
            {
                if (cleanUp.EmptyField(usernameSUTextBox.Text))
                {
                    try
                    {
                        studentNumber = (cleanUp.StudentNumberGenerator(fNameSUTextBox.Text, lNameSUTextBox.Text));
                        sqlQueries.InsertLoginInfo(usernameSUTextBox.Text, passwordSUTextBox.Text, confirmPassSUTextBox.Text, fNameSUTextBox.Text, lNameSUTextBox.Text, emailSUTextBox.Text, gender, studentNumber, majorComboBox.Text);
                        mySQLConnection.Close();
                        MessageBox.Show("Registered");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Username already exists");
                        mySQLConnection.Close();
                    }
                }
                else
                    MessageBox.Show("Username field cannot be empty");
            }
            else
                MessageBox.Show("Passwords fields need to match");
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (sqlQueries.AuthenticateLoginOne(usernameTextBox.Text, passwordTextBox.Text).Rows[0][0].ToString() == "1")
            {
                sNumberLabel.Text = sqlQueries.AuthenticateLoginTwo(usernameTextBox.Text)["StudentNumber"].ToString();
                fullNameLabel.Text = sqlQueries.AuthenticateLoginTwo(usernameTextBox.Text)["FirstName"].ToString() + " " + sqlQueries.AuthenticateLoginTwo(usernameTextBox.Text)["LastName"].ToString();
                majorLabel.Text = sqlQueries.AuthenticateLoginTwo(usernameTextBox.Text)["Major"].ToString();
                sqlQueries.DisplayAvailCourses(availCourseDGV);
                cleanUp.UnsortableColumn(availCourseDGV);
                loginPagePanel.Visible = false;
                signUpPagePanel.Visible = false;
                enrollmentPanel.Visible = true;
            }
            else
            {
                MessageBox.Show("Please check your Username and Password");
            }
            coursesComboBox.SelectedIndex = 4;
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void JCoursesRB_CheckedChanged(object sender, EventArgs e)
        {
            sqlQueries.DisplayAvailCoursesJunior(availCourseDGV);
        }

        private void SCoursesRB_CheckedChanged(object sender, EventArgs e)
        {
            sqlQueries.DisplayAvailCoursesSenior(availCourseDGV);
        }

        private void AllCoursesRB_CheckedChanged(object sender, EventArgs e)
        {
            sqlQueries.DisplayAvailCourses(availCourseDGV);
        }
    }
}
