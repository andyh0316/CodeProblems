using System;

namespace CodeProblems
{
    public class ArrayHelper
    {
        public static void PrintArray(int[] nums)
        {
            Console.Write("[ ");
            foreach (int num in nums)
            {
                Console.Write(num + " ");
            }
            Console.Write("]");
        }
    }
}