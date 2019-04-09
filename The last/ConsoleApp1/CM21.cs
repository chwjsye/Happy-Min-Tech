using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ConsoleApp1
{

    class CM21
    {
        public static string[] calculation = new string[] { "＋", "－", "×", "÷" };
        //年级配置
        /// <summary>
        /// 
        /// </summary>
        /// <param name="grades">年级</param>
        /// <param name="exercises">题目数量</param>
        /// <param name="range">范围</param>
        /// <param name="Operators">符号</param>
        public static void IsGrades(int grades, int exercises, int range, int Operators)
        {
            List<string> Expression = new List<string>();
            List<string> Answer = new List<string>();
            switch (grades)
            {
                case 1:
                    calculation = new string[] { "＋", "－" };
                    CM30.OpNumber(range, exercises, Operators, calculation, false, false, false, ref Expression, ref Answer);
                    Injection(Expression.ToArray(), Answer.ToArray());
                    break;
                case 2:
                    CM30.OpNumber(range, exercises, Operators, calculation, false, false, false, ref Expression, ref Answer);
                    Injection(Expression.ToArray(), Answer.ToArray());
                    break;
                case 3:
                    CM30.OpNumber(range, exercises, Operators, calculation, true, false, false, ref Expression, ref Answer);
                    Injection(Expression.ToArray(), Answer.ToArray());
                    break;
                case 4:
                    CM30.OpNumber(range, exercises, Operators, calculation, true, true, false, ref Expression, ref Answer);
                    Injection(Expression.ToArray(), Answer.ToArray());
                    break;
                case 5:
                    CM30.OpNumber(range, exercises, Operators, calculation, true, true, false, ref Expression, ref Answer);
                    Injection(Expression.ToArray(), Answer.ToArray());
                    break;
                case 6:
                    CM30.OpNumber(range, exercises, Operators, calculation, true, true, true, ref Expression, ref Answer);
                    Injection(Expression.ToArray(), Answer.ToArray());
                    break;
                default: break;
            }

        }
        //注入表达式和答案
        public static void Injection(string[] Expression, string[] Answer)
        {
            Generate_Expression(Expression);
            Generate_Answer(Answer);
        }
        //打印题目TXT
        public static void Generate_Expression(string[] Expression)
        {
            using (StreamWriter sw = new StreamWriter("Exercise.txt"))
            {
                sw.Flush();
                foreach (string dir in Expression)
                {
                    sw.WriteLine(dir);
                }
                sw.Close();
            }
        }
        //打印答案TXT
        public static void Generate_Answer(string[] Answer)
        {
            using (StreamWriter sw = new StreamWriter("Answer.txt"))
            {
                sw.Flush();
                foreach (string dir in Answer)
                {
                    sw.WriteLine(dir);
                }
                sw.Close();
            }
        }

    }
}
