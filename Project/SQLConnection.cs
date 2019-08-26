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
using System.Collections;

namespace Project
{
    public class SQLConnectionQueries
    {
        SqlConnection mySQLConnection = new SqlConnection(@"Data Source=DESKTOP-M4EARNV\JONMSSQLSERVER;Initial Catalog=JONMSSQLSERVER-DB01;Persist Security Info=True;User ID=sa;Password=Rantaro60!");

        public void InsertLoginInfo(string firstString, string secondString, string thirdString, string fourthString, string fifthString, string sixthString, string seventhString, string eighthString, string ninthString)
        {
            mySQLConnection.Open();
            String mySQLQuery = ("INSERT INTO js_LoginInfo (Username,Password,ConfirmPassword,FirstName,LastName,Email,Gender,StudentNumber,Major) VALUES ('" + firstString + "', '" + secondString + "','" + thirdString + "','" + fourthString + "'," + "'" + fifthString + "','" + sixthString + "','" + seventhString + "', '" + eighthString+ "', '" + ninthString + "')");
            SqlDataAdapter mySDA = new SqlDataAdapter(mySQLQuery, mySQLConnection);
            mySDA.SelectCommand.ExecuteNonQuery();
        }

        public DataTable AuthenticateLoginOne(string firstString, string secondString)
        {
            mySQLConnection.Close();
            mySQLConnection.Open();
            String mySQLQuery = ("Select Count(*) From js_LoginInfo where Username = '" + firstString + "' and Password = '" + secondString + "'");
            SqlDataAdapter mySDA = new SqlDataAdapter(mySQLQuery, mySQLConnection);
            DataTable myDT = new DataTable();
            mySDA.Fill(myDT);
            mySQLConnection.Close();
            return myDT;
        }

        public SqlDataReader AuthenticateLoginTwo(string firstString)
        {
            mySQLConnection.Close();
            mySQLConnection.Open();
            String mySQLQueryLogin = ("Select * From js_LoginInfo where Username = '" + firstString + "'");
            SqlCommand mySQLCommand = new SqlCommand(mySQLQueryLogin, mySQLConnection);
            SqlDataReader myDataReaderLogin = mySQLCommand.ExecuteReader();
            myDataReaderLogin.Read();
            return myDataReaderLogin;
        }

        public void DisplayAvailCourses (DataGridView firstDGV)
        {
            mySQLConnection.Close();
            mySQLConnection.Open();
            String mySQLQuery = ("Select Code, Name, Major, Level from js_CourseInfo");
            SqlDataAdapter sda = new SqlDataAdapter(mySQLQuery, mySQLConnection);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            firstDGV.DataSource = dataTable;
            mySQLConnection.Close();
        }

        public void DisplayAvailCoursesJunior (DataGridView firstDGV)
        {
            mySQLConnection.Open();
            String mySQLQuery = ("Select Code, Name, Major, Level from js_CourseInfo where Level = 'J'");
            SqlDataAdapter mySqlSDA = new SqlDataAdapter(mySQLQuery, mySQLConnection);
            DataTable dataTable = new DataTable();
            mySqlSDA.Fill(dataTable);
            firstDGV.DataSource = dataTable;
            mySQLConnection.Close();
        }

        public void DisplayAvailCoursesSenior(DataGridView firstDGV)
        {
            mySQLConnection.Open();
            String mySQLQuery = ("Select Code, Name, Major, Level from js_CourseInfo where Level = 'S'");
            SqlDataAdapter mySqlSDA = new SqlDataAdapter(mySQLQuery, mySQLConnection);
            DataTable dataTable = new DataTable();
            mySqlSDA.Fill(dataTable);
            firstDGV.DataSource = dataTable;
            mySQLConnection.Close();
        }
    }
}
