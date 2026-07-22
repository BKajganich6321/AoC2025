using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2025
{
    internal class StorageController
    {
        public char[][] StorageMap {  get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public List<int[]> PaperRolls { get; set; }

        public StorageController() 
        {
            PaperRolls = new List<int[]>();
            Rows = 0; Columns = 0;
        }
        public void UpdateMap(string path)
        {    
            using (StreamReader fileReader = new StreamReader(path))
            {
                PaperRolls = new List<int[]>();
                string? line = fileReader.ReadLine();
                line.Trim();
                int x = 0;
                int y = 0;
                List<char[]> rows = new List<char[]>();
                int columns = 0;
                while (line != null)
                { 
                    line.Trim();
                    columns++;
                    char[] currentRow = line.ToCharArray();
                    for(int i = 0; i < currentRow.LongLength; i++)
                    {
                        if(currentRow[i] == '@')
                        {
                            int[] FoundRollLocation = [i, columns];
                            PaperRolls.Add(FoundRollLocation);
                        }
                    }
                    rows.Add(line.ToCharArray());
                    line = fileReader.ReadLine();
                }
                Columns = columns;
                Rows = rows.Count;
                StorageMap = rows.ToArray();
            }
        }
    }
}
