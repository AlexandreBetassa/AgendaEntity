using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaEntityCF.Models
{
    public class Person
    {
        [Key]
        public string Name { get; set; }
        public string Mail { get; set; }
        public Phone Numbers { get; set; } = new Phone();


        public override string ToString()
        {
            return $"Nome: {Name}\nEmail: {Mail}\n" +
                   $"Telefone Fixo: {Numbers.Fix}\n" +
                   $"Telefone Móvel: {Numbers.Mobile}".ToString();
        }
    }
}
