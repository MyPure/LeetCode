using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class MinCut_132
    {
        public int MinCut(string s)
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

            int[] dp2 = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                if (i == 0)
                {
                    dp2[i] = 0;
                }
                else
                {
                    if (dp[0, i])
                    {
                        dp2[i] = 0;
                    }
                    else
                    {
                        int min = dp2[i - 1];
                        for (int j = 0; j < i - 1; j++)
                        {
                            if (dp[j + 1, i] && dp2[j] < min)
                            {
                                min = dp2[j];
                            }
                        }
                        dp2[i] = min + 1;
                    }
                }
            }
            return dp2[s.Length - 1];
        }
    }
}
