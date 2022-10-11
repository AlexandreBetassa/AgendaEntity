using AgendaEntityCF.Models;
using AgendaEntityCF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaEntityCF.Controllers
{
    public class PersonControlller
    {
        public void Insert(Person person) => new PessoaRepository().Insert(person);
        public List<Person> Select() => new PessoaRepository().Select();
        public void Update(Person person) => new PessoaRepository().Update(person);
        public void Delete(Person person) => new PessoaRepository().Delete(person);
    }
}
