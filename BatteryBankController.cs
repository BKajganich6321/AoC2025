using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace AoC2025
{
    internal class BatteryBankController
    {
        public List<BatteryBank>? Banks { get; set; }
        public List<Battery> BatteriesFound { get; set; }
        public long VoltageSum { get; set; }

        public BatteryBankController()
        {
            BatteriesFound = new List<Battery>();
            VoltageSum = 0;
        }
        public void UpdateBatteryBank(string path)
        {
            using (StreamReader fileReader = new StreamReader(path))
            {
                string? line = fileReader.ReadLine();
                while (line != null)
                {
                    if(Banks == null)
                    {
                        Banks = new List<BatteryBank>();
                    }
                    BatteryBank currentBank = new BatteryBank();
                    //Take a line - 1 battery bank
                    //Iterate through the line and create a battery for each character, put battery in batteryBank.Batteries
                    currentBank.AddBatteries(line);
                    Banks.Add(currentBank);
                    line = fileReader.ReadLine();
                }
            }
        }

        public Battery findFirstHighest(BatteryBank bank, int lowestIndex)
        {
            Battery bestBattery = new Battery(0, 0);
            BatteriesFound.Add(bestBattery);
            foreach(Battery b in bank.Batteries)
            {
                int level = b.BatteryLevel;
                int bestIndex = b.BatteryIndex;
                if (bestBattery.BatteryLevel < b.BatteryLevel && b.BatteryIndex < bank.Batteries.Count - lowestIndex)
                {
                    bestBattery = b;
                }
            }
            return bestBattery;
        }
        public Battery findSecondHighest(BatteryBank bank, Battery highestBattery)
        {
            Battery secondBestBattery = new Battery(0, 0);
            foreach (Battery b in bank.Batteries)
            {
                int level = b.BatteryLevel;
                int bestIndex = b.BatteryIndex;
                if (b.BatteryLevel > secondBestBattery.BatteryLevel && b.BatteryIndex > highestBattery.BatteryIndex)
                {
                    secondBestBattery = b;
                }
            }
            return secondBestBattery;
        }

        public long HighestVoltage(BatteryBank bank, int batteryCount)
        { 
            int digitsNeeded = batteryCount; //Batteries needed from bank
            int length = bank.Batteries.Count; //number of batteries in bank
            string voltage = ""; //current voltage string
            int startSearch = 0; // Index at which to begin the search
            long totalVoltage = 0;
            int[] batteryArray = new int[bank.Batteries.Count];
            foreach (Battery battery in bank.Batteries)
            {
                batteryArray[battery.BatteryIndex] = battery.BatteryLevel;
            }

            for (int i = 0; i < digitsNeeded; i++) //for loop to iterate (with each iteration, collect a single battery)
            {
                int digitsLeft = digitsNeeded - 1 - i; //Each iteration, require 1 less battery
                int endSearch = length - digitsLeft; //AHHHHH If there's 12 digits left in a 15 digit string, you only need to check 15th, 14th, 13th.
                string maxLevel = "0";
                int maxIndex = -1;

                for (int j = startSearch; j < endSearch; j++)
                {
                    if (batteryArray[j] > int.Parse(maxLevel))
                    {
                        maxLevel = batteryArray[j].ToString();
                        maxIndex = j;
                        if (int.Parse(maxLevel) == 9)
                        {
                            break;
                        }
                    }
                }
                voltage = voltage + maxLevel;
                startSearch = maxIndex + 1;
            }
            totalVoltage = long.Parse(voltage);
            return totalVoltage;
        }
    }
}
