using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AoC2025
{
    internal class StorageController
    {
        private static readonly (int x, int y)[] Neighboring =
            [
            (-1, 1), (0, 1), (1, 1),
            (-1, 0),         (1, 0),
            (-1, -1),(0, -1),(1, -1)
            ];
        public List<(int x, int y)> RemovableRolls { get; set; }
        public int Removables;
        public int Rows { get; set; }
        public int Columns { get; set; }
        public HashSet<(int x, int y)> PaperRolls { get; set; }

        public StorageController() 
        {
            Rows = 0; 
            Columns = 0;
            Removables = 0;
            RemovableRolls = new();
            PaperRolls = new();
        }
        public void UpdateMap(string path)
        {    
            using (StreamReader fileReader = new StreamReader(path))
            {
                PaperRolls = new();
                string? line = fileReader.ReadToEnd();
                string[] lines = line.Split('\n');
                Rows = lines.Length;
                Columns = lines[0].Length;
                for (int rows = 0; rows < lines.Length; rows++)
                {
                    for (int columns = 0; columns < lines[columns].Length; columns++)
                    {
                        if (lines[columns][rows] == '@')
                        {
                            PaperRolls.Add((columns, rows));
                        }
                    }
                }    
            }
        }

        public int NeighborCount((int x, int y) paperRoll)
        {
            int count = 0;
            (int x, int y) neighbor = new();
            foreach((int x, int y) shift in Neighboring)
            {
                neighbor = ((paperRoll.x + shift.x, paperRoll.y + shift.y));
                if(PaperRolls.Contains(neighbor))
                {
                    count++;
                }
            }
            return count;
        }

        public void SolveRemovables1()
        {
            foreach ((int x, int y) roll in PaperRolls)
            {
                if(NeighborCount(roll) < 4)
                {
                    Removables++;
                    RemovableRolls.Add(roll);
                }
            }
        }

        public void SolveRemovables2()
        {
            int lastCount = 0;
            do
            {
                lastCount = PaperRolls.Count();

                foreach ((int x, int y) roll in PaperRolls)
                {
                    if (NeighborCount(roll) < 4)
                    {
                        Removables++;
                        PaperRolls.Remove(roll);
                    }
                }
            } while(lastCount != PaperRolls.Count());
        }
    }
}
