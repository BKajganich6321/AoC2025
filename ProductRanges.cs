using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AoC2025
{
    internal class ProductRange
    {
        public string UpperLimitString {  get; set; }
        public string LowerLimitString { get; set; }
        public double UpperLimit { get; set; }
        public double LowerLimit { get; set; }
        public ProductRange(string upperString, string lowerString, double upperLim, double lowerLim) 
        {
            UpperLimitString = upperString;
            LowerLimitString = lowerString;
            UpperLimit = upperLim;
            LowerLimit = lowerLim;
        }
    }
}
