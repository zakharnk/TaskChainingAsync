using System;
using System.Threading.Tasks;
using TaskChainingAsync.Core;

namespace TaskChainingAsync
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Random random = new Random();

            ArrayManager arrayManager = new ArrayManager();

            var array = await arrayManager.CreateRandomArrayAsync(0, 100);
            Console.WriteLine("Generated Array: ");
            PrintArray(array);

            var number = random.Next(0, 100);
            Console.WriteLine($"Random Number {number}");
            array = await arrayManager.MultiplyArrayByNumberAsync(array, number);
            Console.WriteLine("Multiped Array: ");
            PrintArray(array);

            array = await arrayManager.SortArrayByAscendingAsync(array);
            Console.WriteLine("Sorted Array: ");
            PrintArray(array);

            var average = await arrayManager.AverageValueAsync(array);
            Console.WriteLine($"Average:{average} ");
        }

        private static void PrintArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}
