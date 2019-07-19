using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building_Construction
{
    class AbstractPart
    {
        public string Name { get; set; }
        public int Difficulty { get; }

        public AbstractPart(string name)
        {
            Name = name;
            Random rnd = new Random();
            Difficulty = rnd.Next(1, 10);
        }
    }
}
