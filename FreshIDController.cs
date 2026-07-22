using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2025
{
    internal class FreshIDController
    {
        public (double start, double end)[] Intervals { get; set; }

        public double[] FreshItems { get; set; }

        public FreshIDController (string path)
        {
            UpdateIntervals(path);
        }

        public void UpdateIntervals(string path)
        {
            using (StreamReader fileReader = new StreamReader(path))
            {
                string? line = fileReader.ReadLine();
                List<(double start, double end)> rangeList = new();
                int x = 0;
                while(line != "\n" && line != null)
                {
                    line = line.Trim();
                    string[] rangeString = line.Split('-');
                    (double start, double end) range = (double.Parse(rangeString[0]), double.Parse(rangeString[1]));

                    rangeList.Add(range);    
                    x++;
                    line = fileReader.ReadLine();
                }
                Intervals[x] = rangeList.ToArray();
                
                while(line != null)
                {
                    List<double item> freshItemList = new();
                    if(line == "\n")
                    {
                        x = 0;
                        line = fileReader.ReadLine();
                    }
                    line = line.Trim();
                    freshItemList.Add(double.TryParse(line));
                    x++;
                    line = fileReader.ReadLine();
                }
                FreshItems[x] = freshItemList.ToArray();
            }
        }

    }
}
