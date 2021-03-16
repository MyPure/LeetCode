using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class Calculate_224
    {
        private Stack<char> symbol = new Stack<char>();
        private Stack<int> number = new Stack<int>();
        private List<char> numberList = new List<char>();
        public int Calculate(string s)
        {
            if(!string.IsNullOrEmpty(s) && s[0] == '-')
            {
                PushNumber(0);
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    continue;
                }

                if (IsNumber(s[i]))
                {
                    numberList.Add(s[i]);
                    if (i + 1 >= s.Length || !IsNumber(s[i + 1]))
                    {
                        string n = new string(numberList.ToArray());
                        numberList.Clear();
                        PushNumber(int.Parse(n));
                    }
                }
                else
                {
                    PushSymbol(s[i]);
                }
            }
            return number.Pop();
        }

        private bool IsNumber(char c)
        {
            return c >= '0' && c <= '9';
        }

        private void PushNumber(int n)
        {
            number.Push(n);
            if (symbol.Count != 0)
            {
                if (symbol.Peek() == '+')
                {
                    int a = number.Pop();
                    int b = number.Pop();
                    symbol.Pop();
                    PushNumber(a + b);
                }
                else if (symbol.Peek() == '-')
                {
                    int a = number.Pop();
                    int b = number.Pop();
                    symbol.Pop();
                    PushNumber(b - a);
                }
                else if (symbol.Peek() == '(')
                {
                   
                }
                else
                {
                    symbol.Pop();
                    symbol.Pop();
                    PushNumber(number.Pop());
                }
            }
        }

        private void PushSymbol(char c)
        {
            symbol.Push(c);
            if(c == ')')
            {
                PushNumber(number.Pop());
            }
        }
    }
}
