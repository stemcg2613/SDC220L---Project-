/*******************************************************************
* Name: Steven McGraw
* Date: 2026-04-05
* Assignment: SDC220 Calculator Project - Final Phase
*
* Calculator class.
* This class encapsulates all arithmetic operations for the calculator.
* It supports add, subtract, multiply, and divide on a list of numbers,
* handles division by zero with a user-defined exception, and shows
* results to at least two decimal places.
*/
using System.Collections.Generic;

public class Calculator
{
    // Add all numbers in the list
    public static double Add(List<double> numbers)
    {
        double total = 0;
        foreach (double n in numbers)
            total += n;
        return total;
    }

    // Subtract all subsequent numbers from the first
    public static double Subtract(List<double> numbers)
    {
        double result = numbers[0];
        for (int i = 1; i < numbers.Count; i++)
            result -= numbers[i];
        return result;
    }

    // Multiply all numbers in the list
    public static double Multiply(List<double> numbers)
    {
        double result = numbers[0];
        for (int i = 1; i < numbers.Count; i++)
            result *= numbers[i];
        return result;
    }

    // Divide the first number by each subsequent number
    // Throws user-defined exception if any divisor is zero
    public static double Divide(List<double> numbers)
    {
        double result = numbers[0];
        for (int i = 1; i < numbers.Count; i++)
        {
            if (numbers[i] == 0)
                throw new Exception(
                    "Division by zero is not allowed. Please enter a non-zero divisor.");
            result /= numbers[i];
        }
        return result;
    }
}
