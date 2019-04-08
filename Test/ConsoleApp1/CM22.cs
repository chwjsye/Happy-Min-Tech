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
        public static void ProblemSet(int exercises, int range, int operators, int operatorClass, bool isFraction, bool isDecimal, bool isInvolution)
        {
            for (int i = 0; i <= range; i++)
            {
                if (isFraction)//分数
                {

                }
                if (isDecimal)//小数
                {
                    CM30.Random_Number(isDecimal, range);
                }
                if (isInvolution)//乘方
                {

                }
            }
        }
        //分数配置
        public static Fraction_Math FractionSet(double num1, double num2)
        {
            Fraction_Math Franction = new Fraction_Math();
            int opnext = l.Next(4,5);
            Fraction_Math result = null;
            Franction.Denominator = num1;
            Franction.Numerator = num2;
            switch (opnext)
            {
                case 1:
                    result = Franction.Add(num1, num2);
                    break;
                case 2:
                    result = Franction.Sub(num1, num2);
                    break;
                case 3:
                    result = Franction.Multiple(num1, num2);
                    break;
                case 4:
                    result = Franction.Divided(num1, num2);
                    break;
            }
            return result ;
        }

    }
}