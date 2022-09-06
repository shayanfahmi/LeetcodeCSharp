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

            ////543. Diameter of Binary Tree
            //TreeNode a = new TreeNode(1);
            //TreeNode b = new TreeNode(2);
            //TreeNode c = new TreeNode(3);
            //TreeNode d = new TreeNode(4);
            //TreeNode e = new TreeNode(5);
            //a.left = b;
            //a.right = c;
            //b.left = d;
            //b.right = e;
            //var temp = new Program();
            //Console.WriteLine(temp.DiameterOfBinaryTree(a));

            ////17. Letter Combinations of a Phone Number
            //var res = LetterCombinations("234");
            //foreach (var item in res) {
            //    Console.WriteLine(item);
            //}

            ////39. Combination Sum
            //int[] candidates = new int[] { 2, 3, 6, 7};
            //var res = CombinationSum(candidates, 7);
            //foreach (var items in res) {
            //    foreach (var item in items) {
            //        Console.WriteLine(item);
            //    }
            //    Console.WriteLine("___");
            //}

            //3. Longest Substring Without Repeating Characters
            Console.WriteLine(LengthOfLongestSubstring("abba"));
        }

        public static int LengthOfLongestSubstring(string s)
        {
            //3. Longest Substring Without Repeating Characters
            if (s.Length == 0) return 0;
            Dictionary<char, int> dict = new Dictionary<char, int>();
            int max = 0;
            int start = 0;
            int end = 0;
            while (end < s.Length && start < s.Length && start <= end) {
                if (dict.ContainsKey(s[end]))
                {
                    start = Math.Max(start, dict[s[end]] + 1);
                    dict[s[end]] = end;
                }
                else {
                    dict.Add(s[end], end);
                }
                max = Math.Max(max, end - start + 1);
                end++;
            }
            return max;
        }

        public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            //39. Combination Sum
            IList<IList<int>> resList = new List<IList<int>>();

            FindCombinationSum(0, candidates, target, resList, new List<int>());

            return resList;
        }

        private static void FindCombinationSum(int index, int[] candidates, int target, IList<IList<int>> resList, List<int> tempList)
        {
            //39. Combination Sum
            if (target == 0) {
                resList.Add(tempList);
                return;
            }
            if (index >= candidates.Length) return;
            if (target < 0) return;
            for (int i = 0; i * candidates[index] <= target; i++) {
                FindCombinationSum(
                    index+1,
                    candidates,
                    target - (i * candidates[index]),
                    resList,
                    CreateList(tempList, candidates[index], i));
            }
        }

        private static List<int> CreateList(List<int> tempList, int digitToAdd, int times) {
            //39. Combination Sum
            List<int> res = new List<int>();
            foreach (var item in tempList)
            {
                res.Add(item);
            }

            for (int i = 0; i < times; i++) {
                res.Add(digitToAdd);
            }

            return res;
        }

        public static IList<string> LetterCombinations(string digits)
        {
            //17. Letter Combinations of a Phone Number
            IList<string> resList = new List<string>();
            Dictionary<char, List<char>> dict = new Dictionary<char, List<char>>();
            dict.Add('2', new List<char>() { 'a', 'b', 'c'});
            dict.Add('3', new List<char>() { 'd', 'e', 'f' });
            dict.Add('4', new List<char>() { 'g', 'h', 'i' });
            dict.Add('5', new List<char>() { 'j', 'k', 'l' });
            dict.Add('6', new List<char>() { 'm', 'n', 'o' });
            dict.Add('7', new List<char>() { 'p', 'q', 'r', 's' });
            dict.Add('8', new List<char>() { 't', 'u', 'v' });
            dict.Add('9', new List<char>() { 'w', 'x', 'y', 'z' });
            FindCombinations(0, digits, resList, dict);
            return resList;
        }

        private static void FindCombinations(int curr, string digits, IList<string> resList, Dictionary<char, List<char>> dict, string final="")
        {
            //17. Letter Combinations of a Phone Number
            if (curr == digits.Length) {
                resList.Add(final);
                return;
            }
            foreach (var item in dict[digits[curr]]) {
                FindCombinations(curr+1, digits, resList, dict, final+item);
            }
            return;
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

