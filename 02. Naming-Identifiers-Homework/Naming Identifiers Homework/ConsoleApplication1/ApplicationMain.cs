using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class ApplicationMain
    {
        static void Main(string[] args)
        {
            var matrixFirst = new double[,] { { 1, 3 }, { 5, 7 } };
            var matrixSecond = new double[,] { { 4, 2 }, { 1, 5 } };
            var outputMatrix = matrixBuilder(matrixFirst, matrixSecond);

            for (int i = 0; i < outputMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < outputMatrix.GetLength(1); j++)
                {
                    Console.Write(outputMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }

        }

        static double[,] matrixBuilder(double[,] firstMatrix, double[,] secondMatrix)
        {
            if (firstMatrix.GetLength(1) != secondMatrix.GetLength(0))
            {
                throw new Exception("Error!");
            }

            var length = firstMatrix.GetLength(1);
            var result = new double[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];
            for (int a = 0; a < result.GetLength(0); a++)
                for (int b = 0; b < result.GetLength(1); b++)
                    for (int c = 0; c < length; c++)
                        result[a, b] += firstMatrix[a, c] * secondMatrix[c, b];
            return result;
        }
    }
}