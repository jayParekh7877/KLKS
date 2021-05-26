using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.String;

namespace DS.Practice.Others
{
    public class LongestCommonPrefix
    {
        //static void Main(string[] args)
        //{
        //   var data = Prifix(new string[] { "ab", "a" });
        //}

        private static string Prifix(string[] strs)
        {
            if (strs == null || strs.Length == 0) return "";
            for (int i = 0; i < strs[0].Length; i++)
            {
                char c = strs[0].ToCharArray()[i];
                for (int j = 1; j < strs.Length; j++)
                {
                    if (i == strs[j].Length || strs[j].ToCharArray()[i] != c)
                        return strs[0].Substring(0, i);
                }
            }
            return strs[0];
        }

        //private static string Prifix(string[] strs)
        //{
        //    int count = 0;
        //    var result = string.Empty;
        //    bool isBreak = false;
        //    var master = string.Empty;
        //    if (strs.Length == 0) return "";
        //    bool ismatch = false;

        //    while (true)
        //    {
        //        for (int i = 0; i < strs.Length; i++)
        //        {
        //            strs[0].charAt(i)
        //            var charArray = strs[i].ToCharArray();
        //            if (count >= charArray.Length) {isBreak = true ; break;}
        //            if (result == string.Empty)
        //            {
        //                result = charArray[count].ToString();
        //            }
        //            else if(result == charArray[count].ToString())
        //            {
        //                ismatch = true;
        //            }
        //            else
        //            {
        //                return master;
        //            }
        //        }
        //        if(ismatch) master = master + ""+ result;
        //        if (isBreak)
        //        {
        //            return master;
        //        }
        //        count++; result = string.Empty;
        //        ismatch = false;
        //    }

        //    return string.Empty;
        //}

        //private static string Prifix(string[] strs)
        //{
        //    int count = 0;
        //    char result = ' ';
        //    string matachString = "";
        //    bool isMataching = false;
        //    if (strs == null || strs.Length == 0) return "";


        //    for (int j = 0; j < strs.Length; j++)
        //    {
        //        for (int i = 0; i < strs.Length; i++)
        //        {
        //            var temp = strs[i].ToCharArray();
        //            if (count < temp.Length)
        //            {
        //                if (result == ' ')
        //                {
        //                    result = temp[count];
        //                }
        //                else
        //                {
        //                    if (result == temp[count])
        //                    {
        //                        isMataching = true;
        //                    }
        //                    else
        //                    {
        //                        return matachString;
        //                    }
        //                }
        //            }
        //        }

        //        if (isMataching)
        //        {
        //            matachString = (matachString + "" + result).Trim();
        //            result = ' ';
        //            count++;
        //        }
        //        else
        //        {
        //            return matachString = (matachString + "" + result).Trim(); 
        //        }
        //    }
        //     return matachString;
        //}
    }
}