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
            String mySQLQuery = ("INSERT INTO js_LoginInfo (Username,Password,ConfirmPassword,FirstName,LastName,Email,Gender,StudentNumber,Major) VALUES ('" + firstString + "', '" + secondString + "','" + thirdString + "','" + fourthString + "'," + "'" + fifthString + "','" + sixthString + "','" + seventhString + "', '" + eighthString + "', '" + ninthString + "')");
            SqlDataAdapter mySDA = new SqlDataAdapter(mySQLQuery, mySQLConnection);
            mySDA.SelectCommand.ExecuteNonQuery();
        }

        public DataTable DoesUserExist(string firstString, string secondString)
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

        public void DisplayAvailCourses(DataGridView firstDGV)
        {
            mySQLConnection.Close();
            mySQLConnection.Open();
            String mySQLQuery = ("Select Code, Name, Major, Level , Cost from js_CourseInfo");
            SqlDataAdapter sda = new SqlDataAdapter(mySQLQuery, mySQLConnection);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            firstDGV.DataSource = dataTable;
            mySQLConnection.Close();
        }

        public void DisplayAvailCourses(DataGridView firstDGV, string firstString, string secondString)
        {
            mySQLConnection.Open();
            String mySQLQuery = ("Select Code, Name, Major, Level from js_CourseInfo where " + firstString + " and Major " + secondString + "");
            SqlDataAdapter mySqlSDA = new SqlDataAdapter(mySQLQuery, mySQLConnection);
            DataTable dataTable = new DataTable();
            mySqlSDA.Fill(dataTable);
            firstDGV.DataSource = dataTable;
            mySQLConnection.Close();
        }

        public void AddToCart(string firstString, string secondString, string thirdString, string fourthString, string fifthString, string sixthString)
        {
            mySQLConnection.Close();
            mySQLConnection.Open();
            String mySQLQuery = ("INSERT INTO js_CourseCart VALUES ('" + firstString + "', '" + secondString + "','" + thirdString + "','" + fourthString + "'," + "'" + fifthString + "','" + sixthString + "' ,'')");
            SqlDataAdapter mySDA = new SqlDataAdapter(mySQLQuery, mySQLConnection);
            mySDA.SelectCommand.ExecuteNonQuery();
            String mySQLQueryCost = ("UPDATE js_CourseCart SET Cost = (SELECT cost FROM js_CourseInfo WHERE Username = '" + firstString + "' and Code = '" + thirdString + "') WHERE Username = '" + firstString + "' and Code = '" + thirdString + "'");
            SqlDataAdapter mySDACost = new SqlDataAdapter(mySQLQueryCost, mySQLConnection);
            mySDACost.SelectCommand.ExecuteNonQuery();
        }

        public DataTable AddToCartValidate(string firstString, string secondString)
        {
            mySQLConnection.Close();
            mySQLConnection.Open();
            String mySQLQuery = ("Select Count(*) From js_CourseCart where Username = '" + firstString + "' and Code = '" + secondString + "'");
            SqlDataAdapter mySDA = new SqlDataAdapter(mySQLQuery, mySQLConnection);
            DataTable myDT = new DataTable();
            mySDA.Fill(myDT);
            mySQLConnection.Close();
            return myDT;
        }

        public void DisplayCartCourses (DataGridView firstDGV, string firstString)
        {
            mySQLConnection.Close();
            mySQLConnection.Open();
            String mySQLQuery = ("Select Code, Name, Major, Level, Cost from js_CourseCart where Username = '" + firstString + "'");
            SqlDataAdapter mySqlSDA = new SqlDataAdapter(mySQLQuery, mySQLConnection);
            DataTable dataTable = new DataTable();
            mySqlSDA.Fill(dataTable);
            firstDGV.DataSource = dataTable;
            mySQLConnection.Close();
        }

        public void DeleteCourse(string firstString)
        {
            mySQLConnection.Close();
            mySQLConnection.Open();
            SqlDataAdapter mySqlSDA = new SqlDataAdapter(firstString, mySQLConnection);
            mySqlSDA.SelectCommand.ExecuteNonQuery();
        }

        public double CartTotal()
        {
            double initialValue = 0;
            double totalValue = 0;
            mySQLConnection.Close();
            mySQLConnection.Open();
            String mySqlQuery = ("Select Cost from js_CourseCart");
            SqlCommand mySQLCommand = new SqlCommand(mySqlQuery, mySQLConnection);
            SqlDataReader myDataReader = mySQLCommand.ExecuteReader();

            while (myDataReader.Read())
            {
                totalValue = initialValue + double.Parse(Convert.ToString(myDataReader[0]));
                initialValue = totalValue;
            }
            return totalValue;
        }

        public void PurchaseSingleCourse(string firstString, string secondString, string thirdString, string fourthString, string fifthString, string sixthString, DateTime dateTime)
        {
            mySQLConnection.Close();
            mySQLConnection.Open();
            String mySQLQuery = ("INSERT INTO js_CourseEnrolled (Username,StudentNumber,Code,Name,Major,Level,PurchaseTime) VALUES ('" + firstString + "', '" + secondString + "','" + thirdString + "','" + fourthString + "','" + fifthString + "','" + sixthString + "','"+ dateTime +"')");
            SqlDataAdapter mySDA = new SqlDataAdapter(mySQLQuery, mySQLConnection);
            mySDA.SelectCommand.ExecuteNonQuery();
        }

        public void DisplayEnrolledCourses(DataGridView firstDGV, string firstString)
        {
            mySQLConnection.Close();
            mySQLConnection.Open();
            String mySQLQuery = ("Select Code, Name, Major, Level, PurchaseTime from js_CourseEnrolled where Username = '" + firstString + "'");
            SqlDataAdapter mySqlSDA = new SqlDataAdapter(mySQLQuery, mySQLConnection);
            DataTable dataTable = new DataTable();
            mySqlSDA.Fill(dataTable);
            firstDGV.DataSource = dataTable;
            mySQLConnection.Close();
        }

        public DataTable Validate(string firstString, string secondString)
        {
            mySQLConnection.Close();
            mySQLConnection.Open();
            String mySQLQuery = ("Select Count(*) From js_CourseEnrolled where Username = '" + firstString + "' and Code = '" + secondString + "'");
            SqlDataAdapter mySDA = new SqlDataAdapter(mySQLQuery, mySQLConnection);
            DataTable myDT = new DataTable();
            mySDA.Fill(myDT);
            mySQLConnection.Close();
            return myDT;
        }
    }
}
