using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AoC2025
{
    internal class FreshIDController
    {
        public (long start, long end)[]? Intervals { get; set; }

        public long[] FreshItems { get; set; }

        public FreshIDController (string path)
        {
            UpdateIntervals(path);
        }

        public void UpdateIntervals(string path)
        {
            using (StreamReader fileReader = new StreamReader(path))
            {
                string? line = fileReader.ReadLine();
                List<(long start, long end)> rangeList = new();
                List<long> freshItemList = new();

                while (line != "" && line != null)
                {
                    line = line.Trim();
                    string[] rangeString = line.Split('-');
                    (long start, long end) range = (long.Parse(rangeString[0]), long.Parse(rangeString[1]));

                    rangeList.Add(range);
                    line = fileReader.ReadLine();
                }
                rangeList.Sort((tuple1, tuple2) => tuple1.start.CompareTo(tuple2.start));
                
                Intervals = MergeRanges(rangeList);
                
                while(line != null)
                {
                    if(line.Trim() == string.Empty)
                    {
                        line = fileReader.ReadLine();
                    }
                    line = line.Trim();
                    freshItemList.Add(long.Parse(line));
                    line = fileReader.ReadLine();
                }
                freshItemList.Sort();
                FreshItems = freshItemList.ToArray();
            }
        }

        public (long start, long end)[] MergeRanges(List<(long start, long end)> ranges)
        {
            List<(long start, long end)> MergedRanges = new List<(long start, long end)>();

            bool pastFirstIteration = false;
            (long start, long end) bestRange = new();
            ranges.Add(ranges.Last());

            foreach ((long start, long end) currentRange in ranges)
            {
                if (!pastFirstIteration)
                {
                    pastFirstIteration = true;
                    bestRange = currentRange;
                }
                else
                {
                    if (bestRange.end < currentRange.end)
                    {
                        if (bestRange.end > currentRange.start)
                        {
                            bestRange.end = currentRange.end;
                        }
                        else
                        {
                            MergedRanges.Add(bestRange);
                            bestRange = currentRange;
                        }
                    }
                }
            }
            MergedRanges.Add(bestRange);
            return MergedRanges.ToArray();
        }


        public int FreshCount((long start, long end)[] ranges, long[] ingredientIDs)
        {
            int ingredientIndex = 0;
            int freshIngredientCount = 0;
            int dynamicIngredientIndex = 0;
            foreach ((long start, long end) range in ranges)
            {
                if (dynamicIngredientIndex == 0)
                {
                    while (ingredientIDs[dynamicIngredientIndex] < range.start)
                    {
                        dynamicIngredientIndex++;
                    }
                }
                for(int i = dynamicIngredientIndex; ingredientIDs[i] <= range.end; i++)
                {
                    if (ingredientIDs[i] >= range.start)
                    {
                        freshIngredientCount++;
                    }
                    dynamicIngredientIndex++;
                }        
            }

            return freshIngredientCount;
        }
    }
}
