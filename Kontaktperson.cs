using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MalgreTout
{
    public class Kontaktperson
    {
        public int Id { get; set; }
        public string Person { get; set; }
        public int Tlf {get; set;}
        public string Mail { get; set; }

        public Kontaktperson (int id, string person, int tlf, string mail)
        {
            Id = id;
            Person = person;
            Tlf = tlf;
            Mail = mail;
        }

        public override string ToString()
        {
            return $"Id: {Id}\n Person: {Person}\n Tlf: {Tlf}, Mail: {Mail}";
        }
    }
}
