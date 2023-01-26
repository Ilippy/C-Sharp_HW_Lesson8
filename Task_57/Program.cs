// Задача 57: Составить частотный словарь элементов двумерного массива. 
// Частотный словарь содержит информацию о том, сколько раз встречается элемент входных данных.

internal partial class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();
        int rows = 4, columns = 4, randomMinValue = 0, randomMaxValue = 10;
        int[,] array = CreateRandomArray(rows, columns, randomMinValue, randomMaxValue);
        int[] newArray = Create1DArray(array);
        PrintArray(array);
        Console.WriteLine();
        foreach (int item in newArray)
        {
            Console.WriteLine($"{item} => {FindValueInArray(array, item)}");
        }
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

    static int FindValueInArray(int[,] array, int value)
    {
        int count = 0;
        foreach (int item in array)
            if (item == value) count++;
        return count;
    }

    static int[] Create1DArray(int[,] array)
    {
        List<int> list = new List<int>();
        foreach (var item in array)
            if (!list.Contains(item)) list.Add(item);
        list.Sort();
        return list.ToArray();
    }

    

}