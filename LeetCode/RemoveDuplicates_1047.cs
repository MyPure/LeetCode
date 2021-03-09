using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class RemoveDuplicates_1047
    {
        public string RemoveDuplicates(string S)
        {
            Stack<char> stack = new Stack<char>();
            if (S.Length == 0)
            {
                return S;
            }
            stack.Push(S[0]);
            for (int i = 1; i < S.Length; i++)
            {
                char result;
                if (stack.TryPeek(out result) && S[i] == result)
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(S[i]);
                }
            }
            char[] r = stack.ToArray();
            Array.Reverse(r);
            return new string(r);
        }
    }
}
