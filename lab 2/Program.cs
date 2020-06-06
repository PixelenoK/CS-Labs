using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace split_join
{
    class Program
    {
        static void Main(string[] args)
        {
            string d = Console.ReadLine();
            string[] words = d.Split(' ');//расщепляет на слова
            Console.WriteLine("reversed:");
            Array.Reverse(words);
            for (int i = 0; i < words.Length; i++)
            {
                Console.Write(words[i] + " ");
            }
            Console.ReadKey();
        }
    }
}

