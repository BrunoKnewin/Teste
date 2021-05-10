using System;
using System.Linq;
namespace Knewin.FirstNumberRepeat.ConsoleApp
{
    public class FirstNumberRepeat
    {
        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("Digite o comprimento do vetor ('sair' para encerrar!)");
                
                string arraySizeStr = Console.ReadLine();
                if (arraySizeStr.Equals("sair"))
                    return;
                int arraySize = int.Parse(arraySizeStr);


                int[] values = new int[arraySize];
                Console.WriteLine("Digite os valores do vetor somente com inteiros: ");

                for (int i = 0; i < arraySize; i++)
                {
                    string valueStr = Console.ReadLine();
                    values[i] = int.Parse(valueStr);
                }
                int repeatedIndex = FindFirstRepeatedIndex(values);
                if (repeatedIndex == -1)
                    Console.WriteLine("Não foi encontrado nenhum número repetido no vetor");
                else
                    Console.WriteLine("Index do primeiro número repetido: {0}", repeatedIndex);

            }
            catch (FormatException ex)
            {
                Console.WriteLine("Você digitou um valor não inteiro, Encerrando...");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Overflow para o valor inteiro inserido, Encerrando...");
            }
            Console.ReadLine();
        }

        private static int FindFirstRepeatedIndex(int[] values)
        {
            int currentIndex = 1;
            foreach (var value in values)
            {
                int[] auxArray = values.Skip(currentIndex).ToArray();
                if (ContainsItem(value, auxArray))
                {
                    int repeatedIndex = currentIndex - 1;
                    Console.WriteLine("Indice de item duplicado {0}", currentIndex - 1);
                    Console.WriteLine("Valor de indice duplicado {0}", value);
                    Console.WriteLine();
                    return repeatedIndex;
                }
                ++currentIndex;
            }
            return -1;
        }

        private static bool ContainsItem(int value, int[] auxArray)
        {
            bool contain = false;
            foreach (var item in auxArray)
            {
                if (value == item)
                    contain = true;
            }
            return contain;
        }

    }
}
