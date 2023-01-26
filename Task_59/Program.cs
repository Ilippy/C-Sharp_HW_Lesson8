// Задача 59: Задайте двумерный массив из целых чисел. Напишите программу, 
// которая удалит строку и столбец, на пересечении которых расположен наименьший элемент массива.

internal partial class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();
        int rows = 5, columns = 6, randomMinValue = -10, randomMaxValue = 10;
        int[,] array = CreateRandomArray(rows, columns, randomMinValue, randomMaxValue);
        PrintArray(array);
        int[] indexOfMinValue = FindIndexMinValue(array);
        System.Console.WriteLine($"Min index Value = [{String.Join(", ", indexOfMinValue)}]");
        System.Console.WriteLine();
        int[,] newArray = CoppyChangedArray(array, indexOfMinValue);
        PrintArray(newArray);

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

    static int[] FindIndexMinValue(int[,] array)
    {
        int[] minIndexValue = new int[2];
        minIndexValue[0] = 0;
        minIndexValue[1] = 0;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i, j] < array[minIndexValue[0], minIndexValue[1]])
                {
                    minIndexValue[0] = i;
                    minIndexValue[1] = j;
                }
            }
        }
        return minIndexValue;
    }

    static int[,] CoppyChangedArray(int[,] array, int[] indexOfMinValue)
    {
        int rows = array.GetLength(0), columns = array.GetLength(1);
        int[,] newArray = new int[rows - 1, columns - 1];
        int x = 0, y = 0;
        for (int i = 0; i < rows; i++)
        {
            if (i == indexOfMinValue[0])
            {
                x = 1;
                continue;
            }
            for (int j = 0; j < columns; j++)
            {
                if (j == indexOfMinValue[1])
                {
                    y = 1;
                    continue;
                }
                if(i == 0) newArray[i, j - y] = array[i, j];
                else if(j == 0) newArray[i -x, j] = array[i, j];
                else newArray[i - x, j - y] = array[i, j];
            }
        }
        return newArray;
    }

    static int[,] GetResultArray(int[,] inArray, int[] indexes)
    {
        int[,] result = new int[inArray.GetLength(0) - 1, inArray.GetLength(1) - 1];
        int row = 0;
        int column = 0;
        for (int i = 0; i < inArray.GetLength(0); i++)
        {
            if (i == indexes[0]) continue;
            for (int j = 0; j < inArray.GetLength(1); j++)
            {
                if (j == indexes[1]) continue;
                result[row, column] = inArray[i, j];
                column++;
            }
            column = 0;
            row++;
        }
        return result;
    }
}