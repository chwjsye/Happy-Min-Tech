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
        private static double number1 = 0.1;
        private static int bo = number.Next(1, 10);
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
        /// <param name="Number">初始数</param>
        /// <param name="Range">数据范围</param>
        public static void OpNumber(int Range, int exercises, int Operators, int OperatorsClass, bool IsFraction, bool IsDecimal, bool IsInvolution, ref string[] Expression, ref string[] Answer)
        {
            string[] calculation = new string[] { "＋", "－", "×", "÷" };
            string[] performance = new string[] { "+", "-", "*", "/" };
            for (int i = 0; i < exercises; i++)
            {
                string[] es = Exercises(Range, Operators, OperatorsClass, calculation, performance,IsDecimal);
                Expression[i] = "(" + (i + 1) + ")、" + es[1] + "=";
                Answer[i] = "(" + (i + 1) + ")、" + es[2];
                Console.WriteLine(es[1] + "=" + es[2]);
            }

        }
        /// <summary>
        /// 产生题目和结果
        /// </summary>
        /// <param name="Range"></param>
        /// <param name="Operators"></param>
        /// <param name="OperatorsClass"></param>
        /// <param name="calculation"></param>
        /// <param name="performance"></param>
        /// <param name=" IsDecimal"></param>
        /// <returns></returns>
        private static string[] Exercises(int Range, int Operators, int OperatorsClass, string[] calculation, string[] performance, bool  IsDecimal)
        {
            List<string> Result = new List<string>();
            string Formula = "", Formulanum = "";
            if ( IsDecimal == true)
            {
                number1 = Random_Number( IsDecimal, Range);//随机一个初始数
            }
            int OP = number.Next(0, Operators);//随机运算符数量         
            Formulanum = Formula += number1;
            Splicing(Range, Operators, OperatorsClass, calculation, performance,  IsDecimal, ref Formula, ref Formulanum, OP);
            Result.Add(Formulanum);
            Result.Add(Formula);
            Result.Add(CM10.Shunting(Formulanum).ToString());
            return Result.ToArray();
        }
       

        private static void Splicing(int Range, int Operators, int OperatorsClass, string[] calculation, string[] performance, bool  IsDecimal, ref string Formula, ref string Formulanum, int OP)
        {
            for (int j = 0; j <= OP; j++)
            {
                int opnext = number.Next(0, OperatorsClass);//随机一个符号
                double number2 = Random_Number( IsDecimal, Range);//随机一个数
                if (opnext == 3 && number2 == 0)//判断算式是否存在除0              
                    number2 = Random_Number( IsDecimal, Range);//重新随机一个数                
                Formula += calculation[opnext] + number2;
                Formulanum += performance[opnext] + number2;
                if (Condition(Range, Operators, OperatorsClass, calculation, performance, ref Formula, ref Formulanum,  IsDecimal))
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
        private static bool Condition(int Range, int Operators, int OperatorsClass, string[] calculation, string[] performance, ref string Formula, ref string Formulanum, bool  IsDecimal)
        {
            if (Convert.ToDouble(CM10.Shunting(Formulanum).ToString()) < 0 || !IsDouble(dt.Compute(Formulanum, "null").ToString()) &&  IsDecimal)
            {
                string[] es = Exercises(Range, Operators, OperatorsClass, calculation, performance,  IsDecimal);
                Formulanum = es[0];
                Formula = es[1];
                return true;
            }
            if (!IsNumber(dt.Compute(Formulanum, "null").ToString()) && ! IsDecimal)
            {
                string[] es = Exercises(Range, Operators, OperatorsClass, calculation, performance,  IsDecimal);
                Formulanum = es[0];
                Formula = es[1];
                return true;
            }
            return false;
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
           
            if ( IsDecimal)
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
    }
}
