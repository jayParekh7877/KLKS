using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Practice.Others
{
    public class MajorityElement
    {
        //public static void Main(string[] args)
        //{
        //    var data = majorityElement(new[] {7,7,5,7,5,1,5,7,5,5,7,7,5,5,5,5,2,8,4,7,3,6,7});
        //}

        public static int majorityElement(int[] nums)
        {
            int count = 0;
            int candidate = 0;

            foreach (int num in nums)
            {
                if (count == 0)
                {
                    candidate = num;
                }
                count += (num == candidate) ? 1 : -1;
            }
            return candidate;
        }
    }

    


}