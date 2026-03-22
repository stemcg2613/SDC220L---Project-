/*******************************************************************
* Name: Steven McGraw
* Date: 2026-03-22
* Assignment: SDC220 Performance Assessment - Calculator Phase 2
*
* Main application (program) class.
* This application demonstrates a basic calculator using a menu-driven
* interface. The user can add, subtract, multiply, or divide two numbers.
* The program loops until the user chooses to quit. Arithmetic logic is
* encapsulated in a separate Calculator class.
*/
public class Calculator
{
    // Add two numbers and return the result
    public static double Add(double a, double b)
    {
        return a + b;
    }

    // Subtract b from a and return the result
    public static double Subtract(double a, double b)
    {
        return a - b;
    }

    // Multiply two numbers and return the result
    public static double Multiply(double a, double b)
    {
        return a * b;
    }

    // Divide a by b; returns NaN if b is zero to prevent crash
    public static double Divide(double a, double b)
    {
        if (b == 0)
        {
            return double.NaN;
        }
        return a / b;
    }
}

public class App
{
    // Display the main menu
    public static void DisplayMenu()
    {
        Console.WriteLine("\nPlease select an operation:");
        Console.WriteLine("  1. Add");
        Console.WriteLine("  2. Subtract");
        Console.WriteLine("  3. Multiply");
        Console.WriteLine("  4. Divide");
        Console.WriteLine("  5. Quit");
        Console.Write("Enter your choice: ");
    }

    // Prompt the user for a number and return it as a double
    public static double GetNumber(string prompt)
    {
        Console.Write(prompt);
        string? val = Console.ReadLine();
        return Convert.ToDouble(val);
    }

    static void Main(string[] args)
    {
        // Print header line
        Console.WriteLine("Steven McGraw - Week 2 PA Calculator Phase 2");

        // Print welcome message
        Console.WriteLine("\nWelcome to the Steven McGraw Calculator!");
        Console.WriteLine("This program can add, subtract, multiply, and divide two numbers.");
        Console.WriteLine("Select an option from the menu to get started.");

        bool running = true;

        // Keep showing the menu until the user quits
        while (running)
        {
            DisplayMenu();
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    double a1 = GetNumber("Enter first number: ");
                    double b1 = GetNumber("Enter second number: ");
                    Console.WriteLine("Result: {0}", Calculator.Add(a1, b1));
                    break;

                case "2":
                    double a2 = GetNumber("Enter first number: ");
                    double b2 = GetNumber("Enter second number: ");
                    Console.WriteLine("Result: {0}", Calculator.Subtract(a2, b2));
                    break;

                case "3":
                    double a3 = GetNumber("Enter first number: ");
                    double b3 = GetNumber("Enter second number: ");
                    Console.WriteLine("Result: {0}", Calculator.Multiply(a3, b3));
                    break;

                case "4":
                    double a4 = GetNumber("Enter first number: ");
                    double b4 = GetNumber("Enter second number: ");
                    double result = Calculator.Divide(a4, b4);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("Error: Cannot divide by zero.");
                    }
                    else
                    {
                        Console.WriteLine("Result: {0}", result);
                    }
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid selection. Please enter a number between 1 and 5.");
                    break;
            }
        }

        // Closing message
        Console.WriteLine("\nThank you for using the Steven McGraw Calculator. Goodbye!");
    }
}
