using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2025
{
    internal class ProductID
    {
        public double ID { get; set; }
        public string idString { get; set; }

        public ProductID (double id, string name)
        {
            ID = id;
            idString = name; 
        }
    }
}
