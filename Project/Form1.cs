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

        public Form1()
        {
            InitializeComponent();
            signUpPagePanel.Visible = false;
            enrollmentPanel.Visible = false;
            loginPagePanel.Visible = true;
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
            CleanUp confirmPass = new CleanUp();
            CleanUp confirmUserName = new CleanUp();
            CleanUp generateStudentNumber = new CleanUp();

            if (confirmPass.MatchField(passwordSUTextBox.Text, confirmPassSUTextBox.Text))
            {
                if (confirmUserName.EmptyField(usernameSUTextBox.Text))
                {
                    try
                    {
                        mySQLConnection.Open();
                        studentNumber = (generateStudentNumber.StudentNumberGenerator(fNameSUTextBox.Text, lNameSUTextBox.Text));
                        String mySQLQuery = ("INSERT INTO js_LoginInfo (Username,Password,ConfirmPassword,FirstName,LastName,Email,Gender,StudentNumber,Major) VALUES ('" + usernameSUTextBox.Text + "', '" + passwordSUTextBox.Text + "','" + confirmPassSUTextBox.Text + "','" + fNameSUTextBox.Text + "'," + "'" + lNameSUTextBox.Text + "','" + emailSUTextBox.Text + "','" + gender + "', '"+ studentNumber +"', '" + majorComboBox.Text+ "')");
                        SqlDataAdapter mySDA = new SqlDataAdapter(mySQLQuery, mySQLConnection);
                        mySDA.SelectCommand.ExecuteNonQuery();
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
            mySQLConnection.Open();
            String mySQLQuery = ("Select Count(*) From js_LoginInfo where Username = '" + usernameTextBox.Text + "' and Password = '" + passwordTextBox.Text + "'");
            SqlDataAdapter mySDA = new SqlDataAdapter(mySQLQuery, mySQLConnection);
            DataTable myDT = new DataTable();
            mySDA.Fill(myDT);

            if (myDT.Rows[0][0].ToString() == "1")
            {
                String mySQLQueryLogin = ("Select * From js_LoginInfo where Username = '" + usernameTextBox.Text + "'");
                SqlCommand mySQLCommand = new SqlCommand(mySQLQueryLogin, mySQLConnection);
                SqlDataReader myDataReaderLogin = mySQLCommand.ExecuteReader();
                myDataReaderLogin.Read();

                sNumberLabel.Text = myDataReaderLogin["StudentNumber"].ToString();
                fullNameLabel.Text = myDataReaderLogin["FirstName"].ToString() + " " + myDataReaderLogin["LastName"].ToString();
                majorLabel.Text = myDataReaderLogin["Major"].ToString();
             
                loginPagePanel.Visible = false;
                signUpPagePanel.Visible = false;
                enrollmentPanel.Visible = true;
                mySQLConnection.Close();
            }
            else
            {
                MessageBox.Show("Please check your Username and Password");
                mySQLConnection.Close();
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
