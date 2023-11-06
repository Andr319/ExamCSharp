using System;
using System.Drawing;
using Console = Colorful.Console;

class Program
{
    static double roomTemperature = 15.0;
    static double measuredTemperature = 15.0;
    static int humidity = 80;
    static double boilerPressure = 2.5;
    static double desiredTemperature = 21.0;

    static void Main()
    {
        Console.WriteLine("Heating Control System Console", Color.Blue);
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nAvailable commands:");
            Console.WriteLine("1. Set room temperature, measured temperature, humidity, and boiler pressure.");
            Console.WriteLine("2. Display the currently set values.");
            Console.WriteLine("3. Simulate the test operation.");
            Console.WriteLine("4. Reset to default values.");
            Console.WriteLine("5. Exit the program.");

            Console.Write("Enter a command (1-5): ");
            string command = Console.ReadLine();

            switch (command)
            {
                case "1":
                    SetValues();
                    break;
                case "2":
                    DisplayInfo();
                    break;
                case "3":
                    RunTest();
                    break;
                case "4":
                    ResetToDefaults();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid command. Please enter a valid command (1-5).", Color.Red);
                    break;
            }
        }
    }

    static void SetValues()
    {
        Console.Write("Enter room temperature (in °C): ");
        if (double.TryParse(Console.ReadLine(), out double value))
        {
            roomTemperature = value;
        }

        Console.Write("Enter measured temperature (in °C): ");
        if (double.TryParse(Console.ReadLine(), out value))
        {
            measuredTemperature = value;
        }

        Console.Write("Enter humidity (in %): ");
        if (int.TryParse(Console.ReadLine(), out int hum))
        {
            humidity = hum;
        }

        Console.Write("Enter boiler pressure (in bar): ");
        if (double.TryParse(Console.ReadLine(), out value))
        {
            boilerPressure = value;
        }
        Console.WriteLine("Values set successfully.", Color.Green);
    }

    static void DisplayInfo()
    {
        Console.WriteLine("Current Values:");
        Console.WriteLine($"Room Temperature: {roomTemperature:F2}°C");
        Console.WriteLine($"Measured Temperature: {measuredTemperature:F2}°C");
        Console.WriteLine($"Humidity: {humidity}%");
        Console.WriteLine($"Boiler Pressure: {boilerPressure:F2} bar");
        Console.WriteLine($"Desired Temperature: {desiredTemperature:F2}°C");
    }

    static void RunTest()
    {
        while (measuredTemperature < desiredTemperature)
        {
            Console.WriteLine($"Running test - Measured Temperature: {measuredTemperature:F2}°C");

            if (measuredTemperature <= (desiredTemperature - 2.0))
            {
                Console.WriteLine("Boiler on!", Color.Blue);
            }
            else if (humidity > 90 && desiredTemperature < measuredTemperature)
            {
                Console.WriteLine("Boiler on due to high humidity!", Color.Blue);
            }

           
            measuredTemperature += 0.2;
            if (measuredTemperature >= desiredTemperature)
            {
                Console.WriteLine("Desired temperature reached!", Color.Green);
                break;
            }

            if (measuredTemperature >= (desiredTemperature + 0.3))
            {
                Console.WriteLine("Boiler off!", Color.Blue);
            }

            if (boilerPressure < 2.0 || boilerPressure > 3.0)
            {
                Console.WriteLine("Boiler pressure error! Heating is off.", Color.Red);
                break;
            }
        }
    }

    static void ResetToDefaults()
    {
        roomTemperature = 15.0;
        measuredTemperature = 15.0;
        humidity = 80;
        boilerPressure = 2.5;
        desiredTemperature = 21.0;
        Console.WriteLine("Values reset to defaults.", Color.Green);
    }
}
