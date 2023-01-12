using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            var one = new int[10];
            var two = new int[10];
            var result = new int[10];

            var arrayOne = Task.Run(() =>
            {
                for (int i = 0; i < one.Length; i++)
                {
                    one[i] = random.Next(0, 100);
                }
            });

            var arrayTwo = Task.Run(() =>
            {
                for (int i = 0; i < two.Length; i++)
                {
                    two[i] = random.Next(0, 100);
                }
            });

            var sum = Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    result[i] = one[i] + two[i];
                    Thread.Sleep(50);
                }
            });
            Task.WaitAll(arrayOne, arrayTwo, sum);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{one[i]} + {two[i]} = {result[i]}");
                Thread.Sleep(500);
            }
        }
    }
}