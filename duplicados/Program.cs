using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace duplicados
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length <= 0)
            {
                Console.WriteLine("USO DO PROGRAMA: duplicados <lista de números inteiros separados por vírgula>!");
                return;
            }

            string numbers = args[0];
            string separator = ",";
            
            bool validArgs = false;
            string errorMessage = string.Empty;
            (validArgs, errorMessage) = ValidateArgs(numbers, separator);
            if(!validArgs)
            {
                Console.WriteLine(errorMessage);
                return;
            }
            Console.WriteLine(FindDuplicates(numbers,separator));
            
        }

        /// encontra algum duplicado na lista
        private static string FindDuplicates(string numbers, string separator)
        {
            string result = "Não foram encontrados duplicados!";

            // faz o split da string, já convertendo para long
            long[] numberList = numbers
                .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                .Select(numberStr => long.Parse(numberStr))
                .ToArray();
            
            for(int index=0;index<numberList.Length-1;index++)
            {
                long currentNumber = numberList[index];
                // procura no array, a partir do indice atual + 1, um numero igual ao atual
                int dupIndex = Array.FindIndex<long>(numberList,index+1,num => currentNumber==num);
                if(dupIndex >= 0)
                {
                    result = $"Duplicado encontrado! \nnúmero: {currentNumber}, índices: {index},{dupIndex}";
                    break;
                }
            }

            return result;
        }

        ///Validações básicas
        private static (bool validArgs, string errorMessage) ValidateArgs(string numbers, string separator)
        {
            if(numbers.IndexOf(separator) < 0)
            {
                return (false,"Separador não encontrado na lista!");
            }
            if(!Regex.IsMatch(numbers,@$"^(\d+)({separator}\d+)*"))
            {
                return (false,"Lista inválida!");
            }

            return (true,string.Empty);
        }
    }
}
