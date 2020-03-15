using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace palindromos
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length <= 0)
            {
                Console.WriteLine("USO DO PROGRAMA: palindromos <sequencia para testar>!");
                return;
            }
            string input = args[0];
            
            Console.WriteLine("CONSIDERANDO espaços, especiais e diacríticos: ");
            string result = IsPalindrome(input) 
                ? $"'{input}' É palíndromo!"
                : $"'{input}' NÃO É palíndromo.";
            Console.WriteLine(result);

            Console.WriteLine("IGNORANDO espaços, especiais e diacríticos: ");
            result = IsPalindrome(input, false) 
                ? $"'{input}' É palíndromo!"
                : $"'{input}' NÃO É palíndromo.";
            Console.WriteLine(result);
        }

        // Valida se a string de entrada é palíndroma
        private static bool IsPalindrome(string input, bool isSimpleWord = true)
        {
            bool isPalindrome = true;
            // parâmetro isSimpleWord indica se validará apenas 
            // uma palavra ex.: "arara" ou se é frase e portanto
            // deve usar regras de espaços e diacríticos
            if(!isSimpleWord)
            {
                // remove os espaços e especiais
                // e os diacríticos
                input = Regex.Replace(input, @"\W+", string.Empty);
                input = RemoveDiacritics(input);
            }
            // garantindo o ignoreCase
            input = input.ToUpper();
            int halfLengthIndex = input.Length / 2 - 1;
            int lastIndex = input.Length - 1;
            // vai até a metade da string
            for(int index=0; index< halfLengthIndex; index++)
            {
                // compara o caractrer no primeiro indice com o ultimo
                // o segundo com o penultimo, etc
                // se encontrar alguma coisa diferente, já pode retornar falso
                if(input[index] != input[lastIndex-index])
                {
                    isPalindrome = false;
                    break;
                }
                    
            }
            return isPalindrome;
        }

        // método para "limpar" a string de diacríticos
        // ps.: já havia utilizado anteriormente em produção
        // -- fonte: https://stackoverflow.com/a/13155469
        private static string RemoveDiacritics(string str)
        {
            if (null == str) return null;
            var chars = str
                .Normalize(NormalizationForm.FormD)
                .ToCharArray()
                .Where(c=> CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray();

            return new string(chars).Normalize(NormalizationForm.FormC);
        }
    }
}
