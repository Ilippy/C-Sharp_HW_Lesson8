// Задача 53: Задайте двумерный массив. Напишите программу, которая поменяет местами первую и последнюю строку массива.

internal class Program
{
    private static void Main(string[] args)
    {
        int rows = 4, columns = 4, randomMinValue = 0, randomMaxValue = 100;
        int[,] array = CreateRandomArray(rows, columns, randomMinValue, randomMaxValue);
        PrintArray(array);
        System.Console.WriteLine();
        ChangeFirstAndLastLine(array);
        PrintArray(array);

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
                Console.Write($"{array[i, j]} ");
            Console.WriteLine();
        }
    }

    static void ChangeFirstAndLastLine(int[,] array)
    {
        int tempInt;
        int lastRowIndex = array.GetLength(0)-1;
        for (int i = 0; i < array.GetLength(1); i++)
        {
            tempInt = array[0, i];
            array[0, i] = array[lastRowIndex, i];
            array[lastRowIndex, i] = tempInt;
        }
    }
}