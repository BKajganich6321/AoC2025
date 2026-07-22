using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2025
{
    internal class Battery
    {
        public int BatteryLevel { get; set; }
        public int BatteryIndex { get; set; }

        public Battery (int batteryLevel, int batteryIndex)
        {
            BatteryLevel = batteryLevel;
            BatteryIndex = batteryIndex;
        }
    }
}
