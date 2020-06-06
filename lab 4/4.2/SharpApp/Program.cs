using System;
using System.Runtime.InteropServices;

namespace SharpApp
{
    class Program
    {
        [DllImport("D:\\Prog\\lab_2_sem\\ИСП  (C#)\\lab4_2\\MyLib\\Debug\\MyLib.dll", CallingConvention = CallingConvention.Cdecl)]

        public static extern int Get_PositiveNeg(int number);

        [DllImport("D:\\Prog\\lab_2_sem\\ИСП  (C#)\\lab4_2\\MyLib\\Debug\\MyLib.dll")]

        public static extern int Get_length(int number);

        [DllImport("D:\\Prog\\lab_2_sem\\ИСП  (C#)\\lab4_2\\MyLib\\Debug\\MyLib.dll")]

        public static extern int Odd_or_even(int number);


        public static void Show_info_of_number(int number)
        {
            if (Get_PositiveNeg(number) == 1)
                Console.Write($"Number {number}: positive, ");
            else
                Console.Write($"{number}: negative, ");

            Console.Write($"{Get_length(number)} digits, ");

            if (Odd_or_even(number) == 1)
                Console.WriteLine($"even ");
            else
                Console.WriteLine($"odd ");
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number you want to research\n");
            int number = Int32.Parse(Console.ReadLine());
            Show_info_of_number(number);
        }
    }
}
