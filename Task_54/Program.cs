// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

internal partial class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();
        int rows = 5, columns = 5, randomMinValue = 0, randomMaxValue = 20;
        int[,] array = CreateRandomArray(rows, columns, randomMinValue, randomMaxValue);
        PrintArray(array);
        Console.WriteLine();
        SortArrayByRow(array);
        Console.WriteLine();
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


    static void SortArrayByRow(int[,] array)
    {
        DateTime dt = DateTime.Now;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            SortValuesInRow(array, i);
            // SortArray(array, i, array.GetLength(1) -1);
        }
        Console.WriteLine($"Затраченное время на данную сортировку массива = {(DateTime.Now - dt).TotalMilliseconds}");
    }

    static void SortValuesInRow(int[,] array, int row){
        for (int j = 0; j < array.GetLength(1); j++)
            {
                for (int k = 0; k < array.GetLength(1) - j - 1; k++)  // 0 1 2 
                {
                    // System.Console.WriteLine($"{array[row, k]} > {array[row, k + 1]} {array[row, k] > array[row, k + 1]} , i = {row}, j = {j}, k = {k}");
                    if (array[row, k] < array[row, k + 1])
                    {
                        int temp = array[row, k];
                        array[row, k] = array[row, k + 1];
                        array[row, k + 1] = temp;
                    }
                }
            }
    }

    static void SortArray(int[,] array,int row, int rightIndex, int leftIndex = 0)
    {
        int i = leftIndex;
        int j = rightIndex;
        int pivot = array[row, leftIndex];
        while (i <= j)
        {
            while (array[row, i] < pivot)
            {
                i++;
            }

            while (array[row, j] > pivot)
            {
                j--;
            }
            if (i <= j)
            {
                int temp = array[row, i];
                array[row, i] = array[row, j];
                array[row, j] = temp;
                i++;
                j--;
            }
        }

        if (leftIndex < j)
            SortArray(array, row, j, leftIndex);
        if (i < rightIndex)
            SortArray(array, row, rightIndex, i);

    }
}

