using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Practice
{
    public class StringManipulation
    {
        //static void Main(string[] args)
        //{
        //    var abc = "(al)G()GGGGG()GG()(al)(al)(al)()(al)()()G";
        //    var data = CalParser(abc);
        //}

        private static string CalParser(string command)
        {
            var c = command.ToCharArray();
            var sb = new StringBuilder();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 'G')
                    sb.Append("G");
                else if (c[i] == '(')
                {
                    if (c[i + 1] == ')')
                    {
                        sb.Append("o");
                        i++;
                    }

                    else if (c[i + 1] == 'a')
                    {
                        sb.Append("al");
                        i += 3;
                    }
                }
            }

            return sb.ToString();
        }
    }
}