using System;

namespace Knewin.Palindrome.ConsoleApp
{
    public class Palindrome
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite uma sequencia de caracteres ('sair' para encerrar!)");
            string str = Console.ReadLine();
            while (!str.Equals("sair"))
            {
                bool palindrome = IsPalindrome(str);
                if (palindrome)
                    Console.WriteLine("O valor inserido é um palindromo, Retorno {0}", palindrome);
                else
                    Console.WriteLine("O valor inserido não é um palindromo, Retorno {0}", palindrome);
                Console.WriteLine("\n\n");
                Console.WriteLine("Digite uma sequencia de caracteres ('sair' para encerrar!)");
                str = Console.ReadLine();
            }
            
        }

        private static bool IsPalindrome(string str)
        {
            bool palindrome;
            str = str.Replace(" ", "").ToUpper();
            int strSize = str.Length;
            if (IsEven(strSize))
            {
                string firstHalfstring = str.Substring(0, strSize / 2);
                string finalHalfstring = str.Substring((strSize / 2), (strSize / 2));
                palindrome = CompareTwoHalves(firstHalfstring, finalHalfstring, strSize);
            }
            else
            {
                int sizeHalf = (str.Length - 1) / 2;
                string firstHalfstring = str.Substring(0, sizeHalf);
                string finalHalfstring = str.Substring(sizeHalf + 1, sizeHalf);
                palindrome = CompareTwoHalves(firstHalfstring, finalHalfstring, strSize);
            }

            return palindrome;
        }

        private static bool CompareTwoHalves(string firstHalfstring, string finalHalfstring, int strSize)
        {
            for (int i = 0; i < firstHalfstring.Length; i++)
            {
                int currentValueFirstHalf = firstHalfstring[i];
                int currentValueFinalHalf = finalHalfstring[finalHalfstring.Length - i - 1];
                if (currentValueFirstHalf != currentValueFinalHalf)
                    return false;
            }
            return true;
        }

        private static bool IsEven(int strSize)
        {
            return strSize % 2 == 0;
        }
    }
}
