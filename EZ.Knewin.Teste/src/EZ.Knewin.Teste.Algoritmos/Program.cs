using System;

namespace EZ.Knewin.Teste.Algoritmos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Olá! Vamos aos Algoritmos...");

            Duplicados(new int[] { 1, 2, 3, 4, 1, 4, 2 });

            Console.WriteLine();

            Palindromo();
        }

        public static void Duplicados(int[] vetor)
        {
            Console.WriteLine("--- Duplicados na Lista ---");

            var tamanho = vetor.Length;
            bool temDuplicado = false;

            for (int i = 0; i < tamanho; i++)
            {
                for (int j = i + 1; j < tamanho; j++) 
                {
                    if (vetor[i] == vetor[j])
                    {
                        temDuplicado = true;
                        Console.WriteLine($"{vetor[i]} está duplicado no índice {j}");
                        continue;
                    }
                }

                if (temDuplicado) break;
            }
        }

        public static void Palindromo()
        {
            Console.WriteLine("--- Verificando Palindromo ---");

            string palavra, palavraAoContrario = string.Empty;

            Console.WriteLine("Informe uma palavra:");
            palavra = Console.ReadLine();

            if (!string.IsNullOrEmpty(palavra))
            {
                var auxiliar = palavra.ToCharArray();

                Array.Reverse(auxiliar);

                palavraAoContrario = new string(auxiliar);

                bool ehPalindromo = palavra.Equals(palavraAoContrario, StringComparison.OrdinalIgnoreCase);

                string prepo = ehPalindromo ? "é" : "não é";

                Console.WriteLine($"{palavra} {prepo} um Palindromo!");
            }
        }
    }
}
