using System;
using System.Collections.Generic;

namespace LeetcodeCSharp
{
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ////300. Longest Increasing Subsequence
            //int[] temp = new int[] { 10, 9, 2, 5, 3, 7, 101, 18 };
            //Console.WriteLine(LengthOfLIS(temp));

            ////53.Maximum Subarray
            //int[] nums = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            //Console.WriteLine(MaxSubArray(nums));

            //Same Tree
            TreeNode a1 = new TreeNode(1);
            TreeNode b1 = new TreeNode(2);
            TreeNode c1 = new TreeNode(3);
            a1.left = b1;
            a1.right = c1;

            TreeNode a2 = new TreeNode(1);
            TreeNode b2 = new TreeNode(2);
            TreeNode c2 = new TreeNode(3);
            a2.left = b2;
            a2.right = c2;
            Console.WriteLine(IsSameTree(a1, a2));
        }

        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if (p == null || q == null) return false;
            if (p.val != q.val) return false;
            if (IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right)) {
                return true;
            }
            return false;
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

