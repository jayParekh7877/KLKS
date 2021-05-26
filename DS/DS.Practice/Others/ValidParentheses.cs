using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Practice.Others
{
    public class ValidParentheses
    {
        //static void Main(string[] args)
        //{
        //    var data = IsValid("]");
        //}

        public static bool IsValid(string s)
        {
            var stack = new Stack<char>();
            var dictionary = new Dictionary<char, char> {{'(', ')'}, {'{', '}'}, {'[', ']'}};
            var charArray = s.ToCharArray();

            foreach (var charData in charArray)
            {
                if (dictionary.Keys.Contains(charData))
                {
                    stack.Push(charData);
                }
                else
                {
                    if (stack.Count > 0)
                    {
                        var poppedChar = stack.Pop();
                        if (charData != dictionary[poppedChar])
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return stack.Count == 0;
        }
    }
}