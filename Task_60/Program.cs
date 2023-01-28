// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();
        int rows = 2, columns = 2, tubes = 2, randomMinValue = 10, randomMaxValue = 99;
        int[,,] array = CreateRandomArray(rows, columns, tubes, randomMinValue, randomMaxValue);
        PrintArray(array);
    }

    static int[,,] CreateRandomArray(int rows, int columns, int tubes, int minValue, int maxValue)
    {
        DateTime dt = DateTime.Now;
        int tempNumber;
        int[,,] array = new int[rows, columns, tubes];
        Random random = new Random();
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < columns; j++)
                for (int k = 0; k < tubes; k++)
                {
                    do
                    {
                        tempNumber = random.Next(minValue, maxValue + 1);
                    } while (IsNumberInArray(array, tempNumber));
                    array[i, j, k] = tempNumber;
                }
        Console.WriteLine($"На создание массива ушло {(DateTime.Now - dt).TotalMilliseconds}");
        return array;
    }

    static void PrintArray(int[,,] array)
    {
        for (int i = 0; i < array.GetLength(2); i++)
        {
            Console.WriteLine($"{i+1}-й слой");
            for (int j = 0; j < array.GetLength(0); j++)
            {
                for (int k = 0; k < array.GetLength(1); k++)
                    Console.Write($"{array[j, k, i]}({j},{k},{i}) ");
                Console.WriteLine();
            }

        }
    }
    static bool IsNumberInArray(int[,,] array, int value)
    {
        foreach (int item in array)
            if (item == value) return true;
        return false;

    }
}