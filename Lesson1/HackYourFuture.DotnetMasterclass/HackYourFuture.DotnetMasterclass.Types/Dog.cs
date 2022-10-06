using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackYourFuture.DotnetMasterclass.Types
{
    public class Dog
    {
        public Dog(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public Person Owner { get; set; }
    }
}
