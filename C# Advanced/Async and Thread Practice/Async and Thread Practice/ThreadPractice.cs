using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async_and_Thread_Practice
{
    public class ThreadPractice
    {
        public static void Example1()
        {
            const int V = 6;
            Thread thread = new Thread(Numbers);
            thread.Start();

            for (int i = 0; i < V; i++)
            {
                Console.WriteLine($"Example 1 method: {i}");
            }
        }
        public static void Example2()
        {
            const int V = 7;
            Thread thread = new Thread(Numbers1);
            thread.Start(7);

            for (int i = 0; i < V; i++)
            {
                Console.WriteLine($"Example 2 method: {i}");
            }
        }


        public static void Numbers()
        {
            const int N = 5;
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"Numbers method: {i}");
            }
        }
        public static void Numbers1(object? obj)
        {
            if (obj is int n)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"Numbers1 method: {i}");
                }
            }
        }
    }
}
