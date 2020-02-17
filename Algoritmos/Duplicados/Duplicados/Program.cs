using System;
using System.Linq;

namespace Duplicados
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inicio");

            int [] vetor = new []{ 1 };

            VerificaArray(vetor);
            Console.ReadLine();
        }

        static void VerificaArray(int [] vetor) 
        {
            int menorIndice = vetor.Length - 1;
            var duplicados = vetor.ToList().Select(x => new { Numero = x, Quanditade = vetor.Where(y => y == x).Count()} ).Where(x => x.Quanditade > 1).ToHashSet();
            duplicados.ToList().ForEach(x =>
            {
                int primeiroIndice =-1;
                int segundoIndice = -1;
                for(int i=0; i< vetor.Length; i++)
                {
                    if(vetor[i] == x.Numero)
                    {
                        if (primeiroIndice == -1 && segundoIndice == -1) { primeiroIndice = i; }
                        else
                        if (primeiroIndice != -1 && segundoIndice == -1) { segundoIndice = i; }
                        else
                        { break; }
                    }
                }
                if(segundoIndice < menorIndice)
                {
                    menorIndice = segundoIndice;
                }
            });

            Console.WriteLine(menorIndice);
        }
    }
}
