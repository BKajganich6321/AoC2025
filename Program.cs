// See https://aka.ms/new-console-template for more information
using AoC2025;

Dial dial = new Dial(50);
DialController dialController = new DialController(dial);
ProductIDController idController = new ProductIDController();

idController.UpdateRanges("AoCQ2.txt");
idController.Ranges.Add(new ProductRange("999999", "100000", 999999, 100000));

dialController.UpdateInstructions("AoCQ1.txt");

dialController.UpdateZeroes();

//foreach (ProductRange range in idController.Ranges)
//{ 
//    Console.WriteLine("One Range is " + range.LowerLimitString + '-' + range.UpperLimitString + "\n");
//    idController.CheckInvalidPart1(range);
//}
//foreach(double invalidID in idController.InvalidIDs)
//{
//    Console.WriteLine(invalidID.ToString() + " is invalid");
//}

idController.CheckInvalidPart2(new ProductRange("45652100", "21565000", 45652100, 21565000));
//Console.WriteLine("Sum of all invalid: " + idController.InvalidIDs.Sum().ToString())
    ;
// Q1 Console.WriteLine("Zero Stops: " + dialController.ZeroStop + "\nZeroTouch: " + dialController.ZeroTouch);


//1000-1999: 1010, 1111, 1212, 1313, 1414,1515,1616,1717,1818,1919 => 10
//1000-2999: 1010, 1111, 1212, 1313, 1414,1515,1616,1717,1818,1919, 2020, 2121, 2222, 2323, etc => 20
//1000-1099 
return;
