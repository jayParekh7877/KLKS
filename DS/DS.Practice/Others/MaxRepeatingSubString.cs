using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Practice.Others
{
    public class MaxRepeatingSubString
    {
        //public static void Main(string[] args)
        //{
        //    var data = MaxRepeating("aaabaaaabaaabaaaabaaaabaaaabaaaaba", "aaaba");

        //    //"aaabaaaabaaabaaaabaaaabaaaabaaaaba"
        //    //"aaaba"
        //}

        public static int MaxRepeating(string sequence, string word)
        {
            if (sequence.Length <= 0 || word.Length <= 0 || word.Length > sequence.Length) return 0;

            var charArrayString = sequence.ToCharArray();
            var charArray = word.ToCharArray();

            int count = 0;
            int number = charArray.Length;
            for (int i = 0; i < charArrayString.Length; i++)
            {
                var current = i;
                foreach (var t in charArray)
                {
                    if (charArrayString[current] == t)
                    {
                        number--;
                    }
                    else
                    {
                        break;
                    }

                    current++;
                }

                if (number == 0)
                {
                    count++;
                    i = i + charArray.Length - 1;
                }

                number = charArray.Length;
            }

            return count;
        }
    }
}