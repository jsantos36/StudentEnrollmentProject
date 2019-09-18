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
   public class CleanUp
    {
        public bool IsFieldMatch(string firstString, string secondString)
        {
            bool b = true;
            if (firstString != secondString)
            {
                b = false;
                return b;
            }
            else
                return b;
        }

        public bool IsFieldEmpty(string firstString)
        {
            bool b = true;
            if (String.IsNullOrWhiteSpace(firstString))
            {
                b = false;
                return b;
            }
            else
                return b;
        }

        public string GenerateStudentNumber (string firstString, string secondString)
        {
            string fNameFirstInitial;
            string lNameFirstInitial;
            string studentNumberGenerated = "";
            string studentNumber;

            char[] characters = "1234567890".ToCharArray();
            Random r = new Random();
            for (int i = 0; i < 7; i++)
            {
                studentNumberGenerated += characters[r.Next(0, characters.Length)].ToString();
            }
            fNameFirstInitial = firstString[0].ToString();
            lNameFirstInitial = secondString[0].ToString();
            studentNumber = fNameFirstInitial.ToLower() + lNameFirstInitial.ToLower() + "_" + studentNumberGenerated;
            return studentNumber;
        }

        public void UnsortableColumn(DataGridView firstDGV)
        {
            foreach (DataGridViewColumn column in firstDGV.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public void SetColumnWidth (DataGridView firstDGV)
        {
            DataGridViewColumn columnZero, columnOne, columnTwo, columnThree, columnFour;

            columnZero = firstDGV.Columns[0];
            columnOne = firstDGV.Columns[1];
            columnTwo = firstDGV.Columns[2];
            columnThree = firstDGV.Columns[3];
            columnFour = firstDGV.Columns[4];

            columnZero.Width = 55;
            columnOne.Width = 180;
            columnTwo.Width = 120;
            columnThree.Width = 40;
            columnFour.Width = 52;
        }
    }
}
