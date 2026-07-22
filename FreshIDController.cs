using System;
using System.Collections.Generic;
using System.Linq;
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

                int x = 0;
                while(line != "" && line != null)
                {
                    line = line.Trim();
                    string[] rangeString = line.Split('-');
                    (long start, long end) range = (long.Parse(rangeString[0]), long.Parse(rangeString[1]));

                    rangeList.Add(range);    
                    x++;
                    line = fileReader.ReadLine();
                }
                Intervals = rangeList.ToArray();
                
                while(line != null)
                {
                    if(line.Trim() == string.Empty)
                    {
                        x = 0;
                        line = fileReader.ReadLine();
                    }
                    line = line.Trim();
                    freshItemList.Add(long.Parse(line));
                    x++;
                    line = fileReader.ReadLine();
                }
                FreshItems = freshItemList.ToArray();
            }
        }

    }
}
