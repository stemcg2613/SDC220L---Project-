/*******************************************************************
* Name: Steven McGraw
* Date: 2026-03-29
* Assignment: SDC220 Calculator Project - Week 4 Phase 4
*
* Main application (program) class.
* This application builds on Phase 3 by adding exception handling.
* It includes all memory functionality from Phase 3 (single value
* and collection memory) plus a division operation with full
* exception handling for divide by zero and non-numeric input.
*/
using System.Collections.Generic;

public class Calculator
{
    // Single value memory
    private static double singleMemory = 0;
    private static bool singleMemorySet = false;

    // Collection memory (up to 10 integers)
    private static List<int> memoryList = new List<int>();

    // Divide two numbers; throws user-defined exception if denominator is zero
    public static double Divide(double numerator, double denominator)
    {
        if (denominator == 0)
        {
            throw new Exception(
                "Division by zero is not allowed. Please enter a non-zero value.");
        }
        return numerator / denominator;
    }

    // Store a single value in memory
    public static void StoreValue(double value)
    {
        singleMemory = value;
        singleMemorySet = true;
    }

    // Retrieve the single value from memory
    public static double RetrieveValue()
    {
        return singleMemory;
    }

    // Check if single memory has been set
    public static bool IsSingleMemorySet()
    {
        return singleMemorySet;
    }

    // Clear the single memory value
    public static void ClearSingleMemory()
    {
        singleMemory = 0;
        singleMemorySet = false;
    }

    // Replace the single memory value
    public static void ReplaceValue(double value)
    {
        singleMemory = value;
        singleMemorySet = true;
    }

    // Add a value to the collection (max 10)
    public static bool AddToCollection(int value)
    {
        if (memoryList.Count >= 10)
            return false;
        memoryList.Add(value);
        return true;
    }

    // Display all values in the collection
    public static void DisplayCollection()
    {
        if (memoryList.Count == 0)
        {
            Console.WriteLine("The collection is empty.");
            return;
        }
        Console.WriteLine("Values in collection:");
        for (int i = 0; i < memoryList.Count; i++)
            Console.WriteLine("  [{0}] {1}", i, memoryList[i]);
    }

    // Get count of values in the collection
    public static int GetCollectionCount()
    {
        return memoryList.Count;
    }

    // Remove a value from the collection by index
    public static bool RemoveFromCollection(int index)
    {
        if (index < 0 || index >= memoryList.Count)
            return false;
        memoryList.RemoveAt(index);
        return true;
    }

    // Get sum of all values in the collection
    public static int GetCollectionSum()
    {
        int total = 0;
        foreach (int val in memoryList)
            total += val;
        return total;
    }

    // Get average of all values in the collection
    public static double GetCollectionAverage()
    {
        if (memoryList.Count == 0) return 0;
        return (double)GetCollectionSum() / memoryList.Count;
    }

    // Get difference of first and last values in the collection
    public static int GetFirstLastDifference()
    {
        if (memoryList.Count < 2) return 0;
        return memoryList[0] - memoryList[memoryList.Count - 1];
    }
}

public class App
{
    // Get a double from the user; throws FormatException if not a number
    public static double GetNumber(string prompt)
    {
        Console.Write(prompt);
        string? val = Console.ReadLine();
        return Convert.ToDouble(val);
    }

    static void DisplayMainMenu()
    {
        Console.WriteLine("\nCalculator Menu:");
        Console.WriteLine("  1. Division");
        Console.WriteLine("  2. Single Value Memory");
        Console.WriteLine("  3. Collection Memory");
        Console.WriteLine("  4. Quit");
        Console.Write("Enter your choice: ");
    }

    static void DisplaySingleMemoryMenu()
    {
        Console.WriteLine("\nSingle Value Memory:");
        Console.WriteLine("  1. Store a value");
        Console.WriteLine("  2. Retrieve the value");
        Console.WriteLine("  3. Clear the value");
        Console.WriteLine("  4. Replace the value");
        Console.WriteLine("  5. Back to main menu");
        Console.Write("Enter your choice: ");
    }

    static void DisplayCollectionMenu()
    {
        Console.WriteLine("\nCollection Memory ({0}/10 values stored):", Calculator.GetCollectionCount());
        Console.WriteLine("  1. Display all values");
        Console.WriteLine("  2. Display count of values");
        Console.WriteLine("  3. Add a value");
        Console.WriteLine("  4. Remove a value by index");
        Console.WriteLine("  5. Get sum of all values");
        Console.WriteLine("  6. Get average of all values");
        Console.WriteLine("  7. Get difference of first and last values");
        Console.WriteLine("  8. Back to main menu");
        Console.Write("Enter your choice: ");
    }

    static void Main(string[] args)
    {
        // Header line
        Console.WriteLine("Steven McGraw - Week 4 Calculator Project Phase 4");

        // Welcome message
        Console.WriteLine("\nWelcome to the Steven McGraw Calculator Phase 4!");
        Console.WriteLine("This calculator includes division with exception handling");
        Console.WriteLine("and full memory functionality from Phase 3.");

        bool running = true;

        while (running)
        {
            DisplayMainMenu();
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Division with exception handling
                    bool divDone = false;
                    while (!divDone)
                    {
                        try
                        {
                            double num1 = GetNumber("Enter the numerator: ");
                            double num2 = GetNumber("Enter the denominator: ");
                            double result = Calculator.Divide(num1, num2);
                            Console.WriteLine("Result: {0} / {1} = {2:F4}", num1, num2, result);
                            divDone = true;
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("\nException: {0}", e);
                            Console.WriteLine("Invalid input. Please enter numeric values.");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("\nException: {0}", e);
                            Console.WriteLine("{0}", e.Message);
                        }
                    }
                    break;

                case "2":
                    // Single value memory submenu
                    bool inSingle = true;
                    while (inSingle)
                    {
                        DisplaySingleMemoryMenu();
                        string? sChoice = Console.ReadLine();
                        switch (sChoice)
                        {
                            case "1":
                                Console.Write("Enter a value to store: ");
                                double storeVal = Convert.ToDouble(Console.ReadLine());
                                Calculator.StoreValue(storeVal);
                                Console.WriteLine("Value {0} stored in memory.", storeVal);
                                break;
                            case "2":
                                if (!Calculator.IsSingleMemorySet())
                                    Console.WriteLine("No value stored in memory.");
                                else
                                    Console.WriteLine("Memory value: {0}", Calculator.RetrieveValue());
                                break;
                            case "3":
                                Calculator.ClearSingleMemory();
                                Console.WriteLine("Memory cleared.");
                                break;
                            case "4":
                                Console.Write("Enter a new value to replace memory: ");
                                double replaceVal = Convert.ToDouble(Console.ReadLine());
                                Calculator.ReplaceValue(replaceVal);
                                Console.WriteLine("Memory replaced with {0}.", replaceVal);
                                break;
                            case "5":
                                inSingle = false;
                                break;
                            default:
                                Console.WriteLine("Invalid selection.");
                                break;
                        }
                    }
                    break;

                case "3":
                    // Collection memory submenu
                    bool inCollection = true;
                    while (inCollection)
                    {
                        DisplayCollectionMenu();
                        string? cChoice = Console.ReadLine();
                        switch (cChoice)
                        {
                            case "1":
                                Calculator.DisplayCollection();
                                break;
                            case "2":
                                Console.WriteLine("Count of values stored: {0}", Calculator.GetCollectionCount());
                                break;
                            case "3":
                                if (Calculator.GetCollectionCount() >= 10)
                                    Console.WriteLine("Collection is full (10 values max).");
                                else
                                {
                                    Console.Write("Enter an integer value to add: ");
                                    int addVal = Convert.ToInt32(Console.ReadLine());
                                    Calculator.AddToCollection(addVal);
                                    Console.WriteLine("Value {0} added to collection.", addVal);
                                }
                                break;
                            case "4":
                                if (Calculator.GetCollectionCount() == 0)
                                    Console.WriteLine("Collection is empty.");
                                else
                                {
                                    Calculator.DisplayCollection();
                                    Console.Write("Enter the index of the value to remove: ");
                                    int removeIdx = Convert.ToInt32(Console.ReadLine());
                                    if (Calculator.RemoveFromCollection(removeIdx))
                                        Console.WriteLine("Value removed.");
                                    else
                                        Console.WriteLine("Invalid index.");
                                }
                                break;
                            case "5":
                                if (Calculator.GetCollectionCount() == 0)
                                    Console.WriteLine("Collection is empty.");
                                else
                                    Console.WriteLine("Sum of all values: {0}", Calculator.GetCollectionSum());
                                break;
                            case "6":
                                if (Calculator.GetCollectionCount() == 0)
                                    Console.WriteLine("Collection is empty.");
                                else
                                    Console.WriteLine("Average of all values: {0:F2}", Calculator.GetCollectionAverage());
                                break;
                            case "7":
                                if (Calculator.GetCollectionCount() < 2)
                                    Console.WriteLine("Need at least 2 values in the collection.");
                                else
                                    Console.WriteLine("Difference of first and last values: {0}", Calculator.GetFirstLastDifference());
                                break;
                            case "8":
                                inCollection = false;
                                break;
                            default:
                                Console.WriteLine("Invalid selection.");
                                break;
                        }
                    }
                    break;

                case "4":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid selection. Please enter 1, 2, 3, or 4.");
                    break;
            }
        }

        // Closing message
        Console.WriteLine("\nThank you for using the Steven McGraw Calculator. Goodbye!");
    }
}