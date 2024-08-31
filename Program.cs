using System;
using System.Linq;

class MatrixDiagonalDifference
{
    static void Main(string[] args)
    {
        int matrixSize = int.Parse(Console.ReadLine());
        int[,] matrix = ReadMatrix(matrixSize);

        int primaryDiagonalSum = CalculateDiagonalSum(matrix, matrixSize, true);
        int secondaryDiagonalSum = CalculateDiagonalSum(matrix, matrixSize, false);

        int difference = CalculateAbsoluteDifference(primaryDiagonalSum, secondaryDiagonalSum);
        Console.WriteLine(difference);
    }

    static int[,] ReadMatrix(int size)
    {
        var matrix = new int[size, size];

        for (int i = 0; i < size; i++)
        {
            var row = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int j = 0; j < size; j++)
            {
                matrix[i, j] = row[j];
            }
        }

        return matrix;
    }

    static int CalculateDiagonalSum(int[,] matrix, int size, bool isPrimary)
    {
        int sum = 0;
        for (int i = 0; i < size; i++)
        {
            sum += isPrimary ? matrix[i, i] : matrix[i, size - 1 - i];
        }

        return sum;
    }

    static int CalculateAbsoluteDifference(int primarySum, int secondarySum)
    {
        return Math.Abs(primarySum - secondarySum);
    }
}
