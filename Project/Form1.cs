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
        private string genderSignUp, genderEditProfile;
        SqlConnection mySQLConnection = new SqlConnection(@"Data Source=DESKTOP-M4EARNV\JONMSSQLSERVER;Initial Catalog=JONMSSQLSERVER-DB01;Persist Security Info=True;User ID=sa;Password=Rantaro60!");
        CleanUp cleanUp = new CleanUp();
        SQLConnectionQueries sqlConnectionQueries = new SQLConnectionQueries();

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
            genderSignUp = "Male";
        }

        private void FemaleSURB_CheckedChanged(object sender, EventArgs e)
        {
            genderSignUp = "Female";
        }

        private void RegSUBtn_Click(object sender, EventArgs e)
        {
            string sqlQuery, studentNumber;

            if (cleanUp.IsFieldMatch(passwordSUTextBox.Text, confirmPassSUTextBox.Text))
            {
                if (cleanUp.IsFieldEmpty(usernameSUTextBox.Text))
                {
                    try
                    {
                        studentNumber = (cleanUp.GenerateStudentNumber(fNameSUTextBox.Text, lNameSUTextBox.Text));
                        sqlQuery = ("INSERT INTO js_LoginInfo (Username,Password,ConfirmPassword,FirstName,LastName,Email,Gender,StudentNumber,Major) VALUES ('" + usernameSUTextBox.Text + "', '" + passwordSUTextBox.Text + "','" + confirmPassSUTextBox.Text + "','" + fNameSUTextBox.Text + "'," + "'" + lNameSUTextBox.Text + "','" + emailSUTextBox.Text + "','" + genderSignUp + "', '" + studentNumber + "', '" + majorComboBox.Text + "')");

                        sqlConnectionQueries.InsertTable(sqlQuery);
                        MessageBox.Show("Registered");

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
                MessageBox.Show("Password fields need to match");
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string getLoginInfoQuery, getLoginInfoValidationQuery, getAllCoursesQuery, getOnlyEnrolledCoursesQuery, getCourseCartQuery;
            getLoginInfoQuery = ("Select * From js_LoginInfo where Username = '" + usernameTextBox.Text + "'");
            getLoginInfoValidationQuery = ("Select Count(*) From js_LoginInfo where Username = '" + usernameTextBox.Text + "' and Password = '" + passwordTextBox.Text + "'");
            getAllCoursesQuery = ("Select Code, Name, Major, Level , Cost from js_CourseInfo");
            getOnlyEnrolledCoursesQuery = ("Select Code, Name, Major, Level, PurchaseTime from js_CourseEnrolled where Username = '" + usernameTextBox.Text + "'");
            getCourseCartQuery = ("Select Code, Name, Major, Level, Cost from js_CourseCart where Username = '" + usernameTextBox.Text + "'");

            if (sqlConnectionQueries.DoesRecordExist(getLoginInfoValidationQuery).Rows[0][0].ToString() == "1")
            {
                totalCostLabel.Text = "$" + Convert.ToString(sqlConnectionQueries.CartTotal());
                coursesComboBox.SelectedIndex = 4;
                loginPagePanel.Visible = false;
                signUpPagePanel.Visible = false;
                enrollmentPanel.Visible = true;
                allCoursesRB.Checked = true;

                sNumberLabel.Text = sqlConnectionQueries.ReadTableAndColumnOnce(getLoginInfoQuery)["StudentNumber"].ToString();
                fullNameLabel.Text = sqlConnectionQueries.ReadTableAndColumnOnce(getLoginInfoQuery)["FirstName"].ToString() + " " + sqlConnectionQueries.ReadTableAndColumnOnce(getLoginInfoQuery)["LastName"].ToString();
                majorLabel.Text = sqlConnectionQueries.ReadTableAndColumnOnce(getLoginInfoQuery)["Major"].ToString();

                sqlConnectionQueries.DisplayTable(availCourseDGV, getAllCoursesQuery);
                sqlConnectionQueries.DisplayTable(courseEnrollDGV, getOnlyEnrolledCoursesQuery);
                sqlConnectionQueries.DisplayTable(courseCartDGV, getCourseCartQuery);

                cleanUp.UnsortableColumn(availCourseDGV);
                cleanUp.UnsortableColumn(courseCartDGV);
                cleanUp.UnsortableColumn(courseEnrollDGV);
                cleanUp.SetColumnWidth(availCourseDGV);
                cleanUp.SetColumnWidth(courseCartDGV);

                try
                {
                    availCourseDGV.Rows[0].Selected = false;
                }
                catch { }
                try
                {
                    courseCartDGV.Rows[0].Selected = false;

                }
                catch { }
                try
                {
                    courseEnrollDGV.Rows[0].Selected = false;
                }
                catch { }
            }
            else
                MessageBox.Show("Please check your Username and Password");
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void JCoursesRB_CheckedChanged(object sender, EventArgs e)
        {
            string level = "J";
            sqlConnectionQueries.RadioButtonFilter(coursesComboBox.Text, level, availCourseDGV);
        }

        private void SCoursesRB_CheckedChanged(object sender, EventArgs e)
        {
            string level = "S";
            sqlConnectionQueries.RadioButtonFilter(coursesComboBox.Text, level, availCourseDGV);
        }

        private void AllCoursesRB_CheckedChanged(object sender, EventArgs e)
        {
            string level = "J' or Level = 'S";
            sqlConnectionQueries.RadioButtonFilter(coursesComboBox.Text, level, availCourseDGV);
        }

        private void CoursesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((coursesComboBox.SelectedItem.ToString() == "All"))
            {
                sqlConnectionQueries.ComboBoxSelectionFilter(allCoursesRB, jCoursesRB, sCoursesRB, coursesComboBox.Text, availCourseDGV);
            }
            else if (coursesComboBox.SelectedItem.ToString() == "Art")
            {
                sqlConnectionQueries.ComboBoxSelectionFilter(allCoursesRB, jCoursesRB, sCoursesRB, coursesComboBox.Text, availCourseDGV);
            }
            else if (coursesComboBox.SelectedItem.ToString() == "Business")
            {
                sqlConnectionQueries.ComboBoxSelectionFilter(allCoursesRB, jCoursesRB, sCoursesRB, coursesComboBox.Text, availCourseDGV);
            }
            else if (coursesComboBox.SelectedItem.ToString() == "Information Technology")
            {
                sqlConnectionQueries.ComboBoxSelectionFilter(allCoursesRB, jCoursesRB, sCoursesRB, coursesComboBox.Text, availCourseDGV);
            }
            else if (coursesComboBox.SelectedItem.ToString() == "Computer Science")
            {
                sqlConnectionQueries.ComboBoxSelectionFilter(allCoursesRB, jCoursesRB, sCoursesRB, coursesComboBox.Text, availCourseDGV);
            }
        }

        private void AddToCartButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = availCourseDGV.SelectedRows[0];
            string getCourseCartValidationQuery, getCourseEnrolledValidationQuery, insertToCourseCartQuery, updateToCourseCartQuery, getCourseCartQuery;
            getCourseCartValidationQuery = ("Select Count(*) From js_CourseCart where Username = '" + usernameTextBox.Text + "' and Code = '" + selectedRow.Cells[0].Value.ToString() + "'");
            getCourseEnrolledValidationQuery = ("Select Count(*) From js_CourseEnrolled where Username = '" + usernameTextBox.Text + "' and Code = '" + selectedRow.Cells[0].Value.ToString() + "'");
            insertToCourseCartQuery = ("INSERT INTO js_CourseCart (Username,StudentNumber,Code,Name,Major,Level) VALUES ('" + usernameTextBox.Text + "', '" + sNumberLabel.Text + "','" + selectedRow.Cells[0].Value.ToString() + "','" + selectedRow.Cells[1].Value.ToString() + "'," + "'" + selectedRow.Cells[2].Value.ToString() + "','" + selectedRow.Cells[3].Value.ToString() + "')");
            updateToCourseCartQuery = ("UPDATE js_CourseCart SET Cost = (SELECT cost FROM js_CourseInfo WHERE Username = '" + usernameTextBox.Text + "' and Code = '" + selectedRow.Cells[0].Value.ToString() + "') WHERE Username = '" + usernameTextBox.Text + "' and Code = '" + selectedRow.Cells[0].Value.ToString() + "'");
            getCourseCartQuery = ("Select Code, Name, Major, Level, Cost from js_CourseCart where Username = '" + usernameTextBox.Text + "'");

            if (sqlConnectionQueries.DoesRecordExist(getCourseCartValidationQuery).Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("This course is currently in your cart");
            }
            else if (sqlConnectionQueries.DoesRecordExist(getCourseEnrolledValidationQuery).Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("You are already enrolled for this course");
            }
            else if (selectedRow.Cells[2].Value.ToString().Trim() != majorLabel.Text)
            {
                MessageBox.Show("You can only apply to courses with your Major");
            }
            else
            {
                sqlConnectionQueries.InsertTable(insertToCourseCartQuery);
                sqlConnectionQueries.UpdateTable(updateToCourseCartQuery);
                sqlConnectionQueries.DisplayTable(courseCartDGV, getCourseCartQuery);

                totalCostLabel.Text = "$" + Convert.ToString(sqlConnectionQueries.CartTotal());
            }

            try
            {
                availCourseDGV.Rows[0].Selected = false;
            }
            catch { }
            try
            {
                courseCartDGV.Rows[0].Selected = false;

            }
            catch { }
            try
            {
                courseEnrollDGV.Rows[0].Selected = false;
            }
            catch { }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = courseCartDGV.SelectedRows[0];
                string deleteSelectedRowCourseCartQuery, getCourseCartQuery;
                deleteSelectedRowCourseCartQuery = ("DELETE FROM js_CourseCart WHERE Code = '" + selectedRow.Cells[0].Value.ToString() + "' and Username = '" + usernameTextBox.Text + "'");
                getCourseCartQuery = ("Select Code, Name, Major, Level, Cost from js_CourseCart where Username = '" + usernameTextBox.Text + "'");

                sqlConnectionQueries.DeleteTable(deleteSelectedRowCourseCartQuery);
                sqlConnectionQueries.DisplayTable(courseCartDGV, getCourseCartQuery) ;
                totalCostLabel.Text = "$" + Convert.ToString(sqlConnectionQueries.CartTotal());
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
                DataGridViewRow selectedRow = courseCartDGV.SelectedRows[0];
                string deleteSelectedRowCourseCartQuery, getCourseCartQuery;
                deleteSelectedRowCourseCartQuery = ("DELETE FROM js_CourseCart WHERE Code = '" + selectedRow.Cells[0].Value.ToString() + "' and Username = '" + usernameTextBox.Text + "'");
                getCourseCartQuery = ("Select Code, Name, Major, Level, Cost from js_CourseCart where Username = '" + usernameTextBox.Text + "'");

                sqlConnectionQueries.DeleteTable(deleteSelectedRowCourseCartQuery);
                sqlConnectionQueries.DisplayTable(courseCartDGV, getCourseCartQuery);
                totalCostLabel.Text = "$" + Convert.ToString(sqlConnectionQueries.CartTotal());
            }
            catch (Exception)
            {
                MessageBox.Show("There are no courses selected to delete");
            }
        }

        private void DeleteAllButton_Click(object sender, EventArgs e)
        {
            string deleteCourseCartQuery, getCourseCartQuery;
            deleteCourseCartQuery = ("DELETE FROM js_CourseCart");
            getCourseCartQuery = ("Select Code, Name, Major, Level, Cost from js_CourseCart where Username = '" + usernameTextBox.Text + "'");

            sqlConnectionQueries.DeleteTable(deleteCourseCartQuery);
            sqlConnectionQueries.DisplayTable(courseCartDGV, getCourseCartQuery);
            totalCostLabel.Text = "$" + Convert.ToString(sqlConnectionQueries.CartTotal());
        }

        private void PurchaseButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = courseCartDGV.SelectedRows[0];
                string getCourseCartQuery, deleteSelectedCourseCartQuery, insertCourseEnrolledQuery, getCourseEnrolledQuery;
                deleteSelectedCourseCartQuery = "DELETE FROM js_CourseCart WHERE Code = '" + selectedRow.Cells[0].Value.ToString() + "' and Username = '" + usernameTextBox.Text + "'";
                getCourseCartQuery = ("Select Code, Name, Major, Level, Cost from js_CourseCart where Username = '" + usernameTextBox.Text + "'");
                insertCourseEnrolledQuery = ("INSERT INTO js_CourseEnrolled (Username,StudentNumber,Code,Name,Major,Level,PurchaseTime) VALUES ('" + usernameTextBox.Text + "', '" + sNumberLabel.Text + "','" + selectedRow.Cells[0].Value.ToString() + "','" + selectedRow.Cells[1].Value.ToString() + "','" + selectedRow.Cells[2].Value.ToString() + "','" + selectedRow.Cells[3].Value.ToString() + "','" + DateTime.Now + "')");
                getCourseEnrolledQuery = ("Select Code, Name, Major, Level, PurchaseTime from js_CourseEnrolled where Username = '" + usernameTextBox.Text + "'");

                sqlConnectionQueries.InsertTable(insertCourseEnrolledQuery);
                sqlConnectionQueries.DeleteTable(deleteSelectedCourseCartQuery);
                sqlConnectionQueries.DisplayTable(courseCartDGV, getCourseCartQuery);
                sqlConnectionQueries.DisplayTable(courseEnrollDGV, getCourseEnrolledQuery);
                totalCostLabel.Text = "$" + Convert.ToString(sqlConnectionQueries.CartTotal());
            }
            catch (Exception)
            {
                MessageBox.Show("There are no courses selected to purchase");
            }

            try
            {
                availCourseDGV.Rows[0].Selected = false;
            }
            catch { }
            try
            {
                courseCartDGV.Rows[0].Selected = false;

            }
            catch { }
            try
            {
                courseEnrollDGV.Rows[0].Selected = false;
            }
            catch { }
        }

        private void PurchaseAllButton_Click(object sender, EventArgs e)
        {
            List<string> codeList = new List<string>();
            string addCodeToReadQueryQuery, getCourseEnrolledQuery, deleteCourseCartQuery, getCourseCartQuery;
            getCourseEnrolledQuery = ("Select Code, Name, Major, Level, PurchaseTime from js_CourseEnrolled where Username = '" + usernameTextBox.Text + "'");
            deleteCourseCartQuery = ("DELETE FROM js_CourseCart");
            getCourseCartQuery = ("Select Code, Name, Major, Level, Cost from js_CourseCart where Username = '" + usernameTextBox.Text + "'");
            addCodeToReadQueryQuery = ("Select * from js_CourseCart where Username = '" + usernameTextBox.Text + "'");

            sqlConnectionQueries.ReadTableAndColumnMultiple(addCodeToReadQueryQuery, "Code", codeList);
            for (int i = 0; i < codeList.Count; i++)
            {
                string readQuery = ("Select * from js_CourseCart where Code = '" + codeList[i] + "'");
                sqlConnectionQueries.ReadTableAndColumnOnce(readQuery);

                string insertQuery = ("INSERT INTO js_CourseEnrolled (Username,StudentNumber,Code,Name,Major,Level,PurchaseTime) VALUES ('" + sqlConnectionQueries.ReadTableAndColumnOnce(readQuery)["Username"].ToString() + "', '" + sqlConnectionQueries.ReadTableAndColumnOnce(readQuery)["StudentNumber"].ToString() + "','" + sqlConnectionQueries.ReadTableAndColumnOnce(readQuery)["Code"].ToString() + "','" + sqlConnectionQueries.ReadTableAndColumnOnce(readQuery)["Name"].ToString() + "','" + sqlConnectionQueries.ReadTableAndColumnOnce(readQuery)["Major"].ToString() + "','" + sqlConnectionQueries.ReadTableAndColumnOnce(readQuery)["Level"].ToString() + "','" + DateTime.Now + "')");
                sqlConnectionQueries.InsertTable(insertQuery);
            }

            sqlConnectionQueries.DeleteTable(deleteCourseCartQuery);
            sqlConnectionQueries.DisplayTable(courseEnrollDGV, getCourseEnrolledQuery);
            sqlConnectionQueries.DisplayTable(courseCartDGV, getCourseCartQuery);

            try
            {
                availCourseDGV.Rows[0].Selected = false;
            }
            catch { }
            try
            {
                courseCartDGV.Rows[0].Selected = false;

            }
            catch { }
            try
            {
                courseEnrollDGV.Rows[0].Selected = false;
            }
            catch { }
        }

        private void DeleteAllButtonCourseEnrolled_Click(object sender, EventArgs e)
        {
            string deleteCourseCartQuery, getCourseEnrolledQuery;
            deleteCourseCartQuery = ("DELETE FROM js_CourseEnrolled");
            getCourseEnrolledQuery = ("Select Code, Name, Major, Level, PurchaseTime from js_CourseEnrolled where Username = '" + usernameTextBox.Text + "'");

            sqlConnectionQueries.DeleteTable(deleteCourseCartQuery);
            sqlConnectionQueries.DisplayTable(courseEnrollDGV, getCourseEnrolledQuery);
            totalCostLabel.Text = "$" + Convert.ToString(sqlConnectionQueries.CartTotal());
        }

        private void DeleteButtonCourseEnrolled_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = courseEnrollDGV.SelectedRows[0];
                string deleteSelectedRowCourseCartQuery, getCourseEnrolledQuery;
                deleteSelectedRowCourseCartQuery = ("DELETE FROM js_CourseEnrolled WHERE Code = '" + selectedRow.Cells[0].Value.ToString() + "' and Username = '" + usernameTextBox.Text + "'");
                getCourseEnrolledQuery = ("Select Code, Name, Major, Level, PurchaseTime from js_CourseEnrolled where Username = '" + usernameTextBox.Text + "'");

                sqlConnectionQueries.DeleteTable(deleteSelectedRowCourseCartQuery);
                sqlConnectionQueries.DisplayTable(courseEnrollDGV, getCourseEnrolledQuery);
            }
            catch (Exception)
            {
                MessageBox.Show("There are no courses selected to delete");
            }
        }

        private void EditProfileLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string getUserLoginInfo;
            getUserLoginInfo = ("Select * from js_LoginInfo where Username = '" + usernameTextBox.Text+ "'");

            enrollmentPanel.Visible = false;
            loginPagePanel.Visible = false;
            signUpPagePanel.Visible = false;
            editProfilePanel.Visible = true;

            usernameEPTextBox.Text = sqlConnectionQueries.ReadTableAndColumnOnce(getUserLoginInfo)["Username"].ToString();
            passwordEPTextBox.Text = sqlConnectionQueries.ReadTableAndColumnOnce(getUserLoginInfo)["Password"].ToString();
            confirmPassEPTextBox.Clear();
            fNameEPTextBox.Text = sqlConnectionQueries.ReadTableAndColumnOnce(getUserLoginInfo)["FirstName"].ToString();
            lNameEPTextBox.Text = sqlConnectionQueries.ReadTableAndColumnOnce(getUserLoginInfo)["LastName"].ToString();
            emailEPTextBox.Text = sqlConnectionQueries.ReadTableAndColumnOnce(getUserLoginInfo)["Email"].ToString();
            majorEPComboBox.Text = sqlConnectionQueries.ReadTableAndColumnOnce(getUserLoginInfo)["Major"].ToString();
            if (sqlConnectionQueries.ReadTableAndColumnOnce(getUserLoginInfo)["Gender"].ToString() == "Male")
            {
                maleEPRB.Checked = true;
            }
            else
            {
                femaleEPRB.Checked = true;
            }
        }

        private void UpdateEPButton_Click(object sender, EventArgs e)
        {
            string updateLoginInfo, getLoginInfoQuery, getCourseEnrolledQuery;
            getLoginInfoQuery = ("Select * From js_LoginInfo where Username = '" + usernameTextBox.Text + "'");
            updateLoginInfo = ("Update js_LoginInfo set Password = '" + usernameEPTextBox.Text+ "', ConfirmPassword  = '" +confirmPassEPTextBox.Text + "', FirstName  = '" + fNameEPTextBox.Text + "', LastName  = '" + lNameEPTextBox.Text + "', Email  = '" + emailEPTextBox.Text + "', Gender  = '" + genderEditProfile + "', Major  = '" + majorEPComboBox.Text + "' WHERE Username  = '" + usernameEPTextBox.Text + "' ");
            getCourseEnrolledQuery = ("Select * from js_CourseEnrolled where Username = '" + usernameTextBox.Text + "'");

            if (cleanUp.IsFieldMatch(passwordEPTextBox.Text, confirmPassEPTextBox.Text))
            {
                try
                {
                    if (sqlConnectionQueries.ReadTableAndColumnOnce(getCourseEnrolledQuery)["Major"].ToString().Trim() == majorEPComboBox.Text)
                    {
                        sqlConnectionQueries.UpdateTable(updateLoginInfo);
                        MessageBox.Show("Information updated");
                        sNumberLabel.Text = sqlConnectionQueries.ReadTableAndColumnOnce(getLoginInfoQuery)["StudentNumber"].ToString();
                        fullNameLabel.Text = sqlConnectionQueries.ReadTableAndColumnOnce(getLoginInfoQuery)["FirstName"].ToString() + " " + sqlConnectionQueries.ReadTableAndColumnOnce(getLoginInfoQuery)["LastName"].ToString();
                        majorLabel.Text = sqlConnectionQueries.ReadTableAndColumnOnce(getLoginInfoQuery)["Major"].ToString();
                        loginPagePanel.Visible = false;
                        signUpPagePanel.Visible = false;
                        editProfilePanel.Visible = false;
                        enrollmentPanel.Visible = true;
                        allCoursesRB.Checked = true;
                    }
                    else
                        MessageBox.Show("You have bought courses from the current major you're in. Please delete the courses enrolled before changing majors");
                }
                catch 
                {
                    sqlConnectionQueries.UpdateTable(updateLoginInfo);
                    MessageBox.Show("Information updated");
                    sNumberLabel.Text = sqlConnectionQueries.ReadTableAndColumnOnce(getLoginInfoQuery)["StudentNumber"].ToString();
                    fullNameLabel.Text = sqlConnectionQueries.ReadTableAndColumnOnce(getLoginInfoQuery)["FirstName"].ToString() + " " + sqlConnectionQueries.ReadTableAndColumnOnce(getLoginInfoQuery)["LastName"].ToString();
                    majorLabel.Text = sqlConnectionQueries.ReadTableAndColumnOnce(getLoginInfoQuery)["Major"].ToString();
                    loginPagePanel.Visible = false;
                    signUpPagePanel.Visible = false;
                    editProfilePanel.Visible = false;
                    enrollmentPanel.Visible = true;
                    allCoursesRB.Checked = true;
                }
            }
            else
                MessageBox.Show("Password fields need to match");
        }

        private void MaleEPRB_CheckedChanged(object sender, EventArgs e)
        {
            genderEditProfile = "Male";
        }

        private void FemaleEPRB_CheckedChanged(object sender, EventArgs e)
        {
            genderEditProfile = "Female";
        }

        private void AvailCourseDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                courseCartDGV.Rows[0].Selected = false;
            }
            catch { }
            try
            {
                courseEnrollDGV.Rows[0].Selected = false;
            }
            catch { }
           
            try
            {
                DataGridViewRow selectedRowAvail = availCourseDGV.SelectedRows[0];
                string getProfessorInfo;
                getProfessorInfo = ("Select * from js_ProfessorInfo a INNER JOIN js_CourseInfo b on a.CourseCode = b.Code where b.Code = '" + selectedRowAvail.Cells[0].Value.ToString().Trim() + "'");

                courseCodeLabel.Text = sqlConnectionQueries.ReadTableAndColumnOnce(getProfessorInfo)["CourseCode"].ToString().Trim();
                courseNameLabel.Text = sqlConnectionQueries.ReadTableAndColumnOnce(getProfessorInfo)["CourseName"].ToString().Trim();
                professorLabel.Text = sqlConnectionQueries.ReadTableAndColumnOnce(getProfessorInfo)["Professor"].ToString().Trim();
                professorRatingLabel.Text = sqlConnectionQueries.ReadTableAndColumnOnce(getProfessorInfo)["Rating"].ToString().Trim();
                courseDescriptionTextBox.Text = sqlConnectionQueries.ReadTableAndColumnOnce(getProfessorInfo)["Description"].ToString().Trim();
            }
            catch { }
        }

        private void CourseEnrollDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                availCourseDGV.Rows[0].Selected = false;
            }
            catch { }
            try
            {
                courseCartDGV.Rows[0].Selected = false;
            }
            catch { }

            try
            {
                DataGridViewRow selectedRowEnroll = courseEnrollDGV.SelectedRows[0];
                string getProfessorInfo;
                getProfessorInfo = ("Select * from js_ProfessorInfo a INNER JOIN js_CourseInfo b on a.CourseCode = b.Code where b.Code = '" + selectedRowEnroll.Cells[0].Value.ToString().Trim() + "'");

                courseCodeLabel.Text = sqlConnectionQueries.ReadTableAndColumnOnce(getProfessorInfo)["CourseCode"].ToString().Trim();
                courseNameLabel.Text = sqlConnectionQueries.ReadTableAndColumnOnce(getProfessorInfo)["CourseName"].ToString().Trim();
                professorLabel.Text = sqlConnectionQueries.ReadTableAndColumnOnce(getProfessorInfo)["Professor"].ToString().Trim();
                professorRatingLabel.Text = sqlConnectionQueries.ReadTableAndColumnOnce(getProfessorInfo)["Rating"].ToString().Trim();
                courseDescriptionTextBox.Text = sqlConnectionQueries.ReadTableAndColumnOnce(getProfessorInfo)["Description"].ToString().Trim();
            }
            catch { }
        }

        private void CourseCartDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                availCourseDGV.Rows[0].Selected = false;
            }
            catch { }
            try
            {
                courseEnrollDGV.Rows[0].Selected = false;
            }
            catch { }

            try
            {
                DataGridViewRow selectedRowCart = courseCartDGV.SelectedRows[0];
                string getProfessorInfo;
                getProfessorInfo = ("Select * from js_ProfessorInfo a INNER JOIN js_CourseInfo b on a.CourseCode = b.Code where b.Code = '" + selectedRowCart.Cells[0].Value.ToString().Trim() + "'");

                courseCodeLabel.Text = sqlConnectionQueries.ReadTableAndColumnOnce(getProfessorInfo)["CourseCode"].ToString().Trim();
                courseNameLabel.Text = sqlConnectionQueries.ReadTableAndColumnOnce(getProfessorInfo)["CourseName"].ToString().Trim();
                professorLabel.Text = sqlConnectionQueries.ReadTableAndColumnOnce(getProfessorInfo)["Professor"].ToString().Trim();
                professorRatingLabel.Text = sqlConnectionQueries.ReadTableAndColumnOnce(getProfessorInfo)["Rating"].ToString().Trim();
                courseDescriptionTextBox.Text = sqlConnectionQueries.ReadTableAndColumnOnce(getProfessorInfo)["Description"].ToString().Trim();
            }
            catch { }
        }

        private void EnrollmentBackButton_Click(object sender, EventArgs e)
        {
            loginPagePanel.Visible = true;
            signUpPagePanel.Visible = false;
            enrollmentPanel.Visible = false;
            usernameTextBox.Clear();
            passwordTextBox.Clear();
        }

        private void BackEPButton_Click(object sender, EventArgs e)
        {
            loginPagePanel.Visible = false;
            signUpPagePanel.Visible = false;
            editProfilePanel.Visible = false;
            enrollmentPanel.Visible = true;
            allCoursesRB.Checked = true;
        }
    }
}
