using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CM10
    {
        private static double ToDig(string str)
        {
            double n = 0, mag = 0.1;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '.') break;
                mag *= 10;
            }
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '.') continue;
                n += mag * (str[i] - '0');
                mag /= 10;
            }
            return n;
        }
        private static double GetAns(double a, double b, char c)
        {
            double s = 0;
            switch (c)
            {
                case '+': s = b + a; break;
                case '-': s = b - a; break;
                case '*': s = b * a; break;
                case '/': s = b / a; break;
            }
            return s;
        }
        private static int[] priority = new int[55];
        private static Stack<double> iStk = new Stack<double>();
        private static Stack<char> strStk = new Stack<char>();
        private static void Priority()
        {
            priority['+'] = priority['-'] = 0;
            priority['*'] = priority['/'] = 1;
        }
        public static double Shunting(string str)
        {
            Priority();
            Dismantling(str);
            while (strStk.Count != 0)
            {
                Value_ToDig(iStk, strStk);
            }
            if (CM30.IsDouble(iStk.Peek().ToString()) == false)
            {
                double IStk = Convert.ToDouble(iStk.Peek().ToString("#0.00"));
                return IStk;
            }
            return iStk.Peek();
        }

        private static void Dismantling(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i] >= '0' && str[i] <= '9') || (i == 0 && str[i] == '-') || (str[i] == '-' && str[i - 1] == '('))
                {
                    string s1 = "";
                    int f = 1, t = i;
                    if (str[i] == '-')
                    {
                        f = -1;
                        i++;
                    }
                    IsNumber(str, ref i, ref s1, ref t);
                    iStk.Push(f * ToDig(s1));
                }
                else
                    Value_Sort(str, iStk, strStk, i);
            }
        }

        private static void IsNumber(string str, ref int i, ref string s1, ref int t)
        {
            while ((str[i] >= '0' && str[i] <= '9') || str[i] == '.')
            {
                if (t < str.Length)
                {
                    if (str[t] == '+' || str[t] == '-' || str[t] == '*' || str[t] == '/' || t >= str.Length || str[t] == ')')
                    { i = t - 1; break; }
                    s1 += str[t];
                    t++;
                    if (t >= str.Length) { i = t - 1; break; }
                }
                else
                    break;
            }
        }

        private static void Value_Sort(string str, Stack<double> iStk, Stack<char> strStk, int i)
        {
            if (strStk.Count == 0 || str[i] == '(' || strStk.Peek() == '(' || (str[i] != ')' && priority[str[i]] > priority[strStk.Peek()]))
            {
                if (str[i] == ')' && strStk.Peek() == '(')
                    strStk.Pop();
                else
                    strStk.Push(str[i]);
            }
            else if (str[i] == ')')
            {
                char c = strStk.Peek();
                while (c != '(')
                {
                    double a = iStk.Pop(), b = iStk.Pop();
                    strStk.Pop();
                    iStk.Push(GetAns(a, b, c));
                    c = strStk.Peek();
                }
                strStk.Pop();
            }
            else
            {
                Value_ToDig(iStk, strStk);
                strStk.Push(str[i]);
            }
        }

        private static void Value_ToDig(Stack<double> iStk, Stack<char> strStk)
        {
            double a = iStk.Pop();
            double b = iStk.Pop();
            char c = strStk.Pop();
            iStk.Push(GetAns(a, b, c));
        }
    }
}
