using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class GenerateMatrix_59
    {
        public int[][] GenerateMatrix(int n)
        {
            int[][] matrix = new int[n][];
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[n];
            }

            int length = n * n;
            int pass = 1;
            int x = 0, y = 0;
            int blockCount = 0;
            int direction = 0;//0 1 2 3 = → ↓ ← ↑
            bool[,] state = new bool[matrix.Length, matrix[0].Length];

            while (pass <= length && blockCount <= 4)
            {
                if (IsBlock(state, x, y, direction))
                {
                    direction = direction == 3 ? 0 : direction + 1;
                    blockCount++;
                }
                else
                {
                    state[y, x] = true;
                    matrix[y][x] = pass;
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
            matrix[y][x] = pass;
            return matrix;
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
