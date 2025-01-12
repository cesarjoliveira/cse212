using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        //Solving problem steps: 
        // 1 - create an accumulator to save the results of the incrementation that will happen in the looping to create the list with the size in lenght. this accumulator should be out of the loop and initiated in 0, receiving number and adding it to the list in every loop, in the end of the loop we should add number to this accumulator. 
        // 2 - we have mutiples ways to stop the loop but we will use the lenght to find the final number of the loops that will be running and use a counter to make sure it will not pass this number.

        int counter = 0;
        double results = 0;
        List<double> multiples = new List<double>();
        while (counter < length)
        {
            results = results + number;
            multiples.Add(results);
            counter = counter + 1;
        }

        return multiples.ToArray(); // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        // 1 - Split and Rearrange: Divide the list into two parts: the last amount elements (tail) and the rest (head), then rearrange as tail + head.
        // 2 - Optimize Rotations: Use % to reduce amount when it's larger than the list size, avoiding unnecessary rotations.
        // 3 - Rebuild List: Clear the original list and use AddRange to rebuild it with the new order.
        int count = data.Count;
        amount = amount % count;


        List<int> tail = data.GetRange(count - amount, amount);
        List<int> head = data.GetRange(0, count - amount);

        data.Clear();
        data.AddRange(tail);
        data.AddRange(head);
    }
}
