﻿using System;
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

            ////100. Same Tree
            //TreeNode a1 = new TreeNode(1);
            //TreeNode b1 = new TreeNode(2);
            //TreeNode c1 = new TreeNode(3);
            //a1.left = b1;
            //a1.right = c1;

            //TreeNode a2 = new TreeNode(1);
            //TreeNode b2 = new TreeNode(2);
            //TreeNode c2 = new TreeNode(3);
            //a2.left = b2;
            //a2.right = c2;
            //Console.WriteLine(IsSameTree(a1, a2));

            ////104. Maximum Depth of Binary Tree
            //TreeNode a = new TreeNode(3);
            //TreeNode b = new TreeNode(9);
            //TreeNode c = new TreeNode(20);
            //TreeNode d = new TreeNode(15);
            //TreeNode e = new TreeNode(7);
            //a.left = b;
            //a.right = c;
            //c.left = d;
            //c.right = e;
            //Console.WriteLine(MaxDepth(a));

            ////329. Longest Increasing Path in a Matrix
            //List<List<int>> list = new List<List<int>>();
            //list.Add(new List<int>() { 9, 9, 4 });
            //list.Add(new List<int>() { 6, 6, 8 });
            //list.Add(new List<int>() { 2, 1, 1 });
            //Console.WriteLine(LongestIncreasingPath(list));

            //543. Diameter of Binary Tree
            TreeNode a = new TreeNode(1);
            TreeNode b = new TreeNode(2);
            TreeNode c = new TreeNode(3);
            TreeNode d = new TreeNode(4);
            TreeNode e = new TreeNode(5);
            a.left = b;
            a.right = c;
            b.left = d;
            b.right = e;
            var temp = new Program();
            Console.WriteLine(temp.DiameterOfBinaryTree(a));
        }
        int max = 0;
        public int DiameterOfBinaryTree(TreeNode root)
        {
            //543.Diameter of Binary Tree
            CheckDiameter(root);
            return max;
        }
        public int CheckDiameter(TreeNode root)
        {
            //543.Diameter of Binary Tree
            if (root == null) return 0;
            int left = CheckDiameter(root.left);
            int right = CheckDiameter(root.right);
            max = Math.Max(max, left + right + 1);
            return Math.Max(left + 1, right + 1);
        }

        public static int LongestIncreasingPath(List<List<int>> matrix)
        {
            //329. Longest Increasing Path in a Matrix
            Dictionary<string, int> dict = new Dictionary<string, int>();
            int max = 0;
            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[0].Count; j++)
                {
                    max = Math.Max(max, FindLongestIncreasingPath(0, 0, matrix, int.MinValue, dict));
                }
            }
            return max;
        }

        public static int FindLongestIncreasingPath(int x, int y, List<List<int>> matrix, int check, Dictionary<string, int> dict)
        {
            //329. Longest Increasing Path in a Matrix
            if (x >= matrix.Count || x < 0 || y >= matrix[0].Count || y < 0) return 0;
            if (check >= matrix[x][y]) return 0;
            if (dict.ContainsKey(x + "," + y)) return dict[x + "," + y];
            int max = 0;
            max = Math.Max(max, FindLongestIncreasingPath(x, y - 1, matrix, matrix[x][y], dict));
            max = Math.Max(max, FindLongestIncreasingPath(x, y + 1, matrix, matrix[x][y], dict));
            max = Math.Max(max, FindLongestIncreasingPath(x - 1, y, matrix, matrix[x][y], dict));
            max = Math.Max(max, FindLongestIncreasingPath(x + 1, y, matrix, matrix[x][y], dict));
            dict.Add(x + "," + y, max + 1);
            return dict[x + "," + y];
        }

        public static int MaxDepth(TreeNode root)
        {
            //104.Maximum Depth of Binary Tree
            if (root == null) return 0;
            return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
        }

        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            //100. Same Tree
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

