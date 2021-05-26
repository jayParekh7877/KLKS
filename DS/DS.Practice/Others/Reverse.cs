using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Practice.Others
{
    public class Reverse
    {
        //static void Main(string[] args)
        //{
        //   // var y = Convert.ToInt32(Console.ReadLine());
        //    var abc = ReverseNumber(1534236469);
        //    Console.ReadLine();
        //}

        public static int ReverseNumber(int x)
        {
            var data = 0;

            while (x != 0)
            {
                var mode = x % 10;
                x = x / 10;
                data = data * 10 + mode;
                if ((data < int.MinValue) || (data > int.MaxValue))
                {
                    return 0;
                }
            }
            return data;
        }
    }
}