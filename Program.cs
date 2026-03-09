/*******************************************************************
* Name: Steven McGraw
* Date: 3/8/2026
* Assignment: Week 1 Calculator Project
*
* This program performs basic integer and floating point operations
* and demonstrates console input and output.
*******************************************************************/

using System;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Steven McGraw - Week 1 Calculator Project\n");

        Console.WriteLine("Welcome to the basic console calculator.");
        Console.WriteLine("Follow the prompts to perform calculations.\n");

        // Integer operation
        Console.Write("Enter the first integer value: ");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the second integer value: ");
        int num2 = Convert.ToInt32(Console.ReadLine());

        int sum = num1 + num2;

        Console.WriteLine($"\n{num1} + {num2} = {sum}\n");

        // Floating point operation
        Console.Write("Enter the first floating point value: ");
        double f1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the second floating point value: ");
        double f2 = Convert.ToDouble(Console.ReadLine());

        double result = f2 - f1;

        Console.WriteLine($"\n{f2:F4} - {f1:F4} = {result:F4}\n");

        Console.WriteLine("Thank you for using the calculator.");
    }
}
