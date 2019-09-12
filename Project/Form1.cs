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
            if (sqlQueries.DoesUserExist(usernameTextBox.Text, passwordTextBox.Text).Rows[0][0].ToString() == "1")
            {
                sNumberLabel.Text = sqlQueries.AuthenticateLoginTwo(usernameTextBox.Text)["StudentNumber"].ToString();
                fullNameLabel.Text = sqlQueries.AuthenticateLoginTwo(usernameTextBox.Text)["FirstName"].ToString() + " " + sqlQueries.AuthenticateLoginTwo(usernameTextBox.Text)["LastName"].ToString();
                majorLabel.Text = sqlQueries.AuthenticateLoginTwo(usernameTextBox.Text)["Major"].ToString();
                coursesComboBox.SelectedIndex = 4;
                sqlQueries.DisplayAvailCourses(availCourseDGV);
                sqlQueries.DisplayEnrolledCourses(courseEnrollDGV, usernameTextBox.Text);
                cleanUp.UnsortableColumn(availCourseDGV);
                totalCostLabel.Text = "$" + Convert.ToString(sqlQueries.CartTotal());
                sqlQueries.DisplayCartCourses(courseCartDGV, usernameTextBox.Text);
                loginPagePanel.Visible = false;
                signUpPagePanel.Visible = false;
                enrollmentPanel.Visible = true;
                allCoursesRB.Checked = true;
            }
            else
            {
                MessageBox.Show("Please check your Username and Password");
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void JCoursesRB_CheckedChanged(object sender, EventArgs e)
        {
            string level = "Level = 'J'";
            string major = "= '" + coursesComboBox.Text + "'";
            if (coursesComboBox.Text == "All") 
            {
                major = "is not null";
                sqlQueries.DisplayAvailCourses(availCourseDGV,level, major);
            }
            else
            {
                sqlQueries.DisplayAvailCourses(availCourseDGV, level, major);
            }
        }

        private void SCoursesRB_CheckedChanged(object sender, EventArgs e)
        {
            string level = "Level = 'S'";
            string major = "= '" + coursesComboBox.Text + "'";
            if (coursesComboBox.Text == "All")
            {
                major = "is not null";
                sqlQueries.DisplayAvailCourses(availCourseDGV, level, major);
            }
            else
            {
                sqlQueries.DisplayAvailCourses(availCourseDGV, level, major);
            }
        }

        private void AllCoursesRB_CheckedChanged(object sender, EventArgs e)
        {
            string level = "(Level = 'J' or Level = 'S')";
            string major = "= '" + coursesComboBox.Text + "'";
            if (coursesComboBox.Text == "All")
            {
                sqlQueries.DisplayAvailCourses(availCourseDGV);
            }
            else
            {
                sqlQueries.DisplayAvailCourses(availCourseDGV, level, major);
            }
        }

        private void CoursesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((coursesComboBox.SelectedIndex == 4))
            {
                if (allCoursesRB.Checked == true)
                {
                    sqlQueries.DisplayAvailCourses(availCourseDGV);
                }
                else if (jCoursesRB.Checked == true)
                {
                    string level = "Level = 'J'";
                    string major = "is not null";
                    sqlQueries.DisplayAvailCourses(availCourseDGV, level, major);
                }
                else if (sCoursesRB.Checked == true)
                {
                    string level = "Level = 'S'";
                    string major = "is not null";
                    sqlQueries.DisplayAvailCourses(availCourseDGV, level, major);
                }
            }
            else if (coursesComboBox.SelectedIndex == 3)
            {
                if (allCoursesRB.Checked == true)
                {
                    string level = "(Level = 'J' or Level = 'S')";
                    string major = "= '" + coursesComboBox.Text + "'";
                    sqlQueries.DisplayAvailCourses(availCourseDGV, level, major);
                }
                else if (jCoursesRB.Checked == true)
                {
                    string level = "Level = 'J'";
                    string major = "= '" + coursesComboBox.Text + "'";
                    sqlQueries.DisplayAvailCourses(availCourseDGV, level, major);
                }
                else if (sCoursesRB.Checked == true)
                {
                    string level = "Level = 'S'";
                    string major = "= '" + coursesComboBox.Text + "'";
                    sqlQueries.DisplayAvailCourses(availCourseDGV, level, major);
                }
            }
            else if (coursesComboBox.SelectedIndex == 2)
            {
                if (allCoursesRB.Checked == true)
                {
                    string level = "(Level = 'J' or Level = 'S')";
                    string major = "= '" + coursesComboBox.Text + "'";
                    sqlQueries.DisplayAvailCourses(availCourseDGV, level, major);
                }
                else if (jCoursesRB.Checked == true)
                {
                    string level = "Level = 'J'";
                    string major = "= '" + coursesComboBox.Text + "'";
                    sqlQueries.DisplayAvailCourses(availCourseDGV, level, major);
                }
                else if (sCoursesRB.Checked == true)
                {
                    string level = "Level = 'S'";
                    string major = "= '" + coursesComboBox.Text + "'";
                    sqlQueries.DisplayAvailCourses(availCourseDGV, level, major);
                }
            }
            else if (coursesComboBox.SelectedIndex == 1)
            {
                if (allCoursesRB.Checked == true)
                {
                    string level = "(Level = 'J' or Level = 'S')";
                    string major = "= '" + coursesComboBox.Text + "'";
                    sqlQueries.DisplayAvailCourses(availCourseDGV, level, major);
                }
                else if (jCoursesRB.Checked == true)
                {
                    string level = "Level = 'J'";
                    string major = "= '" + coursesComboBox.Text + "'";
                    sqlQueries.DisplayAvailCourses(availCourseDGV, level, major);
                }
                else if (sCoursesRB.Checked == true)
                {
                    string level = "Level = 'S'";
                    string major = "= '" + coursesComboBox.Text + "'";
                    sqlQueries.DisplayAvailCourses(availCourseDGV, level, major);
                }
            }
            else if (coursesComboBox.SelectedIndex == 0)
            {
                if (allCoursesRB.Checked == true)
                {
                    string level = "(Level = 'J' or Level = 'S')";
                    string major = "= '" + coursesComboBox.Text + "'";
                    sqlQueries.DisplayAvailCourses(availCourseDGV, level, major);
                }
                else if (jCoursesRB.Checked == true)
                {
                    string level = "Level = 'J'";
                    string major = "= '" + coursesComboBox.Text + "'";
                    sqlQueries.DisplayAvailCourses(availCourseDGV, level, major);
                }
                else if (sCoursesRB.Checked == true)
                {
                    string level = "Level = 'S'";
                    string major = "= '" + coursesComboBox.Text + "'";
                    sqlQueries.DisplayAvailCourses(availCourseDGV, level, major);
                }
            }
        }

        private void AddToCartButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = availCourseDGV.SelectedRows[0];
            string firstString = usernameTextBox.Text;
            string secondString = sNumberLabel.Text;
            string cellZero = selectedRow.Cells[0].Value.ToString();
            string cellOne = selectedRow.Cells[1].Value.ToString();
            string cellTwo = selectedRow.Cells[2].Value.ToString();
            string cellThree = selectedRow.Cells[3].Value.ToString();

            if (sqlQueries.AddToCartValidate(firstString, cellZero).Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("You have already enrolled for this course");
            }
            else if (sqlQueries.Validate(usernameTextBox.Text, selectedRow.Cells[0].Value.ToString()).Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("You have already purchased this course");
            }
            else
            {
                sqlQueries.AddToCart(firstString, secondString, cellZero, cellOne, cellTwo, cellThree);
                mySQLConnection.Close();
                sqlQueries.DisplayCartCourses(courseCartDGV, firstString);
                cleanUp.UnsortableColumn(courseCartDGV);
                totalCostLabel.Text = "$" + Convert.ToString(sqlQueries.CartTotal());
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                string firstString = usernameTextBox.Text;
                DataGridViewRow selectedRow = courseCartDGV.SelectedRows[0];
                string query = "DELETE FROM js_CourseCart WHERE Code = '" + selectedRow.Cells[0].Value.ToString() + "' and Username = '" + firstString + "'";
                sqlQueries.DeleteCourse(query);
                sqlQueries.DisplayCartCourses(courseCartDGV, firstString);
                totalCostLabel.Text = "$" + Convert.ToString(sqlQueries.CartTotal());
            }
            catch (Exception)
            {
                MessageBox.Show("There are no courses selected to delete");
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                string firstString = usernameTextBox.Text;
                DataGridViewRow selectedRow = courseCartDGV.SelectedRows[0];
                string query = "DELETE FROM js_CourseCart WHERE Code = '" + selectedRow.Cells[0].Value.ToString() + "' and Username = '" + firstString + "'";
                sqlQueries.DeleteCourse(query);
                sqlQueries.DisplayCartCourses(courseCartDGV, firstString);
                totalCostLabel.Text = "$" + Convert.ToString(sqlQueries.CartTotal());
            }
            catch (Exception)
            {
                MessageBox.Show("There are no courses selected to delete");
            }
        }

        private void DeleteAllButton_Click(object sender, EventArgs e)
        {
            string firstString = usernameTextBox.Text;
            string query = "DELETE FROM js_CourseCart";
            sqlQueries.DeleteCourse(query);
            sqlQueries.DisplayCartCourses(courseCartDGV, firstString);
            totalCostLabel.Text = "$" + Convert.ToString(sqlQueries.CartTotal());
        }

        private void PurchaseButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = courseCartDGV.SelectedRows[0];
            string query = "DELETE FROM js_CourseCart WHERE Code = '" + selectedRow.Cells[0].Value.ToString() + "' and Username = '" + usernameTextBox.Text + "'";
            sqlQueries.PurchaseSingleCourse(usernameTextBox.Text, sNumberLabel.Text, selectedRow.Cells[0].Value.ToString(), selectedRow.Cells[1].Value.ToString(), selectedRow.Cells[2].Value.ToString(), selectedRow.Cells[3].Value.ToString(), DateTime.Now);
            sqlQueries.DeleteCourse(query);
            sqlQueries.DisplayCartCourses(courseCartDGV, usernameTextBox.Text);
            sqlQueries.DisplayEnrolledCourses(courseEnrollDGV, usernameTextBox.Text);
        }

        private void PurchaseAllButton_Click(object sender, EventArgs e)
        {

        }
    }
}
