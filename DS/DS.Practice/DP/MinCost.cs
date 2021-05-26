using System;
using System.Collections.Generic;

namespace DS.Practice.DP
{
    public class MinCost
    {
        //public static void Main(string[] args)
        //{
        //    //var data1 = new[] {10, 15, 20};
        //    var data1 = new[] {1, 100, 1, 1, 1, 100, 1, 1, 100, 1};
        //    //var temp = new int[data1.Length];
        //    //for (int j = 0; j < data1.Length; j++)
        //    //{
        //    //    temp[j] = -1;
        //    //}
        //    var temp = new Dictionary<string, int>();
        //    var data = FindMin(data1, -1, 0, data1.Length,temp);
        //}

        public static int FindMin(int[] cost, int i, int c, int n,Dictionary<string,int> temp)
        {
           
            //if ((i + 1 < n) && temp[i+1] != -1 ) return temp[i+1];
            if (i + 1 >= n || i + 2 >= n) return c;
            var key = cost[i + 1] + "," + (i + 1);
            if (temp.ContainsKey(key)) return temp[key];
            Console.WriteLine("i=>" + i + " c=>" + c + " n=>" + n);
            //temp[i+1] = Math.Min(FindMin(cost, i + 1, cost[i + 1] + c, n,temp), 
            //    FindMin(cost, i + 2, cost[i + 2] + c, n,temp));
            //return temp[i+1];
            temp.Add(key, Math.Min(FindMin(cost, i + 1, cost[i + 1] + c, n, temp),
                FindMin(cost, i + 2, cost[i + 2] + c, n, temp)));
            return temp[key];
        }
    }
}