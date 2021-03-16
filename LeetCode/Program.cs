using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] Args)
        {
            SpiralOrder_54 s = new SpiralOrder_54();
            int[][] m = new int[][]
            {
                new int[]{1,2,3},
                new int[]{4,5,6},
                new int[]{7,8,9}
            };
            foreach (int i in s.SpiralOrder(m))
            {
                Console.Write(i + " ");
            }
        }
    }
}
