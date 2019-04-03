using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Fraction_Math
    {

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

        /// <summary>l
        /// 相加
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public Fraction_Math Add(double d1, double d2)
        {
            return Add(new Fraction_Math(d1), new Fraction_Math(d2));
        }

        /// <summary>
        ///  计算两个数的相减,并返回一个分数
        /// </summary>
        /// <param name="minuend">被减数</param>
        /// <param name="subtrahend">减数</param>
        /// <returns></returns>
        public Fraction_Math Sub(double minuend, double subtrahend)
        {
            return Sub(new Fraction_Math(minuend), new Fraction_Math(subtrahend));
        }


        /// <summary>
        /// 计算两个数的相乘,并返回一个分数
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public Fraction_Math Multiple(double d1, double d2)
        {
            return Multiple(new Fraction_Math(d1), new Fraction_Math(d2));
        }

        /// <summary>
        /// 计算两个数的相除,并返回一个分数
        /// </summary>
        /// <param name="dividend">被除数</param>
        /// <param name="divisor">除数</param>
        /// <returns></returns>
        public Fraction_Math Divided(double dividend, double divisor)
        {
            return Divided(new Fraction_Math(dividend), new Fraction_Math(divisor));
        }


        public string GetFractionValueString()
        {
            return string.Format("{0}/{1}", Numerator, Denominator);
        }

        public double GetFractionValue()
        {
            return Numerator / Denominator;
        }


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
