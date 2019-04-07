using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine(CM10.Shunting("60.8-54.23"));
            // Console.WriteLine(CM30.IsDouble((CM10.Shunting("60.8-54.23")).ToString()));


            //Console.WriteLine("你是多少年级？？？？？、");
            //int s1 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("你想做多少道题？？？？？、");
            //int s2 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("你希望题中数的范围是多少？？？？？、");
            //int s3 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("你希望做多少个运算符以内的四则运算？？？？？、");
            //int s4 = Convert.ToInt32(Console.ReadLine());
            //CM21.IsGrades(s1, s2, s3, s4);

           Console.Write( CM22.FractionSet(0.7,0.6));
            //for (int i = 0; i <= s2; i++)
            //{
            //    Console.WriteLine(CM22.DecimalAndInteger(s3));
            //}

            //Console.WriteLine(s);
            Console.ReadKey();

            //string s = "(" + "1" + "+" + "3" + ")" + "*" + "10";
        }

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
        private static double[] score_reduction(double a, double b)
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
        private static double max(double a, double b)
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
