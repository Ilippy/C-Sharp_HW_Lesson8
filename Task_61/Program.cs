// Задача 61: Вывести первые N строк треугольника Паскаля. 
// Сделать вывод в виде равнобедренного треугольника

internal partial class Program
{
    private static void Main(string[] args)
    {
        int[][] pascalTriangle = PasTri(5);
        PrintArray(pascalTriangle);
    }

    static int[][] PasTri(int n)
    {
        int[][] result = new int[n][];
        result[0] = new int[] { 1 };
        for (int i = 1; i < n; i++)
        {
            result[i] = new int[i + 1];
            int left = 0;
            for (int j = 0; j < i; j++)
            {
                result[i][j] = result[i - 1][j] + left;
                left = result[i - 1][j];
            }
            result[i][i] = left;
        }
        return result;
    }

    static void PrintArray(int[][] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array[i].Length; j++)
                Console.Write($"{array[i][j]}\t");
            Console.WriteLine();
        }
    }
}