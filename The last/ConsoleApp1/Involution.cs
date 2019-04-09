using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Involution
    {
        public static string[] calculation = new string[] { "＋", "－", "×", "÷" };
        public static Random num = new Random();

        public static string Generate(string exe, int operators)
        {

            List<int> opcount = new List<int> { };
            int l = 0;
            for (int i = 0; i < exe.Length; i++)
            {
                string opstr = exe[i].ToString();
                if (opstr == "＋" || opstr == "－" || opstr == "×" || opstr == "÷")
                {
                    opcount.Add(i);
                    l++;
                }
            }
           return InvolutionSet( exe, opcount);
        }
        public static string InvolutionSet(string exe, List<int> opcount)
        {
            int rannum = num.Next(2, 5);
            foreach (int i in opcount)
            { 
              exe = exe.Insert(i, "^" + rannum);
            }
            return exe;
        }
    }
}
