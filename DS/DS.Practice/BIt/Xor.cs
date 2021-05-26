using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Practice.BIt
{
    public class Xor
    {
        //static void Main(string[] args)
        //{
        //    int[] ar = new[]
        //    {
        //        2, 3, 5, 2, 2
        //    };
        //    var data = getOddOcurrance(ar);

        //}

        private static int getOddOcurrance(int[] ar)
        {
            int res = 0;
            foreach (var t in ar)
            {
                res = res ^ t;
            }

            return res;
        }
    }
}