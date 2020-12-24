using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class Candy_135
    {
        public int Candy(int[] ratings)
        {
            int[] result = new int[ratings.Length];

            int p = 0;
            bool solved = true;
            bool mark = true;
            //从左到右遍历,左侧LR指评价，右侧LR指结果，钩叉指解决标记
            //L >= this <= R | ✔ this = 1 
            //L >= this > R | ✖ this = R + 1, mark = false
            //L < this <= R | ✔ this = L + 1
            //L < this > R | ✖ this = max(L,R) + 1, mark = true
            for (int i = 0; i < ratings.Length; i++)
            {
                //L > this
                bool Lgreater = i == 0 ? true : ratings[i - 1] >= ratings[i];
                //this > R
                bool Rgreater = i == ratings.Length - 1 ? false : ratings[i] > ratings[i + 1];

                if (Lgreater && !Rgreater)     //L > this < R
                {
                    result[i] = 1;
                    if (!solved)
                    {
                        Contract(result, p, i, mark);
                    }                    
                    solved = true;
                }
                else if (Lgreater && Rgreater)//L > this > R
                {
                    if (solved)
                    {
                        solved = false;
                        p = i;
                        mark = false;
                    }
                }
                else if (!Lgreater && !Rgreater) //L < this < R
                {
                    result[i] = result[i - 1] + 1;
                    if (!solved)
                    {
                        Contract(result, p, i, mark);
                    }
                    solved = true;
                }
                else                           //L < this > R 
                {
                    if (solved)
                    {
                        solved = false;
                        p = i;
                        mark = true;
                    }
                }
            }

            int sum = 0;
            for(int i = 0; i < result.Length; i++)
            {
                sum += result[i];
            }
            return sum;
        }

        private void Contract(int[] result, int left, int right, bool mark)
        {
            for (int i = right - 1; i >= left; i--)
            {
                if (i > left)
                {
                    result[i] = result[i + 1] + 1;
                }
                else
                {
                    if (mark)
                    {
                        result[i] = Math.Max(result[i - 1], result[i + 1]) + 1;
                    }
                    else
                    {
                        result[i] = result[i + 1] + 1;
                    }
                }
            }
        }
    }
}
