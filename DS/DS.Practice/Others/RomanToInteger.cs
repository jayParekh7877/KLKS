using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Practice.Others
{
    public class RomanToInteger
    {
        //static void Main(string[] args)
        //{
        //    RomanToInt("III");
        //}

        public static int RomanToInt(string s)
        {
            var charArrayData = s.ToCharArray();
            var dictionaryOfData = new Dictionary<char, int>
            {
                {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50}, {'C', 100}, {'D', 500}, {'M', 1000}
            };
            var spl = new Dictionary<string, int>
            {
                {"IV", 4}, {"IX", 9}, {"XL", 40}, {"XC", 90}, {"CD", 400}, {"CM", 900}
            };

            var count = 0;
            for (int i = 0; i < charArrayData.Length; i++)
            {
                if (i + 1 < charArrayData.Length)
                {
                    string data = charArrayData[i] + "" + charArrayData[i + 1];
                    if (spl.ContainsKey(data))
                    {
                        int xyz;
                        if (spl.TryGetValue(data, out xyz))
                        {
                            count = count + xyz;
                        }

                        i++;
                    }
                    else
                    {
                        int abc;
                        if (dictionaryOfData.TryGetValue(charArrayData[i], out abc))
                        {
                            count = count + abc;
                        }
                    }
                }
                else
                {
                    int abc;
                    if (dictionaryOfData.TryGetValue(charArrayData[i], out abc))
                    {
                        count = count + abc;
                    }
                }
            }

            return count;
        }
    }
}