using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace day7_1.Models
{
    public class Filex
    {
        public Filex(string name, int size)
        {
            Name = name;
            Size = size;
        }

        public string Name { get; init; }
        public int Size { get; init; }
    }
}