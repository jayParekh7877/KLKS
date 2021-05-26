using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DS.Practice.Others
{
    public class SubString
    {
        //static void Main(string[] args)
        //{
        //    LengthOfLongestSubstring(" ");
        //}

        public static int LengthOfLongestSubstring(string s)
        {
            var substring = "";
            var chara = s.ToCharArray();
            var maxsub = "";
            for (int i = 0; i < chara.Length; i++)
            {
                substring = substring + "" + chara[i];
                var substringchar = substring.ToCharArray();
                for (int j = 0; j < substringchar.Length; j++)
                {
                    if (i + 1 < chara.Length)
                    {
                        if (substringchar[j] == chara[i + 1])
                        {
                            if (maxsub.Length < substring.Length)
                            {
                                maxsub = substring;
                            }
                            substring = "";

                        }
                    }
                    
                }
            }

            return maxsub.Length;
        }
    }
}
