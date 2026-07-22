// See https://aka.ms/new-console-template for more information
using AoC2025;
using System.Runtime.InteropServices;

Dial dial = new Dial(50);
DialController dialController = new DialController(dial);
ProductIDController idController = new ProductIDController();
BatteryBankController batteryController = new BatteryBankController();
StorageController storageController = new StorageController();

idController.UpdateRanges("AoCQ2.txt");

dialController.UpdateInstructions("AoCQ1.txt");

dialController.UpdateZeroes();

Console.WriteLine("Zero Stops: " + dialController.ZeroStop + "\nZeroTouch: " + dialController.ZeroTouch);

foreach (ProductRange range in idController.Ranges)
{
    idController.CheckRangeForInvalidPart1(range);
}
Console.WriteLine("Sum of all invalid: " + idController.InvalidIDs.Sum().ToString());
idController.InvalidIDs.Clear();

foreach (ProductRange range in idController.Ranges)
{
    idController.CheckRangeForInvalidPart2(range);
}
Console.WriteLine("Sum of all invalid: " + idController.InvalidIDs.Sum().ToString());
idController.InvalidIDs.Clear();


batteryController.UpdateBatteryBank("AoCQ3.txt");
int[] batteries = new int[400];
int[] batteries2 = new int[400];
int i = 0;
foreach (BatteryBank bank in batteryController.Banks)
{
    Battery highest = batteryController.findFirstHighest(bank, 1);
    Battery secondHighest = batteryController.findSecondHighest(bank, highest);
    string v = highest.BatteryLevel.ToString() + secondHighest.BatteryLevel.ToString();
    batteryController.VoltageSum += long.Parse(v);
    batteries[i] = int.Parse(highest.BatteryLevel.ToString() + secondHighest.BatteryLevel.ToString());
    i++;
}
Console.WriteLine("Sum of highest voltage: " + batteryController.VoltageSum);
batteryController.VoltageSum = 0;
i = 0;

foreach (BatteryBank bank in batteryController.Banks)
{
    long voltage = batteryController.HighestVoltage(bank, 2);
    batteries2[i] = (int)voltage;
    i++;
    batteryController.VoltageSum += batteryController.HighestVoltage(bank, 2);
}
Console.WriteLine("Sum of highest voltage output: " + batteryController.VoltageSum.ToString());

storageController.UpdateMap("AoCQ4.txt");

//for (int i = 0; i < storageController.Rows; i++)
//{
//    for (int j = 0; j < storageController.Columns; j++)
//    {
//        Console.Write(storageController.StorageMap[i][j]);
//    }
//    Console.Write('\n');
//}
Console.WriteLine("Rows: " + storageController.Rows.ToString() + "\nColumns: " + storageController.Columns.ToString());
Console.WriteLine("Index 3, 130: " + storageController.StorageMap[3][130]);
Console.WriteLine("Index 135, 122: " + storageController.StorageMap[134][122]);
Console.WriteLine(storageController.PaperRolls.Count());

return;
