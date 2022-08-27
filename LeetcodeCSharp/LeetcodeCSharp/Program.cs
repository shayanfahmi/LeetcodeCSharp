using System;
using System.Collections.Generic;

namespace LeetcodeCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            ////300. Longest Increasing Subsequence
            //int[] temp = new int[] { 10, 9, 2, 5, 3, 7, 101, 18 };
            //Console.WriteLine(LengthOfLIS(temp));

            //53.Maximum Subarray
            int[] nums = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            Console.WriteLine(MaxSubArray(nums));
        }

        public static int MaxSubArray(int[] nums)
        {
            //53.Maximum Subarray
            int maxSum = nums[0];
            int sum = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                sum = Math.Max(nums[i], sum + nums[i]);
                maxSum = Math.Max(sum, maxSum);
            }
            return maxSum;
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

