using System;
using System.Linq;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите вашу строку ");
            string test = Console.ReadLine();
            //удаляем английские буквы из строки
            string result = new string(test.Where(c => !((c > 0x40 && c < 0x5B) || (c > 0x60 && c < 0x7B))).ToArray());
            //удаляем лишние символы(пробел,+,- и т.д)
            string result1 = new string(result.Where(e => char.IsLetter(e)).ToArray());
            Console.WriteLine(result);
            for (int i = 0; i < result.Length; i++)
            {
                if (result1[i] == result1.ToUpper()[i])
                {
                    Console.WriteLine("заглавная буква: {0} ", result1[i]);
                }
            }
                
        }
    }
}
