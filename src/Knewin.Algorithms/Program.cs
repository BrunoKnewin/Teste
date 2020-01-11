using System;

namespace Knewin.Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Escolha qual algoritmo executar!");
                Console.WriteLine("1 - Duplicado na lista.");
                Console.WriteLine("2 - Palindromo.");
                Console.WriteLine("3 - Fechar");

                var key = Console.ReadLine();

                switch (key)
                {
                    case "1":
                        Duplication.Execute();
                        break;
                    case "2":
                        Palindrome.Execute();
                        break;
                    case "3":
                        Console.WriteLine("Bye Bye....");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }
    }
}
