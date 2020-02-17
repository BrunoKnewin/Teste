using System;
using System.Globalization;
using System.Text;

namespace Palindromo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(VerificarString(RemoverAcentos("Socorram-me, subi no ônibus em Marrocos2")));
            Console.Read();
        }

        static bool VerificarString(string conteudo)
        {
            string reverseConteudo = string.Empty;
            var conteudoArray = conteudo.ToCharArray();
            for(int i = conteudoArray.Length -1; i>= 0; i--)
            {
                reverseConteudo += conteudoArray[i];
            }
            return conteudo == reverseConteudo;

        }
        static string RemoverAcentos(string texto)
        {
            texto = texto.ToUpper();
            string s = texto.Normalize(NormalizationForm.FormKD);
            StringBuilder sb = new StringBuilder();

            for (int k = 0; k < s.Length; k++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(s[k]);
                if (uc == UnicodeCategory.SpaceSeparator || uc == UnicodeCategory.UppercaseLetter || uc == UnicodeCategory.DecimalDigitNumber)
                {
                    sb.Append(s[k]);
                }
            }
            return sb.ToString().Replace(" ", "");
        }
    }
}
