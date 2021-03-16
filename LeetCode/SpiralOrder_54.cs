using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class SpiralOrder_54
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            int pass = 0;
            int length = matrix.Length * matrix[0].Length;
            int direction = 0;//0 1 2 3 = → ↓ ← ↑
            bool[,] state = new bool[matrix.Length, matrix[0].Length];
            int x = 0, y = 0;//x = 横坐标 = 列，y = 纵坐标 = 行
            List<int> result = new List<int>();
            int blockCount = 0;

            while (pass <= length - 1 && blockCount <= 4)
            {
                if (IsBlock(state, x, y, direction))
                {
                    direction = direction == 3 ? 0 : direction + 1;
                    blockCount++;
                }
                else
                {
                    state[y, x] = true;
                    result.Add(matrix[y][x]);
                    pass++;
                    blockCount = 0;
                    switch (direction)
                    {
                        case 0:
                            x++; break;
                        case 1:
                            y++; break;
                        case 2:
                            x--; break;
                        case 3:
                            y--; break;
                    }
                }
            }
            result.Add(matrix[y][x]);
            return result;
        }

        private bool IsBlock(bool[,] state, int x, int y, int direction)
        {
            switch (direction)
            {
                case 0:
                    return x + 1 >= state.GetLength(1) || state[y, x + 1];
                case 1:
                    return y + 1 >= state.GetLength(0) || state[y + 1, x];
                case 2:
                    return x - 1 <= -1 || state[y, x - 1];
                case 3:
                    return y - 1 <= -1 || state[y - 1, x];
            }
            return false;
        }
    }
}
