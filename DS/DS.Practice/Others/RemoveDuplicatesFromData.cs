using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Practice.Others
{
    public class RemoveDuplicatesFromData
    {
        //static void Main(string[] args)
        //{
        //   // removeElement(new[] {3, 2, 2, 3}, 3);
        //    //var data = StrStr("hello", "ll");

        //}

        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }

            return i + 1;
        }

        public static int removeElement(int[] nums, int val)
        {
            int i = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != val)
                {
                    nums[i] = nums[j];
                    i++;
                }
            }

            return i;
        }

        public static int StrStr(string haystack, string needle)
        {
            var hellochar = haystack.ToCharArray();
            var needlechar = needle.ToCharArray();
            var isMatch = false;
            if (hellochar.Length == 0 && needle.Length == 0) return 0;
            if (hellochar.Length == 0) return -1;
            if (needle.Length == 0) return 0;
            if (hellochar.Length < needlechar.Length) return -1;

            for (int i = 0; i < hellochar.Length; i++)
            {
                if (hellochar[i] == needle[0])
                {
                    var count = i;
                    for (int j = i, k = 0; k < needle.Length && j < hellochar.Length; j++, k++)
                    {
                        if (hellochar[j] == needle[k])
                        {
                           
                        }
                        else
                        {
                            i = i + needle.Length -1;
                            isMatch = false;
                            break;
                        }

                        if (k == needle.Length -1) isMatch = true;
                    }
                    if (isMatch) return count;
                }
            }
            return -1;
        }
    }
}