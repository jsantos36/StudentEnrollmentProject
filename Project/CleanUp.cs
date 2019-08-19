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

    }
}
