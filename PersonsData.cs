using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp
{
    public class PersonsData
    {
        public static List<Person> person = new List<Person>();

        public PersonsData()
        {
            person.Add(new Person(1, "Abuzer Komurcu"));
            person.Add(new Person(2, "Erdal Komurcu"));
            person.Add(new Person(3, "Husrev Aga"));
            person.Add(new Person(4, "Pala"));
        }
    }
}