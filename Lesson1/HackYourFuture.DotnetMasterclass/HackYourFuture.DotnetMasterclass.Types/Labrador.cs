using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackYourFuture.DotnetMasterclass.Types
{
    public class Labrador : Dog
    {
        public Labrador(string name) : base(TransformName(name))
        {
        }

        private static string TransformName(string name)
        {
            return $"Good boy called: {name}";
        }
    }
}
