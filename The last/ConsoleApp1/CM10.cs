using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CM10
    {
        
        private static string GetAns(string a1, string b1, char c)
        {
            double s = 0,a,b;
            if (IsFractioon(a1)||IsFractioon(b1))
            {
                return Fraction_Math.Fraction(b1, a1, c);
            }
            a =Convert.ToDouble(a1);
            b = Convert.ToDouble(b1);          
            switch (c)
            {
                case '＋': s = b + a; break;
                case '－': s = b - a; break;
                case '×': s = b * a; break;
                case '÷': s = b / a; break;
                case '^': s = Math.Pow(b,a); break;
            }
            return s.ToString();
        }
        public static bool IsFractioon(string a)
        {
            for (int i=0;i<a.Length;i++)
            {
                if (a[i]=='/')
                {
                    return true;
                }
            }
            return false;
        } 
        private static int[] priority = new int[9999999];
        private static Stack<string> iStk = new Stack<string>();
        private static Stack<char> strStk = new Stack<char>();
        private static void Priority()
        {
            priority['＋'] = priority['－'] = 0;
            priority['×'] = priority['÷'] = 1;
            priority['^'] = 2;
        }
        public static string Shunting(string str)
        {
            Priority();
            Dismantling(str);
            while (strStk.Count != 0)
            {
                Value_ToDig(iStk, strStk);
            }
            if (CM30.IsDouble(iStk.Peek().ToString()) == false)
            {
                double IStk = Convert.ToDouble(iStk.Peek());
                return IStk.ToString();
            }
            return iStk.Peek();
        }

        private static void Dismantling(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i] >= '0' && str[i] <= '9') || (i == 0 && str[i] == '－') || (str[i] == '－' && str[i - 1] == '('))
                {
                    string s1 = "";
                    int f = 1, t = i;
                    if (str[i] == '-')
                    {
                        f = -1;
                        i++;
                    }
                    IsNumber(str, ref i, ref s1, ref t);
                    iStk.Push(s1);
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
                    if (str[t] == '＋' || str[t] == '－' || str[t] == '×' || str[t] == '÷' || t >= str.Length || str[t] == ')'||str[t]=='^')
                    { i = t - 1; break; }
                    s1 += str[t];
                    t++;
                    if (t >= str.Length) { i = t - 1; break; }
                }
                else
                    break;
            }
        }

        private static void Value_Sort(string str, Stack<string> iStk, Stack<char> strStk, int i)
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
                    string a = iStk.Pop(), b = iStk.Pop();
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

        private static void Value_ToDig(Stack<string> iStk, Stack<char> strStk)
        {
            string a = iStk.Pop();
            string b = iStk.Pop();
            char c = strStk.Pop();
            iStk.Push(GetAns(a, b, c));
        }
    }
}
