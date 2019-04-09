using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CM30
    {
        private static Random number = new Random(); //实例化一个随机数
        private static DataTable dt = new DataTable();
        private static string number1;
        private static int bo = number.Next(1, 5);
        private static string[] calculation = new string[] { "＋", "－", "×", "÷" };
        /// <summary>
        /// 判断输入的类型是否为整数
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static bool IsNumber(string input)
        {
            if (Regex.IsMatch(input, @"^[+-]?\d*[.]?$"))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 判断输入的类型是否为合格的小数
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsDouble(string expression)
        {
            int st = 0;
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '.')
                { st = i; break; }
                st = i;
            }
            if (expression.Length - st - 1 > 3)
                return false;
            return true;
        }
        /// <summary>
        /// 公式配置与运算
        /// </summary>
        /// <param name="Range">数据范围</param>
        public static void OpNumber(int Range, int exercises, int Operators, string[] OperatorsClass, bool IsFraction, bool IsDecimal, bool IsInvolution, ref List<string> Expression, ref List<string> Answer)
        {
          
            for (int i = 0; i < exercises; i++)
            {
                bo = number.Next(1,4);
                if (IsFraction&&bo==1)
                {
                    string[] es1 = Exercises_Fraction(Operators, OperatorsClass, calculation, IsDecimal, IsFraction, IsInvolution);
                    Expression.Add( "(" + (i + 1) + ")、" + es1[0] + "=");
                    Answer.Add("(" + (i + 1) + ")、" + es1[1]);
                    //Expression[i] = "(" + (i + 1) + ")、" + es1[0] + "=";
                    //Answer[i] = "(" + (i + 1) + ")、" + es1[1];
                    Console.WriteLine(es1[0] + "=" + es1[1]);
                    i++;
                }
               
                string[] es = Exercises(Range, Operators, OperatorsClass, calculation, IsDecimal, IsFraction, IsInvolution);
                Expression.Add("(" + (i + 1) + ")、" + es[0] + "=");
                Answer.Add("(" + (i + 1) + ")、" + es[1]);
                //Expression[i] = "(" + (i + 1) + ")、" + es[0] + "=";
                //Answer[i] = "(" + (i + 1) + ")、" + es[1];
                Console.WriteLine(es[0] + "=" + es[1]);               
            }

        }
        /// <summary>
        /// 产生题目和结果
        /// </summary>
        /// <param name="Range">范围</param>
        /// <param name="Operators">符号数</param>
        /// <param name="OperatorsClass">符号类型</param>
        /// <param name="calculation"></param>
        /// <param name=" IsDecimal"></param>
        /// <returns></returns>
        private static string[] Exercises(int Range, int Operators, string[] OperatorsClass, string[] calculation, bool IsDecimal, bool IsFraction, bool IsInvolution)
        {
            List<string> Result = new List<string>();
            string Formula = "";
            number1 = Random_Number(IsDecimal, Range).ToString();//随机一个初始数            
            int OP = number.Next(0, Operators);//随机运算符数量         
            Formula += number1;
            Splicing(Range, Operators, OperatorsClass, calculation, IsDecimal, ref Formula, OP);
           
            int lbo = number.Next(1, 4);
            if (IsInvolution && lbo == 2)
            {
                Formula= Involution.Generate(Formula, Operators);
            }
            Result.Add(Formula);
            Result.Add(CM10.Shunting(Formula).ToString());
            return Result.ToArray();
        }
        public static string[] Exercises_Fraction(int Operators, string[] OperatorsClass, string[] calculation, bool IsDecimal, bool IsFraction, bool IsInvolution)
        {
            List<string> Result = new List<string>();
            string Formula = "";
            number1 = Random_Fraction();//随机一个初始数            
            int OP = number.Next(0, Operators);//随机运算符数量         
            Formula += number1;
            Splicing_Fraction(Operators, OperatorsClass, calculation, IsDecimal, ref Formula, OP);
            Result.Add(Formula);
            Result.Add(CM10.Shunting(Formula).ToString());
            return Result.ToArray();
        }

        private static void Splicing(int Range, int Operators, string[] OperatorsClass, string[] calculation, bool IsDecimal, ref string Formula, int OP)
        {
            for (int j = 0; j <= OP; j++)
            {
                calculation = OperatorsClass;
                int opnext = number.Next(0, calculation.Length);//随机一个符号
                string number2 = Random_Number(IsDecimal, Range).ToString();//随机一个数
                if (opnext == 3 && number2 == "0")//判断算式是否存在除0              
                    number2 = Random_Number(IsDecimal, Range).ToString();//重新随机一个数                
                Formula += calculation[opnext] + number2;
                if (Condition(Range, Operators, OperatorsClass, calculation, ref Formula, IsDecimal))
                    break;
            }
        }
        private static void Splicing_Fraction( int Operators, string[] OperatorsClass, string[] calculation, bool IsInvolution, ref string Formula, int OP)
        {
            for (int j = 0; j <= OP; j++)
            {
                calculation = OperatorsClass;
                int opnext = number.Next(0, calculation.Length);//随机一个符号
                string number2 =Random_Fraction();//随机一个数
                if (opnext == 3 && number2 == "0")//判断算式是否存在除0              
                    number2 = Random_Fraction();//重新随机一个数                
                Formula += calculation[opnext] + number2;
                if (Condition_Fraction(Operators, OperatorsClass, calculation, ref Formula, IsInvolution))
                    break;
            }
        }
        /// <summary>
        /// 重构判断题目计算过程中是否有负数或除0
        /// </summary>
        /// <param name="Range"></param>
        /// <param name="Operators"></param>
        /// <param name="OperatorsClass"></param>
        /// <param name="calculation"></param>
        /// <param name="performance"></param>
        /// <param name="Formula"></param>
        /// <param name="Formulanum"></param>
        /// <param name=" IsDecimal"></param>
        /// <returns></returns>
        private static bool Condition(int Range, int Operators, string[] OperatorsClass, string[] calculation, ref string Formula, bool IsDecimal)
        {
            if (Convert.ToDouble(CM10.Shunting(Formula).ToString()) < 0 || !IsDouble(CM10.Shunting(Formula).ToString()) && IsDecimal)
            {
                string[] es = Exercises(Range, Operators, OperatorsClass, calculation, IsDecimal, false, false);
                Formula = es[0];
                return true;
            }
            if (!IsNumber(CM10.Shunting(Formula).ToString()) && !IsDecimal)
            {
                string[] es = Exercises(Range, Operators, OperatorsClass, calculation, IsDecimal, false, false);
                Formula = es[0];
                return true;
            }
            return false;
        }
        private static bool Condition_Fraction(int Operators, string[] OperatorsClass, string[] calculation, ref string Formula,bool IsInvolution)
        {
            if (!negative_fraction(CM10.Shunting(Formula).ToString()) || !IsDouble(CM10.Shunting(Formula).ToString()) && IsInvolution)
            {
                string[] es = Exercises_Fraction( Operators, OperatorsClass, calculation, IsInvolution, false, false);
                Formula = es[0];
                return true;
            }
            if (!IsNumber(CM10.Shunting(Formula).ToString()) && !IsInvolution)
            {
                string[] es = Exercises_Fraction( Operators, OperatorsClass, calculation, IsInvolution, false, false);
                Formula = es[0];
                return true;
            }
            return false;
        }
        private static bool negative_fraction(string s)
        {
            for(int i=0;i<s.Length;i++)
            {
                if (s[i]=='-'||s[i]=='0')
                {
                    return false;
                }
            }
            return true;
        }
            private static string Brackets(string result)
        {
            string brack = "()";
            result.Insert(0, brack[0].ToString());
            for (int s = 0; s < result.Length; s++)
            {
                if (result[s] == '+' || result[s] == '-')
                {

                }
            }
            return "";
        }
        //随机生成小数或整数
        public static double Random_Number(bool IsDecimal, int Range)
        {
            double s = 0.1;
            if (IsDecimal)
            {
                if (bo == 1)//生成小数
                {
                    Range = Range * 100;
                    s = number.Next(1, Range + 1);
                    return s / 100;
                }
            }
            s = number.Next(1, Range + 1);
            return s;
        }
        public static string Random_Fraction()
        {
            double s = 0.1;
            s = number.Next(1, 10);
            s = s / 10;
            return score(s);
        }

        /// <summary>
        /// 小数转分数
        /// </summary>
        /// <param name="d">小数</param>
        /// <returns></returns>
        public static string score(double d)
        {
            string dn = Regex.Match(d.ToString(), @"(?<=\.)\d+").Value;//去小数点
            int denominator = 1;
            for (int i = dn.Length; i > 0; i--)
            {
                denominator *= 10;
            }
            double[] sr = score_reduction(d * denominator, denominator);
            return sr[0].ToString() + "/" + sr[1].ToString();
        }

        /// <summary>
        /// 分数化简
        /// </summary>
        /// <param name="a">分子</param>
        /// <param name="b">分母</param>
        /// <returns></returns>
        public static double[] score_reduction(double a, double b)
        {
            double max_nub = 0;
            if (a % b == 0 || b % a == 0)
            {
                max_nub = a > b ? b : a;
            }
            max_nub = max(a, b);//求最大公约数          
            b = b / max_nub;
            a = a / max_nub;
            double[] score = new double[] { a, b };
            return score;
        }

        /// <summary>
        /// 求公约数
        /// </summary>
        /// <param name="a">分子</param>
        /// <param name="b">分母</param>
        /// <returns></returns>
        public static double max(double a, double b)
        {
            while (b != 0)
            {
                double maxNum = a % b;
                a = b;
                b = maxNum;
            }
            return a;
        }
    }
}
