using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaEntityCF.Models
{
    public class Utils
    {
        public static bool ValidarCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf, digito;
            int soma, resto;
            //Formatando para deixar o CPF somente com os números, sem caracteres especiais
            cpf = cpf.ToLower().Trim();
            cpf = cpf.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "");
            cpf = cpf.Replace("+", "").Replace("*", "").Replace(",", "").Replace("?", "");
            cpf = cpf.Replace("!", "").Replace("@", "").Replace("#", "").Replace("$", "");
            cpf = cpf.Replace("%", "").Replace("¨", "").Replace("&", "").Replace("(", "");
            cpf = cpf.Replace("=", "").Replace("[", "").Replace("]", "").Replace(")", "");
            cpf = cpf.Replace("{", "").Replace("}", "").Replace(":", "").Replace(";", "");
            cpf = cpf.Replace("<", "").Replace(">", "").Replace("ç", "").Replace("Ç", "");
            //Se o CPF for informado vazio
            if (cpf.Length == 0)
            {
                Console.WriteLine("CPF inválido");
                Pause();
                return false;
            }
            //Se a quantidade de dígitos for diferente do permitido (11)
            if (cpf.Length != 11)
            {
                Console.WriteLine("CPF inválido");
                Pause();
                return false;
            }
            //Se os números informados forem todos iguais
            switch (cpf)
            {
                case "00000000000": return false;
                case "11111111111": return false;
                case "22222222222": return false;
                case "33333333333": return false;
                case "44444444444": return false;
                case "55555555555": return false;
                case "66666666666": return false;
                case "77777777777": return false;
                case "88888888888": return false;
                case "99999999999": return false;
            }
            tempCpf = cpf.Substring(0, 9);
            //Calculo para gerar um número de CPF válido
            soma = 0;
            for (int i = 0; i < 9; i++) soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2) resto = 0;
            else resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++) soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2) resto = 0;
            else resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
        public static void Pause()
        {
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
        public static DateTime ColetarData(string texto)
        {
            DateTime data;
            do
            {
                Console.Write(texto);
                if (!DateTime.TryParse(Console.ReadLine(), out data))
                {
                    Console.WriteLine("Informe uma data válida!!!");
                    Pause();
                }
                else return data;
            } while (true);
        }
        public static int ColetarValorInt(string texto)
        {
            int valor;
            do
            {
                Console.Write(texto);
                if (!int.TryParse(Console.ReadLine(), out valor) || valor < 0)
                {
                    Console.WriteLine("Informe uma opção válida...");
                    Pause();
                }
                else return valor;
            } while (true);
        }
        public static char ColetarValorChar(string texto)
        {
            char valor;
            do
            {
                Console.Write(texto);
                if (!char.TryParse(Console.ReadLine().ToUpper(), out valor) && char.IsWhiteSpace(valor))
                {
                    Console.WriteLine("Informe uma opção válida...");
                    Pause();
                }
                else
                    return valor;
            } while (true);
        }
        public static String ColetarString(string texto)
        {
            string valor;
            do
            {
                Console.Write(texto);
                valor = Console.ReadLine().ToUpper();
                if (String.IsNullOrWhiteSpace(valor))
                {
                    Console.WriteLine("Insira uma informação válida...");
                    Pause();
                    Console.Clear();
                }
                return valor;
            } while (true);
        }
    }
}
