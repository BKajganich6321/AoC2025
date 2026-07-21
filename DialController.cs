using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2025
{
    internal class DialController
    {
        private Dial Dial { get; set; }
        public List<DialInstruction> Instructions { get; set; }
        public int ZeroStop { get; set; }
        public int ZeroTouch { get; set; }
        public int Password {  get; set; }

        public DialController(Dial dial)
        {
            Dial = dial;
            Instructions = new List<DialInstruction>();
            ZeroStop = 0;
            ZeroTouch = 0;
            Password = 0;
        }
        
        public void UpdateInstructions(string path)
        {
            using (StreamReader fileReader = new StreamReader(path))
            {
                string? line = fileReader.ReadLine();
                string? direction;
                int count = 0;
                while (line != null)
                {
                    line = line.Trim();
                    direction = line[0].ToString();
                    line = line.Substring(1);
                    count = int.Parse(line);
                    Instructions.Add(new DialInstruction(direction, count));
                    line = fileReader.ReadLine();
                }
            }
        }

        public void UpdateZeroes()
        {
            foreach (DialInstruction instruction in Instructions)
            {
                int lastDial = Dial.DialPos;

                if (instruction.Count > 100)
                {
                    ZeroTouch += instruction.Count / 100;
                }

                instruction.Count %= 100;

                Dial.Turn(instruction);

                if (lastDial == 0 || instruction.Count == 0) continue;

                if (Dial.DialPos == 0)
                {
                    ZeroStop++;
                    ZeroTouch++;
                }
                else if (instruction.Direction == "R" && lastDial + instruction.Count > 100)
                {
                    ZeroTouch++;
                }
                else if (instruction.Direction == "L" && lastDial - instruction.Count < 0)
                {
                    ZeroTouch++;
                }
            }
        }

        public void ResetDial(int resetDialPos)
        {
            ZeroTouch = 0;
            ZeroStop = 0;
            Password = 0;
            Instructions.Clear();
            Dial.DialPos = resetDialPos;
        }
    }
}
