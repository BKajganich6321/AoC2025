using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2025
{
    internal class BatteryBank
    {
        public List<Battery> Batteries { get; set; }
        public long VoltageSum { get; set; }
        public BatteryBank()
        {
            Batteries = new List<Battery>();
            VoltageSum = 0;
        }

        public void AddBatteries(string bankString)
        {
            for (int i = 0; i < bankString.Length; i++)
            {
                Battery currentBattery = new Battery(int.Parse(bankString.Substring(i, 1)), i);
                if (currentBattery != null)
                {
                    Batteries.Add(currentBattery);
                }
            }
        }
    }
}
