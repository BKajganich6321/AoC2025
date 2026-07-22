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
                int x = 0;
                while(line != "\n" && line != null)
                {
                    line = line.Trim();
                    string[] rangeString = line.Split('-');
                    (double start, double end) range = (double.Parse(rangeString[0]), double.Parse(rangeString[1]));

                    Intervals[x] = range;    
                    x++;
                }
                while(line != null)
                {
                    if(line == '\n')
                    {
                        x = 0;
                        line = fileReader.ReadLine();
                    }
                    line = line.Trim();
                    FreshItems[x] = double.TryParse(line);
                    x++;
                    line = fileReader.ReadLine();
                }
            }
        }

    }
}