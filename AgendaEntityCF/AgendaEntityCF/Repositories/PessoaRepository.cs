using AgendaEntityCF.Models;
using AgendaEntityCF.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaEntityCF.Repositories
{
    public class PessoaRepository
    {
        public void Insert(Person person)
        {
            using (var db = new ContextAgendaCF())
            {
                db.Person.Add(person);
                db.SaveChanges();
            }
        }

        public List<Person> Select()
        {
            using (var db = new ContextAgendaCF())
            {
                var lstPerson = db.Person.Include(item => item.Numbers).ToList();
                return lstPerson;
            }
        }

        public void Update(Person person)
        {
            using (var db = new ContextAgendaCF())
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(Person person)
        {
            using (var db = new ContextAgendaCF())
            {
                db.Entry(person).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
