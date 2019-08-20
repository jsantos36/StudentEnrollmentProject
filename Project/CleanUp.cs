using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
   public class CleanUp
    {
        public bool MatchField(string firstString, string secondString)
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

        public bool EmptyField(string firstString)
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

        public string StudentNumberGenerator (string firstString, string secondString)
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
    }
}
