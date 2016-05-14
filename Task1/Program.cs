using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static bool IsPrime(string s)
        {
            //конвертация от типа строки в тип целое число
            int x = int.Parse(s);
            int cnt = 0;
            //подсчет кол-ва делителей отличных от 1 и самого числа
            for (int j = 2; j <= Math.Sqrt(x); ++j)
            {
                if (x % j == 0)
                {
                    cnt++;
                }
            }

            return cnt == 0 && x != 1;
        }

        static void Main(string[] args)
        {
            // args = 5 6 8 13 17 92 45 7 23 26

            Console.WriteLine("These are prime number not divisible by 5: ");
            for (int i = 0; i < args.Length; i++)
            {
                if (IsPrime(args[i]) && int.Parse(args[i]) % 5 != 0)
                {
                    Console.WriteLine(args[i]);
                }
            }
        }
    }
}
