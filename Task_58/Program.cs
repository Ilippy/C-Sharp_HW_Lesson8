// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

internal partial class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();
        int rows = 3, columns = 2, randomMinValue = 0, randomMaxValue = 10;
        int[,] arrayA = CreateRandomArray(3, 2, randomMinValue, randomMaxValue);
        int[,] arrayB = CreateRandomArray(2, 3, randomMinValue, randomMaxValue);
        int[,] arrayC = MultipyMatrix(arrayA, arrayB);
        System.Console.WriteLine("Матрица А");
        PrintArray(arrayA);
        System.Console.WriteLine();
        System.Console.WriteLine("Матрица Б");
        PrintArray(arrayB);
        System.Console.WriteLine();
        System.Console.WriteLine("Матрица С");
        PrintArray(arrayC);
        
    }

    static int[,] CreateRandomArray(int rows, int columns, int minValue, int maxValue)
    {
        int[,] array = new int[rows, columns];
        Random random = new Random();
        for (int i = 0; i < array.GetLength(0); i++)
            for (int j = 0; j < array.GetLength(1); j++)
                array[i, j] = random.Next(minValue, maxValue + 1);
        return array;
    }

    static void PrintArray(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
                Console.Write($"{array[i, j]}\t");
            Console.WriteLine();
        }
    }

    static int[,] MultipyMatrix(int[,] matrixA, int[,] matrixB)
        {
            if (matrixA.GetLength(1) != matrixB.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
            int rows = matrixA.GetLength(0), columns = matrixB.GetLength(1);
            System.Console.WriteLine($"rows = {rows}, columns = {columns}");
            int[,] matrixC = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    for (int k = 0; k < matrixA.GetLength(1); k++)
                    {
                        // Console.WriteLine($"{matrixC[i,j]} += {matrixA[i,k]} * {matrixB[k,j]}, i = {i}, j = {j}, k = {k}, a[i,k] * b[k,j]");
                        matrixC[i,j] += matrixA[i,k] * matrixB[k,j];
                    }
                }
            }
            return matrixC;
        }
}