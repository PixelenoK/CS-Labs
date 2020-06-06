using System;

namespace ConsoleApp5
{
    class Program
    {
        //перемешивание с помощью алгоритма Фишера-Йетса
        static void Shuffle(char[] arr)
        {
            Random rand = new Random();

            for (int i = arr.Length - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);

                char tmp = arr[j];
                arr[j] = arr[i];
                arr[i] = tmp;
            }
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i]);
            Console.WriteLine();

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите вашу строку");
            string hello = Console.ReadLine();
            char[] strM1 = hello.ToCharArray();            
            for (int i = 0; i < strM1.Length; i++)
                Console.Write(strM1[i]);
            Console.WriteLine();
            Shuffle(strM1);
        }
    }
}
