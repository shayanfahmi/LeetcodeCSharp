using System;
using System.Collections.Generic;

namespace LeetcodeCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //300. Longest Increasing Subsequence
            int[] temp = new int[] { 10, 9, 2, 5, 3, 7, 101, 18 };
            Console.WriteLine(LengthOfLIS(temp));
        }

        public static int LengthOfLIS(int[] nums)
        {
            //300. Longest Increasing Subsequence
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int max = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                max = Math.Max(max, LengthOfLISRecursion(i, nums, dict));
            }
            return max;
        }

        public static int LengthOfLISRecursion(int i, int[] nums, Dictionary<int, int> dict)
        {
            //300. Longest Increasing Subsequence
            if (i >= nums.Length) return 0;
            if (dict.ContainsKey(i)) return dict[i];
            int max = 0;
            for (int c = i + 1; c < nums.Length; c++)
            {
                if (nums[c] > nums[i])
                {
                    max = Math.Max(max, LengthOfLISRecursion(c, nums, dict));
                }
            }
            dict.Add(i, max + 1);
            return dict[i];
        }
    }
}

