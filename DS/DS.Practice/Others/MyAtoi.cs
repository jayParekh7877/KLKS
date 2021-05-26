using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Practice.Others
{
    public class MyAtoi
    {
        //static void Main(string[] args)
        //{
        //    MyAtoidata("words and 987");
        //}

        public static int MyAtoidata(string s)
        {
            var charArray = s.ToCharArray();
            var tempString = "";
            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i] == ' ' || charArray[i] == '.')
                {
                   
                }
                else if (charArray[i] == '-')
                {
                    tempString = tempString + charArray[i];
                }
                else
                {
                    string abc = charArray[i].ToString();
                    var value = Encoding.ASCII.GetBytes(abc);
                    if (value[0] > 57) break;
                    else
                    {
                        tempString = tempString + charArray[i];
                    }
                }
            }

            if (tempString == "") return 0;
            var data = Convert.ToInt32(tempString);
            if (data > Int32.MaxValue / 10)
            {
                return Int32.MaxValue;
            }
            else if (data < Int32.MinValue / 10)
            {
                return Int32.MinValue;
            }
            else
            {
                return data;
            }
        }
    }
}