using System;

namespace DS.Practice.Others
{
    public class CountAndTell
    {
        //static void Main(string[] args)
        //{
        //    // removeElement(new[] {3, 2, 2, 3}, 3);
        //    //var data = StrStr("hello", "ll");
        //    //var data = CountAndSay(2);
        //    var l1 = new ListNode(1);
        //    var l2 = new ListNode(0);
        //    var l3 = new ListNode(1);
        //    l1.next = l2;
        //    l2.next = l3;

        //    var data = GetDecimalValue(l1);
        //}

        public static string CountAndSay(int n)
        {
            var count = 1;
            var result = string.Empty;
            while (n >= count)
            {
                result = result + " " + CountNumber(result);
                count++;
            }

            return result;
        }

        private static string CountNumber(string n)
        {
            if (n == string.Empty) n = "1";
            var c = n.ToCharArray();
            if (c.Length >= 2)
            {
                for (int i = 0; i < c.Length; i++)
                {

                }
            }
            else
            {
                return "1";
            }

            return string.Empty;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public static int GetDecimalValue(ListNode head)
        {
            //From the list get the number in string 
            var curr = head;
            string binaryNumber = string.Empty;
            while (curr != null)
            {
                binaryNumber = binaryNumber + "" + curr.val;
                curr = curr.next;
            }

            //convert string to int
            var intNumber = Convert.ToInt32(binaryNumber);
            //convert int number to decimal number
            int decimalValue = 0;
            int base1 = 1;
            while (intNumber > 0)
            {
                var rem = intNumber % 10;
                intNumber = intNumber / 10;
                decimalValue += rem * base1;
                base1 = base1 * 2;
            }

            //return decimal number
            return decimalValue;
        }
    }
}