using System;
using System.Collections.Generic;
using System.Linq;

namespace Knewin.Algorithms
{
    public static class Duplication
    {

        public static void Execute()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Informe a lista de valores inteiros separados por 1 espaço. Ex: 1 2 3...");
            var input = Console.ReadLine();
            var values = input.Trim()
                .Split(" ")
                .Select(v => Convert.ToInt32(v.Trim()))
                .ToArray();

            try
            {
                Console.WriteLine($"O índice do primeiro valor duplicado é: {FindFirstDuplication(values)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("----------------------------------------------------------");
        }

        public static int FindFirstDuplication(int[] list)
        {
            Dictionary<int, int> res = new Dictionary<int, int>();

            for (int i = 0; i < list.Length; i++)
            {
                if (res.ContainsKey(list[i])) res[list[i]]++;
                else res[list[i]] = 0;

                if (res[list[i]] > 0) return i;
            }

            throw new Exception("A lista não possui valores duplicados.");
        }
    }
}
