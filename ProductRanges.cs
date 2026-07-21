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
        //11-22 has two invalid IDs, 11 and 22.
        //95-115 has one invalid ID, 99.
        //998-1012 has one invalid ID, 1010.
        //1188511880-1188511890 has one invalid ID, 1188511885.
        //222220-222224 has one invalid ID, 222222.
        //1698522-1698528 contains no invalid IDs.
        //446443-446449 has one invalid ID, 446446.
        //38593856-38593862 has one invalid ID, 38593859.
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
