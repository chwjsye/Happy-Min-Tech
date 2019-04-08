using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Fraction_Math
    {
        public static string Fraction(string d1, string d2, char c1)
        {
            Fraction_Math fraction_Math = new Fraction_Math();
            DataTable dt = new DataTable();
            Fraction_Math D1 =Score(d1), D2 = Score(d2);
            string s;
            switch (c1)
            {
                case '＋':
                    Fraction_Math st = fraction_Math.Add(D1, D2);
                    s = st.Numerator + "/" + st.Denominator;
                    break;
                case '－':
                    st = fraction_Math.Sub(D1, D2);
                    s = st.Numerator + "/" + st.Denominator;
                    break;
                case '×':
                    st = fraction_Math.Multiple(D1, D2);
                    s = st.Numerator + "/" + st.Denominator;
                    break;
                case '÷':
                    st = fraction_Math.Divided(D1, D2);
                    s = st.Numerator + "/" + st.Denominator;
                    break;
                default:
                    s = null;
                    break;
            }
            
            if (Regex.IsMatch(dt.Compute(s, null).ToString(), @"^[+-]?\d*[.]?$"))
            {
                return dt.Compute(s, null).ToString();
            }          
            return s;
        }

        public static Fraction_Math Score(string fraction)
        {

            Fraction_Math fraction_Math = new Fraction_Math();
            if(!IsFractioon(fraction))
            {
                fraction_Math.Numerator = Convert.ToDouble(fraction) * Convert.ToDouble(fraction);
                fraction_Math.Denominator = Convert.ToDouble(fraction);
                return fraction_Math;
            }
            string n=null, m=null;
            n = fraction.Substring(0, Fraction_Math.Appoint(fraction));
            m = fraction.Substring(Fraction_Math.Appoint(fraction) + 1, fraction.Length - 1 - Fraction_Math.Appoint(fraction));
            fraction_Math.Numerator =Convert.ToDouble(n);
            fraction_Math.Denominator = Convert.ToDouble(m);
            return fraction_Math;
        }
        public static bool IsFractioon(string a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == '/')
                {
                    return true;
                }
            }
            return false;
        }
        public static int Appoint(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '/')
                {
                    return i;
                }
            }
            return 0;
        }
        #region
            

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
        #endregion


        #region property

        private double _denominator;

        /// <summary>
        /// 分母
        /// </summary>
        public double Denominator
        {
            get
            {
                return _denominator;
            }
            set
            {
                if (value == 0)
                {
                    throw new InvalidOperationException("分母不能为0");
                }
                _denominator = value;
            }
        }

        /// <summary>
        /// 分子
        /// </summary>
        public double Numerator { get; set; }

        #endregion

        #region constructor

        public Fraction_Math()
        {

        }

        /// <summary>
        /// 创建分数(默认分母为1)
        /// </summary>
        /// <param name="numerator">分子</param>
        public Fraction_Math(double numerator)
        {
            Numerator = numerator;
            _denominator = 1;
        }

        /// <summary>
        /// 创建分数
        /// </summary>
        /// <param name="numerator">分子</param>
        /// <param name="denominator">分母</param>
        public Fraction_Math(double numerator, double denominator)
        {
            Numerator = numerator;
            _denominator = denominator;
        }

        #endregion

        #region method

       
        /// <summary>
        /// 计算两个分数的相加,并返回一个分数
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <returns></returns>
        public Fraction_Math Add(Fraction_Math f1, Fraction_Math f2)
        {
            Fraction_Math result = new Fraction_Math();
            double dencominator = CalculateLeaseCommonMultiple(f1.Denominator, f2.Denominator);
            f1.Numerator = (dencominator / f1.Denominator) * f1.Numerator;
            f2.Numerator = (dencominator / f2.Denominator) * f2.Numerator;
            result.Denominator = dencominator;
            result.Numerator = f1.Numerator + f2.Numerator;
            return result;
        }

        /// <summary>
        ///  计算两个分数的相减,并返回一个分数
        /// </summary>
        /// <param name="minuend">被减数</param>
        /// <param name="subtrahend">减数</param>
        /// <returns></returns>
        public Fraction_Math Sub(Fraction_Math minuend, Fraction_Math subtrahend)
        {
            Fraction_Math result = new Fraction_Math();
            double dencominator = CalculateLeaseCommonMultiple(minuend.Denominator, subtrahend.Denominator);
            minuend.Numerator = (dencominator / minuend.Denominator) * minuend.Numerator;
            subtrahend.Numerator = (dencominator / subtrahend.Denominator) * subtrahend.Numerator;
            result.Denominator = dencominator;
            result.Numerator = minuend.Numerator - subtrahend.Numerator;
            return result;
        }

        /// <summary>
        /// 计算两个分数的相乘,并返回一个分数
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <returns></returns>
        public Fraction_Math Multiple(Fraction_Math f1, Fraction_Math f2)
        {
            Fraction_Math result = new Fraction_Math();
            double dencominator = f1.Denominator * f2.Denominator;
            result.Denominator = dencominator;
            result.Numerator = f1.Numerator * f2.Numerator;
            return result;
        }

        /// <summary>
        /// 计算两个分数的相除,并返回一个分数
        /// </summary>
        /// <param name="dividend">被除数</param>
        /// <param name="divisor">除数</param>
        /// <returns></returns>
        public Fraction_Math Divided(Fraction_Math dividend, Fraction_Math divisor)
        {
            Fraction_Math result = new Fraction_Math();
            double dencominator = dividend.Denominator * divisor.Numerator;
            result.Denominator = dencominator;
            result.Numerator = dividend.Numerator * divisor.Denominator;
            return result;
        }

        #endregion

        #region private

        /// <summary>
        /// 计算最小公倍数
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        private double CalculateLeaseCommonMultiple(double d1, double d2)
        {
            double result = Math.Max(d1, d2);
            double i = 1D;
            do
            {
                if (result % d1 == 0D
                    && result % d2 == 0D)
                {
                    break;
                }
                else
                {
                    result *= (++i);
                }
            } while (true);

            return result;
        }
        #endregion
    }
}
