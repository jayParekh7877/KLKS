using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Practice.Others
{
    class MaximumSubArray
    {
        //static void Main(string[] args)
        //{
        //    // var data = maxSubArraySum(new[] {-2, 1, -3, 4, -1, 2, 1, -5, 4});
        //    //var data = LengthOfLastWord(" ");
        //    //ReverseString(new[] {'h', 'e', 'l', 'l', 'o','a'});
        //    //RunningSum(new[] {1, 2, 3, 4});
        //    MaximumWealth(new int[][]
        //    {
        //        new[] {1, 2, 3},
        //        new[] {3, 2, 1}
        //    });
        //}

        public static int MaximumWealth(int[][] accounts)
        {
            int maxsum = 0;
            int currsum = 0;
            for (int i = 0; i < accounts.Length; i++)
            {
                currsum = 0;
                for (int j = 0; j < accounts[i].Length; j++)
                {
                    currsum += accounts[i][j];
                }

                if (currsum > maxsum)
                {
                    maxsum = currsum;
                }
            }

            return maxsum;
        }

        public static int[] RunningSum(int[] nums)
        {
            var data = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                var count = 0;
                for (int j = 0; j <= i; j++)
                {
                    count += nums[j];
                }

                data[i] = count;
            }

            return data;
        }

        static int maxSubArraySum(int[] a)
        {
            int size = a.Length;
            int max_so_far = int.MinValue,
                max_ending_here = 0;

            for (int i = 0; i < size; i++)
            {
                max_ending_here = max_ending_here + a[i];

                if (max_so_far < max_ending_here)
                    max_so_far = max_ending_here;

                if (max_ending_here < 0)
                    max_ending_here = 0;
            }

            return max_so_far;
        }

        public static int LengthOfLastWord(string s)
        {
            var data = s.Split(' ');
            return data[data.Length - 1].ToCharArray().Length;
        }

        public static void ReverseString(char[] s)
        {
            for (int i = 0, j = s.Length - 1; i <= j; i++, j--)
            {
                var temp = s[i];
                s[i] = s[j];
                s[j] = temp;
            }

            var data = s;
        }
    }
}