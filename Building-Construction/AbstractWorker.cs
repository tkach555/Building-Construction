using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building_Construction
{
    abstract class AbstractWorker
    {
        public string Name { get; set; }
        public int Velocity { get; }

        public AbstractWorker(string name)
        {
            Name = name;
            Random rnd = new Random();
            Velocity = rnd.Next(10, 20);
        }
    }
}
