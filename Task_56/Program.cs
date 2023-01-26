// Задача 56: Задайте прямоугольный двумерный массив. 
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.

internal partial class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();
        int rows = 5, columns = 5, randomMinValue = 0, randomMaxValue = 20;
        int[,] array = CreateRandomArray(rows, columns, randomMinValue, randomMaxValue);
        PrintArray(array);
        int[] minValueRow = GetMinValueRow(array);
        Console.WriteLine($"Строка с наименьшей суммой элементов => {String.Join(" ",minValueRow)}");
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

    static int[] GetMinValueRow(int[,] array)
    {
        int minIndexOfRow = 0, minSumValuesOfRow = int.MaxValue, tempSumValues;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            // tempSumValues = 0;
            // for (int j = 0; j < array.GetLength(1); j++)
            //     tempSumValues += array[i, j];

            tempSumValues = Enumerable.Range(0, array.GetLength(1)).Sum(y => array[i, y]);
            // Console.WriteLine($"{i} = {tempSumValues}");
            if (tempSumValues < minSumValuesOfRow)
            {
                minSumValuesOfRow = tempSumValues;
                minIndexOfRow = i;
            }
        }
        // Console.WriteLine($"{minIndexOfRow} => {minSumValuesOfRow}");
        return Enumerable.Range(0, array.GetLength(1)).Select(x => array[minIndexOfRow, x]).ToArray();
    }
}