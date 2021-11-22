using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MalgreTout
{
    public class Udleveringssted
    {
        //TEST
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }

        public Udleveringssted(int id, string name, string adress)
        {
            Id = id;
            Name = name;
            Adress = adress;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Adress: {Adress}";
        }
    }

   
}
