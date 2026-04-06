/*******************************************************************
* Name: Steven McGraw
* Date: 2026-04-05
* Assignment: SDC220 Calculator Project - Final Phase
*
* Memory class.
* This class manages the calculator's memory functionality. It supports
* storing a single value in memory as well as a collection of up to
* 10 integer values. Operations include store, retrieve, clear, replace
* for single memory, and add, remove, display, count, sum, average,
* and first/last difference for the collection.
*/
using System.Collections.Generic;

public class Memory
{
    // Single value memory
    private double singleMemory = 0;
    private bool singleMemorySet = false;

    // Collection memory (up to 10 integers)
    private List<int> memoryList = new List<int>();

    // Store a single value
    public void StoreValue(double value)
    {
        singleMemory = value;
        singleMemorySet = true;
    }

    // Retrieve the single value
    public double RetrieveValue() { return singleMemory; }

    // Check if single memory has been set
    public bool IsSingleMemorySet() { return singleMemorySet; }

    // Clear the single memory
    public void ClearSingleMemory()
    {
        singleMemory = 0;
        singleMemorySet = false;
    }

    // Replace the single memory value
    public void ReplaceValue(double value)
    {
        singleMemory = value;
        singleMemorySet = true;
    }

    // Add a value to the collection (max 10)
    public bool AddToCollection(int value)
    {
        if (memoryList.Count >= 10) return false;
        memoryList.Add(value);
        return true;
    }

    // Display all values in the collection
    public void DisplayCollection()
    {
        if (memoryList.Count == 0)
        {
            Console.WriteLine("  The collection is empty.");
            return;
        }
        for (int i = 0; i < memoryList.Count; i++)
            Console.WriteLine("  [{0}] {1}", i, memoryList[i]);
    }

    // Get count of values
    public int GetCollectionCount() { return memoryList.Count; }

    // Remove a value by index
    public bool RemoveFromCollection(int index)
    {
        if (index < 0 || index >= memoryList.Count) return false;
        memoryList.RemoveAt(index);
        return true;
    }

    // Get sum of collection
    public int GetCollectionSum()
    {
        int total = 0;
        foreach (int val in memoryList) total += val;
        return total;
    }

    // Get average of collection
    public double GetCollectionAverage()
    {
        if (memoryList.Count == 0) return 0;
        return (double)GetCollectionSum() / memoryList.Count;
    }

    // Get difference of first and last values
    public int GetFirstLastDifference()
    {
        if (memoryList.Count < 2) return 0;
        return memoryList[0] - memoryList[memoryList.Count - 1];
    }
}
