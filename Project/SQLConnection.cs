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
        
        public void InsertTable(string query)
        {
            mySQLConnection.Close();
            mySQLConnection.Open();
            SqlDataAdapter mySDA = new SqlDataAdapter(query, mySQLConnection);
            mySDA.SelectCommand.ExecuteNonQuery();
        }

        public void DisplayTable(DataGridView firstDGV, string query)
        {
            mySQLConnection.Close();
            mySQLConnection.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, mySQLConnection);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            firstDGV.DataSource = dataTable;
        }

        public DataTable DoesRecordExist(string query)
        {
            mySQLConnection.Close();
            mySQLConnection.Open();
            SqlDataAdapter mySDA = new SqlDataAdapter(query, mySQLConnection);
            DataTable myDT = new DataTable();
            mySDA.Fill(myDT);
            return myDT;
        }

        public SqlDataReader ReadTableAndColumnOnce(string query)
        {
            mySQLConnection.Close();
            mySQLConnection.Open();
            SqlCommand mySQLCommand = new SqlCommand(query, mySQLConnection);
            SqlDataReader dataReader = mySQLCommand.ExecuteReader();
            dataReader.Read();
            return dataReader;
        }

        public List<string> ReadTableAndColumnMultiple(string query, string columnName, List<string> listString)
        {
            mySQLConnection.Close();
            mySQLConnection.Open();
            SqlCommand mySQLCommand = new SqlCommand(query, mySQLConnection);
            SqlDataReader dataReader = mySQLCommand.ExecuteReader();

            while (dataReader.Read())
            {
                string codeFromQuery = (dataReader)[columnName].ToString();
                listString.Add(codeFromQuery);
            }
            return listString;
        }

        public void UpdateTable(string query)
        {
            mySQLConnection.Close();
            mySQLConnection.Open();
            SqlDataAdapter mySDACost = new SqlDataAdapter(query, mySQLConnection);
            mySDACost.SelectCommand.ExecuteNonQuery();
        }

        public void DeleteTable(string query)
        {
            mySQLConnection.Close();
            mySQLConnection.Open();
            SqlDataAdapter mySqlSDA = new SqlDataAdapter(query, mySQLConnection);
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

        public void RadioButtonFilter (string comboBoxText, string level, DataGridView firstDGV)
        {
            SQLConnectionQueries sqlConnectionQueries = new SQLConnectionQueries();

            string major, query;
            major = "= '" + comboBoxText + "'";
            query = ("Select Code, Name, Major, Level, Cost from js_CourseInfo where (Level = '" + level + "') and Major " + major + "");

            if (comboBoxText == "All")
            {
                major = "is not null";
                query = ("Select Code, Name, Major, Level, Cost from js_CourseInfo where (Level = '" + level + "') and Major " + major + "");
                sqlConnectionQueries.DisplayTable(firstDGV, query);
            }
            else
            {
                sqlConnectionQueries.DisplayTable(firstDGV, query);
            }
        }

        public void ComboBoxSelectionFilter(RadioButton allCourse, RadioButton jCourse, RadioButton sCourse, string comboBoxText, DataGridView firstDGV)
        {
            SQLConnectionQueries sqlConnectionQueries = new SQLConnectionQueries();

            if (allCourse.Checked == true)
            {
                string level = "J' or Level = 'S";
                sqlConnectionQueries.RadioButtonFilter(comboBoxText, level, firstDGV);
            }
            else if (jCourse.Checked == true)
            {
                string level = "J";
                sqlConnectionQueries.RadioButtonFilter(comboBoxText, level, firstDGV);
            }
            else if (sCourse.Checked == true)
            {
                string level = "S";
                sqlConnectionQueries.RadioButtonFilter(comboBoxText, level, firstDGV);
            }
        }
    }
}
