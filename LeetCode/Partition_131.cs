using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class Partition_131
    {
        private IList<string> ans = new List<string>();
        private IList<IList<string>> result = new List<IList<string>>();
        public IList<IList<string>> Partition(string s)
        { 
            bool[,] dp = new bool[s.Length, s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                dp[i, i] = true;
            }
            for (int j = 1; j < s.Length; j++)
            {
                for (int i = 0; i < j; i++)
                {
                    if (i == j - 1)
                    {
                        dp[i, j] = s[i] == s[j];
                    }
                    else if (i > j - 1)
                    {
                        continue;
                    }
                    else
                    {
                        dp[i, j] = dp[i + 1, j - 1] && s[i] == s[j];
                    }
                }
            }

            Search(dp, s, 0);
            return result;
        }

        private void Search(bool[,] dp, string s, int pointerA)
        {          
            if (pointerA == s.Length)
            {
                result.Add(new List<string>(ans));
            }
            else
            {
                int pointerB = pointerA;
                while(pointerB < s.Length)
                {
                    if (dp[pointerA, pointerB])
                    {
                        ans.Add(s.Substring(pointerA, pointerB - pointerA + 1));
                        Search(dp, s, pointerB + 1);
                        ans.RemoveAt(ans.Count - 1);
                        pointerB++;
                    }
                    else
                    {
                        pointerB++;
                    }
                }               
            }
        }
    }
}
