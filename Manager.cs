using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Manager
    {
        List<Offer> offers = new List<Offer>();
        List<Account> accounts = new List<Account>();
        public int id { get; set; }
        public string name { get; set; }
        public int salary { get; set; }
        public int position { get; set; }

        public Manager (string name, int salary, int position)
        {
            this.name = name;
            this.salary = salary;
            this.position = position;
        }
    }
}
