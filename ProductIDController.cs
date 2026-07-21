using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AoC2025
{
    /// <summary>
    /// PART 1 SAMPLE RANGES and SOLUTIONS
        // 11-22 has two invalid IDs, 11 and 22.
        // 95-115 has one invalid ID, 99.
        // 998-1012 has one invalid ID, 1010.
        // 1188511880-1188511890 has one invalid ID, 1188511885.
        // 222220-222224 has one invalid ID, 222222.
        // 1698522-1698528 contains no invalid IDs.
        // 446443-446449 has one invalid ID, 446446.
        // 38593856-38593862 has one invalid ID, 38593859.
    /// </summary>
    /// <summary>
    /// PART 2 SAMPLE RANGES and SOLUTIONS
        // 11-22 still has two invalid IDs, 11 and 22.
        // 95-115 now has two invalid IDs, 99 and 111.
        // 998-1012 now has two invalid IDs, 999 and 1010.
        // 1188511880-1188511890 still has one invalid ID, 1188511885.
        // 222220-222224 still has one invalid ID, 222222.
        // 1698522-1698528 still contains no invalid IDs.
        // 446443-446449 still has one invalid ID, 446446.
        // 38593856-38593862 still has one invalid ID, 38593859.
        // 565653-565659 now has one invalid ID, 565656.
        // 824824821-824824827 now has one invalid ID, 824824824.
        // 2121212118-2121212124 now has one invalid ID, 2121212121.
    /// </summary>

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
        public void CheckInvalidPart1(ProductRange range) // 5000-5999
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

        public void CheckInvalidPart2(ProductRange range)
        {
            List<string> repeatableSequences = new List<string>();
            for (int repeatedLength = 1; repeatedLength <= range.UpperLimitString.Length / 2; repeatedLength++)
            {
                string sequence = range.LowerLimitString.Substring(0, repeatedLength);
                while (double.Parse(sequence) < double.Parse(range.UpperLimitString.Substring(0, repeatedLength)))
                {
                    repeatableSequences.Add(sequence);
                    sequence = (double.Parse(sequence) + 1).ToString();
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
