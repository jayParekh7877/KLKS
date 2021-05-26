using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Practice.Others
{
    class LicenseKeyFormatting
    {
        //public static void Main(string[] args)
        //{
        //    var data = LicenseKeyFormattingData("5F3Z-2e-9-w", 4);
        //    Console.ReadLine();
        //}

        //https://leetcode.com/problems/license-key-formatting/
        public static string LicenseKeyFormattingData(string S, int K)
        {
            S = S.ToUpper();

            var len = S.Length;
            var ans = "";
            var group = "";
            for (var i = len - 1; i >= 0; i--)
            {
                if (S[i] == '-') continue;
                group = S[i] + group;
                if (group.Length == K)
                {
                    if (ans != "") ans = group + '-' + ans;
                    else ans = group;
                    group = "";
                }
            }
            if (group != "")
            {
                if (ans != "") ans = group + '-' + ans;
                else ans = group;
            }

            return ans;
            //var c = S.ToCharArray();
            //var sb = new StringBuilder();
            //var count = 0;
            //for (int i = c.Length - 1; i >= 0; i--)
            //{
            //    if (!c[i].Equals('-'))
            //    {
            //        count++;

            //        if (IsChar(c[i]))
            //        {
            //            var data = Char.ToUpper(c[i]).ToString();
            //            sb.Append(data);
            //        }
            //        else
            //        {
            //            sb.Append(c[i]);
            //        }

            //        if (count == K)
            //        {
            //            sb.Append('-');
            //            count = 0;
            //        }
            //    }
            //}

            //return sb.ToString();
        }

        public static bool IsChar(char c)
        {
            if ((c >= 65 && c <= 90) || (c >= 97 && c <= 122)) return true;
            return false;
        }
    }
}