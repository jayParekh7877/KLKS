using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Practice
{
    public class Mutations
    {
        //static void Main(string[] args)
        //{
        //    //var data = MinMutation("AACCGGTT", "AAACGGTA", new[] {"AACCGGTA", "AACCGCTA", "AAACGGTA"});

        //    //var temp = MinutationData("AACCGGTT", "AAACGGTA");

        //    //var data = SplitArraySameAverage(new[] {1, 2, 3, 4, 5, 6, 7});

        //    //var data = pattern("^coal", "coaltar");
        //    String str = "Geeks";
        //    Console.Write("Length is: " + longestPalSubstr(str));

        //}

        static void printSubStr(String str, int low, int high)
        {
            for (int i = low; i <= high; ++i)
                Console.Write(str[i]);
        }

        // This function prints the
        // longest palindrome subString
        // It also returns the length
        // of the longest palindrome
        static int longestPalSubstr(String str)
        {
            // get length of input String
            int n = str.Length;

            // All subStrings of length 1
            // are palindromes
            int maxLength = 1, start = 0;

            // Nested loop to mark start and end index
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = i; j < str.Length; j++)
                {
                    int flag = 1;

                    // Check palindrome
                    for (int k = 0; k < (j - i + 1) / 2; k++)
                        if (str[i + k] != str[j - k])
                            flag = 0;

                    // Palindrome
                    if (flag != 0 && (j - i + 1) > maxLength)
                    {
                        start = i;
                        maxLength = j - i + 1;
                    }
                }
            }

            Console.Write("longest palindrome subString is: ");
            printSubStr(str, start, start + maxLength - 1);

            // return length of LPS
            return maxLength;
        }

        private static int pattern(string p, string s)
        {
            if (p.StartsWith("^"))
            {

            }
            else if(p.EndsWith("$"))
            {
                
            }
            else
            {
                if (s.Contains(p))
                    return 1;
            }
            return 0;
        }

        private static int MinutationData(string start, string end)
        {
            var count = 0;
            var startCharArray = start.ToCharArray();
            var endCharArray = end.ToCharArray();

            for (int i = 0; i < start.Length; i++)
            {
                if (startCharArray[i] != endCharArray[i])
                {
                    count++;
                }
            }

            return count;
        }

        public static int MinMutation(string start, string end, string[] bank)
        {
            const string GeneBase = "ACGT";
            HashSet<string> bankSet = new HashSet<string>(bank);
            Queue<string> genes = new Queue<string>();
            genes.Enqueue(start);
            bankSet.Remove(start);
            int level = 0;

            while (genes.Count > 0)
            {
                int count = genes.Count;
                for (int i = 0; i < count; i++)
                {
                    var current = genes.Dequeue();
                    if (current.Equals(end, StringComparison.Ordinal))
                    {
                        return level;
                    }

                    foreach (char g in GeneBase)
                    {
                        var currentGenes = current.ToCharArray();
                        for (int j = 0; j < currentGenes.Length; j++)
                        {
                            char t = currentGenes[j];
                            currentGenes[j] = g;

                            string next = new string(currentGenes);
                            if (bankSet.Contains(next))
                            {
                                bankSet.Remove(next);
                                genes.Enqueue(next);
                            }

                            currentGenes[j] = t;
                        }
                    }
                }

                level++;
            }

            return -1;
        }

        private static bool Helper(int[] nums, int startIdx, int sum1, int count1, int allSum, bool[,] visited)
        {
            checked
            {
                if (startIdx >= nums.Length)
                {
                    return false;
                }

                if (visited[count1, sum1])
                {
                    return false;
                }

                int count2 = nums.Length - count1;
                int sum2 = allSum - sum1;

                if (count2 != 0 && sum1 * count2 == sum2 * count1)
                {
                    return true;
                }

                for (int i = startIdx; i < nums.Length; i++)
                {
                    if (Helper(nums, i + 1, sum1 - nums[i], count1 - 1, allSum, visited))
                    {
                        return true;
                    }
                }

                visited[count1, sum1] = true;
                return false;
            }
        }


        public static bool SplitArraySameAverage(int[] nums)
        {
            if (nums.Length == 1)
            {
                return false;
            }

            int allSum = nums.Sum();
            bool[,] visited = new bool[nums.Length + 1, allSum + 1];
            return Helper(nums, 0, allSum, nums.Length, allSum, visited);
        }
    }
}