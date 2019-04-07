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
        public static double FractionSet(double num1, double num2)
        {
            Fraction_Math Franction = new Fraction_Math();
            int opnext = l.Next(2,3);
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
            return result.Numerator ;
        }

    }
}