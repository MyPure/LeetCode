using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class IsIsomorphic_205
    {
        public bool IsIsomorphic(string s, string t)
        {
            Dictionary<char, char> pairs = new Dictionary<char, char>();
            for(int i = 0; i < s.Length; i++)
            {
                if (!pairs.ContainsKey(s[i]))
                {
                    if (pairs.ContainsValue(t[i]))
                    {
                        return false;
                    }
                    else
                    {
                        pairs.Add(s[i], t[i]);
                    }
                }
                else
                {
                    if(t[i] != pairs[s[i]])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
