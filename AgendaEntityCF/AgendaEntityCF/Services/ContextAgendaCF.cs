using AgendaEntityCF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaEntityCF.Services
{
    internal class ContextAgendaCF : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<Phone> Phone { get; set; }
    }
}
