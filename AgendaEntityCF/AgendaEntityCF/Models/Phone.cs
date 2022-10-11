using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaEntityCF.Models
{
    public class Phone
    {
        [Key]
        public string Fix { get; set; }
        public string Mobile { get; set; }

        public override string ToString()
        {
            return $"Telefone Fixo: {Fix}\nTelefone Móvel: {Mobile}".ToString();
        }
    }
}
