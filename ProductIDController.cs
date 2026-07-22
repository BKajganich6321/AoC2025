using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC2025
{
    internal class ProductIDController
    {
        public List<ProductRange> Ranges { get; set; }
        public List<double> InvalidIDs { get; set; }

        public ProductIDController()
        {
            Ranges = new List<ProductRange>();
            InvalidIDs = new List<double>();
        }
        
        public string[]? SplitID(ProductID ID)
        {
            string[]? halves = ["", ""];
            if (ID == null || ID.idString.Length % 2 != 0)
            {
                return null;
            }
            else
            {
                halves[0] = ID.idString.Substring(0, ID.idString.Length / 2);
                halves[1] = ID.idString.Substring(ID.idString.Length / 2);
            }
            return halves;
        }
        public void CheckRangeForInvalidPart1(ProductRange range) // 5000-5999
        {
            if(range.LowerLimitString.Length % 2 == 0)
            {
                double invalidSequence = 0;
                string[]? lowerID = SplitID(new ProductID(range.LowerLimit, range.LowerLimitString));
                string[]? upperID = SplitID(new ProductID(range.UpperLimit, range.UpperLimitString));
                if (lowerID != null && upperID != null)
                {
                    while (double.Parse(lowerID[0]) /*400*/ <= double.Parse(upperID[0]) /* 500 */)
                    {
                        invalidSequence = double.Parse(lowerID[0] + lowerID[0]); //"400400" then "401401" "402402
                        if (range.LowerLimit <= invalidSequence && invalidSequence <= range.UpperLimit)
                        {
                            InvalidIDs.Add(invalidSequence);
                        }
                        lowerID[0] = (double.Parse(lowerID[0]) + 1).ToString();
                    }
                }
            }
            else
            {
                return;
            }
        }

        public void CheckRangeForInvalidPart2(ProductRange range)
        {
            string regexInvalidPattern = @"^(\d+)\1+$";

            for (double id = range.LowerLimit; id <= range.UpperLimit; id++)
            {
                if (Regex.IsMatch(id.ToString(), regexInvalidPattern))
                {
                    if(InvalidIDs.Contains(id) == false)
                    {
                        InvalidIDs.Add(id);
                    }
                }
            }
            return;
        }
            //if (range.LowerLimitString.Length % 2 == 0)
            //{
            //    double invalidSequence = 0;
            //    string[]? lowerID = SplitID(new ProductID(range.LowerLimit, range.LowerLimitString));
            //    string[]? upperID = SplitID(new ProductID(range.UpperLimit, range.UpperLimitString));
            //    if (lowerID != null && upperID != null)
            //    {
            //        while (double.Parse(lowerID[0]) <= double.Parse(upperID[0]))
            //        {
            //            invalidSequence = double.Parse(lowerID[0] + lowerID[0]);
            //            if (range.LowerLimit <= invalidSequence && invalidSequence <= range.UpperLimit)
            //            {
            //                InvalidIDs.Add(invalidSequence);
            //            }
            //            lowerID[0] = (double.Parse(lowerID[0]) + 1).ToString();
            //        }
            //    }
            //}
            //else
            //{
            //    return;
            //}
      //}
        public void UpdateRanges(string path)
        {
            using (StreamReader fileReader = new StreamReader(path))
            {
                string? line = fileReader.ReadLine();
                if (line != null)
                {
                    line = line.Trim();
                    string[] ranges = line.Split(',');
                    foreach (string rangeString in ranges)
                    {
                        ProductRange? currentRange = ValidateRange(rangeString);
                        if(currentRange != null)
                        {
                            SplitRanges(currentRange);
                        }
                    }
                }
            }
        }
        public ProductRange? ValidateRange(string range)
        {
            if (range == null)
            {
                return null;
            }
            string[] split = range.Split("-"); 
            if (range.Split('-').Length != 2)
            {
                return null;
            }
            string lowerLim = range.Split('-')[0];
            string upperLim = range.Split('-')[1];
            try
            {
                double upperInt = double.Parse(upperLim);
                double lowerInt = double.Parse(lowerLim);

                if (upperInt <= lowerInt)
                {
                    return null;
                }
                else return new ProductRange(upperLim, lowerLim, upperInt, lowerInt);
            }
            catch
            {
                return null;
            }
        }

        public void SplitRanges(ProductRange range)
        {
            if (range.LowerLimitString.Length != range.UpperLimitString.Length)
            {
                string newLimit = "";
                while(newLimit.Length != range.UpperLimitString.Length - 1)
                {
                    newLimit += "9";
                }
                Ranges.Add(new ProductRange(newLimit, range.LowerLimitString, double.Parse(newLimit), range.LowerLimit));

                newLimit = "1";
                while(newLimit.Length != range.UpperLimitString.Length)
                {
                    newLimit += "0";
                }
                newLimit.Concat(range.UpperLimitString);
                Ranges.Add(new ProductRange(range.UpperLimitString, newLimit, range.UpperLimit, double.Parse(newLimit)));
            }
            else
            {
                Ranges.Add(range);
            }
        }
    }
}
