using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace day11_1
{
    public class Monkey
    {
        public Monkey(int id, List<Item> items, int operation, int divisible, int ifTrue, int ifFalse)
        {
            Id = id;
            Items = items;
            Operation = operation;
            Divisible = divisible;
            IfTrue = ifTrue;
            IfFalse = ifFalse;
        }

        public int Id { get; set; }
        public List<Item> Items { get; set; }
        public int Operation { get; set; }
        public int Divisible { get; set; }
        public int IfTrue { get; set; }
        public int IfFalse { get; set; }

        void Turn()
        {
            foreach (var item in Items)
            {
            }
        }
    }
}