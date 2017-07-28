using System;
using System.Threading;

namespace Join
{
    class Program
    {
        //Метод, который будет выполняться во вторичном потоке
        static void Method()
        {
            Console.WriteLine("ID вторичного потока - {0}",Thread.CurrentThread.ManagedThreadId);
            Console.ForegroundColor = ConsoleColor.Yellow;
            string str = @"Наша Таня громко плачет, 
по головке скачет мячик.
Это выдумка отца
мячик сделан из свинца!";
            char[] arr = str.ToCharArray();

            for (int k = 0; k < arr.Length; k++)
            {
                Thread.Sleep(20);
                Console.Write(arr[k]);
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Работа вторичного потока завершилась");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("ID первичного потока - {0}",Thread.CurrentThread.ManagedThreadId);

            //Запускаю метод в отдельном потоке
            Thread thread = new Thread(Method);
            thread.Start();
            thread.Join();

            //и еще разок(использую var. проверяю что за IsBackground)
            var thread1 = new Thread(Method);
            thread1.Start();
            //thread1.IsBackground = true;
            thread1.Join();

            //работа первичного потока
            string str1 = "Скоро дело делается, да не скоро дело делается";
            char[] arr2 = str1.ToCharArray();
            for (int y = 0; y < arr2.Length; y++)
            {
                Thread.Sleep(50);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(arr2[y]);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("Работа первичного потока завершилась!!!");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.ReadKey();
        }
    }
}
