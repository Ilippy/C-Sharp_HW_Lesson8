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
        int rows = 2, columns = 2, tubes = 2, randomMinValue = 0, randomMaxValue = 100;
        int[,,] array = CreateRandomArray(rows, columns, tubes, randomMinValue, randomMaxValue);
        PrintArray(array);
    }

    static int[,,] CreateRandomArray(int rows, int columns, int tubes, int minValue, int maxValue)
    {
        int[,,] array = new int[rows, columns, tubes];
        Random random = new Random();
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < columns; j++)
                for (int k = 0; k < tubes; k++)
                    array[i, j, k] = random.Next(minValue, maxValue + 1);

        return array;
    }

    static void PrintArray(int[,,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                for (int k = 0; k < array.GetLength(2); k++)
                    Console.Write($"{array[i, j, k]}({i},{j},{k}) ");
                Console.WriteLine();
            }
            
        }
    }
}