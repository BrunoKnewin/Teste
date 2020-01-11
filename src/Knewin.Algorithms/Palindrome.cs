using System;
using System.Collections.Generic;
using System.Text;

namespace Knewin.Algorithms
{
    public static class Palindrome
    {
        public static void Execute()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Informe a palavra que deseja verificar se é palindromo:");
            
            var word = Console.ReadLine().Trim();

            Console.WriteLine($"É palindromo: {IsPalidrome(word)}");
            Console.WriteLine("----------------------------------------------------------");
        }

        public static bool IsPalidrome(string word)
        {
            int start = 0;
            int end = word.Length - 1;

            while (start != end) {
                if (word[start] != word[end])
                    return false;

                start++;
                end--;
            }

            return true;
        }
    }
}
