using System;
class MyFirstConsoleApplication
{
    static void Main()
    {
        string myName, myLocation;
        DateTime today, christmas;
        int daysLeft;

        myName = "Anderson Ortiz Dias Junior";
        myLocation = "Brazil";
        today = DateTime.Now;
        christmas = new DateTime(2023, 12, 25, 0, 0, 0);
        daysLeft = (int)(christmas - today).TotalDays;

        Console.WriteLine("My name is {0}", myName);
        Console.WriteLine("I am from {0}", myLocation);
        Console.WriteLine("Today is {0}", today.ToString("dd/MM/yyyy"));
        Console.WriteLine("There are {0} days left until Christmas!", daysLeft);
        MyFirstConsoleApplication.GlazerCalc();
        Console.ReadKey();
    }

    static void GlazerCalc()
    {
        double width, height, woodLength, glassArea;
        string widthString, heightString;
        Console.WriteLine("----------------------------\nGlazer Calculator from C# Programming Yellow Book by Rob Miles\n");
        Console.WriteLine("What is the width?");
        widthString = Console.ReadLine();
        width = double.Parse(widthString);

        Console.WriteLine("What is the height?");
        heightString = Console.ReadLine();
        height = double.Parse(heightString);

        woodLength = 2 * (width + height) * 3.25;
        glassArea = 2 * (width * height);

        Console.WriteLine("The length of the wood is " +
        woodLength + " feet");
        Console.WriteLine("The area of the glass is " +
        glassArea + " square metres");
    }
}