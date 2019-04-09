using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class CM22
    {

        private static Random l = new Random();
        public static string[] calculation = new string[] { "＋", "－", "×", "÷" };
        //用户自定义
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exercises">题目数量</param>
        /// <param name="range">数据范围</param>
        /// <param name="operators">符号数量</param>
        /// <param name="operatorClass">符号种类</param>
        /// <param name="isFraction">是否支持真分数运算</param>
        /// <param name="isDecimal">是否支持小数运算</param>
        /// <param name="isInvolution">是否支持乘方运算</param>
        public static void ProblemSet(int exercises, int range, int operators, string[] operatorClass, bool isFraction, bool isDecimal, bool isInvolution)
        {
            List<string> Expression = new List<string>();
            List<string> Answer = new List<string>();
            int Rannum = l.Next(1, 3);
            if (isFraction && Rannum == 1)//带分数
            {
                CM30.OpNumber(range, exercises, operators, operatorClass, true, true, false, ref Expression, ref Answer);
                CM21.Injection(Expression.ToArray(), Answer.ToArray());
            }
            else//带小数
            {
                CM30.OpNumber(range, exercises, operators, operatorClass, false, true, false, ref Expression, ref Answer);
                CM21.Injection(Expression.ToArray(), Answer.ToArray());
            }


        }



    }
}