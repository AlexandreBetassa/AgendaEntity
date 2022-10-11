using AgendaEntityCF.Controllers;
using AgendaEntityCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaEntityCF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do Menu();
            while (true);
        }

        public static void Menu()
        {
            int op = Utils.ColetarValorInt("INFORME A OPERAÇÃO\n(0 - Sair)\n(1 - Cadastrar Novo usuario)\n" +
                "(2 - Listar)\n(3 - Update)\n(4 - Delete)\nInforme: ");
            switch (op)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    Cadastrar();
                    break;
                case 2:
                    new PersonControlller().Select().ForEach(item => Console.WriteLine(item + "\n\n"));
                    break;
                case 3:
                    Update();
                    break;
                case 4:
                    Delete();
                    break;
                default:
                    Console.WriteLine("Opção Inválida");
                    break;
            }
        }

        public static void Cadastrar()
        {
            Person person = new Person();
            person.Name = Utils.ColetarString("Informe o nome: ");
            person.Mail = Utils.ColetarString("Informe o email: ");
            person.Numbers.Fix = Utils.ColetarString("Informe o número do telefone fixo: ");
            person.Numbers.Mobile = Utils.ColetarString("Informe o número do telefone celular: ");

            Console.WriteLine(person);
            new PersonControlller().Insert(person);
        }
        public static void Cadastrar(Person person)
        {
            person.Mail = Utils.ColetarString("Informe o email: ");
            person.Numbers.Mobile = Utils.ColetarString("Informe o número do telefone celular: ");
            new PersonControlller().Update(person);
        }

        public static void Update()
        {
            string nome = Utils.ColetarString("Informe o nome da pessoa a ser atualizada: ");
            var person = new PersonControlller().Select().SingleOrDefault(item => item.Name == nome);
            Console.WriteLine(person + "\n\n");
            Cadastrar(person);
        }
        public static void Delete()
        {
            string nome = Utils.ColetarString("Informe o nome da pessoa a ser removida: ");
            var person = new PersonControlller().Select().SingleOrDefault(item => item.Name == nome);
            Console.WriteLine(person + "\n\n");
            new PersonControlller().Delete(person);
        }

    }
}
