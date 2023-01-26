// Задача 55: Задайте двумерный массив. Напишите программу, которая заменяет строки на столбцы. 
// В случае, если это невозможно, программа должна вывести сообщение для пользователя.

internal partial class Program
{
    private static void Main(string[] args)
    {
        int rows = 4, columns = 4, randomMinValue = 0, randomMaxValue = 100;
        int[,] array = CreateRandomArray(rows, columns, randomMinValue, randomMaxValue);
        PrintArray(array);
        Console.WriteLine();
        array = ChangeRowsOnColumns(array);
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

    static int[,] ChangeRowsOnColumns(int[,] array)
    {
        int rows = array.GetLength(0), columns = array.GetLength(1);
        if (rows != columns){
             Console.WriteLine("Замена не возможна");
             return array;
        }
        else
        {
            int[,] newArray = new int[rows, columns];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    newArray[i, j] = array[j, i];
            return newArray;
        }
    }

}