
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function produces an array of size 'length' starting with
    /// 'number' followed by multiples of 'number'.
    /// For example, MultiplesOf(7, 5) returns {7, 14, 21, 28, 35}.
    /// </summary>
    /// <returns>Array of doubles that are multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan:
        // Step 1: Create a new array that can store the required number of multiples.
        // Step 2: Start a loop at index 0 and continue until the array is full.
        // Step 3: At each index, multiply the starting number by the index plus 1.
        // Step 4: Store each calculated multiple at its corresponding array index.
        // Step 5: Return the completed array.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotates the 'data' list to the right by the specified 'amount'.
    /// For example, {1, 2, 3, 4, 5} rotated by 2 becomes {4, 5, 1, 2, 3}.
    /// This function modifies the existing list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan:
        // Step 1: Get the total number of elements in the list.
        // Step 2: Calculate the starting index of the last 'amount' elements.
        // Step 3: Copy those elements into a temporary list using GetRange.
        // Step 4: Remove those elements from the original list using RemoveRange.
        // Step 5: Insert the saved elements at index 0 using InsertRange.
        // Step 6: The original list is now rotated to the right by the given amount.

        int count = data.Count;

        List<int> lastElements = data.GetRange(count - amount, amount);

        data.RemoveRange(count - amount, amount);

        data.InsertRange(0, lastElements);
    }
}
