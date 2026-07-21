using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AoC2025
{
    internal class DialInstruction
    {
        public string Direction {  get; set; }
        public int Count { get; set; }
        public DialInstruction(string direction, int count)
        {
            Count = count;
            Direction = direction;
        }
    }
}
