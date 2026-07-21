using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2025
{
    internal class Dial
    {
        public int DialPos {get; set;}

        public Dial(int dialPos)
        {
            DialPos = dialPos;
        }


        /// <summary>
        /// TURN: Take an instruction, turn the dial, change the dial current position
        /// </summary>
        /// <param name="instruction"></param>
        /// <exception cref="Exception"></exception>
        public void Turn(DialInstruction instruction)
        {
            try
            {
                if (instruction.Direction == "R")
                {
                    DialPos += instruction.Count;
                }
                else if (instruction.Direction == "L")
                {
                    DialPos -= instruction.Count;
                }
                DialPos = DialPos % 100;
                if(DialPos < 0)
                {
                    DialPos += 100;
                }
            }
            catch { throw new Exception();}
        }
    }
}
