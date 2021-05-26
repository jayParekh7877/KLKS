using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Practice.Others
{
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

    public class MergeTwoListData
    {
        //static void Main(string[] args)
        //{
        //    //var l1 = new ListNode(1);
        //    //var l3 = new ListNode(5);
        //    //var l4 = new ListNode(4);
        //    //l1.next = l3;
        //    //l3.next = l4;

        //    //var l2 = new ListNode(1);
        //    //var d3 = new ListNode(2);
        //    //var d4 = new ListNode(4);
        //    //var d5 = new ListNode(6);
        //    //var d6 = new ListNode(3);
        //    //l2.next = d3;
        //    //d3.next = d4;
        //    //d4.next = d5;
        //    //d5.next = d6;

            

        //    ListNode l2 = null;
        //    ListNode l1 = new ListNode(1);
        //    var data = MergeTwoLists(l1, l2);


        //}

        private static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode head = new ListNode();
            ListNode tail = head;
            if (l1 == null && l2 == null) return null;
            if (l1 == null && l2 != null)
            {
                var temp = head;
                head = NewMethod1(temp.next, l2, head);
                return head;
            }
            else if (l1 != null && l2 == null)
            {
                var temp = head;
                return NewMethod2(l1, temp.next, head);
            }
            else
            {
                head = NewMethod(l1, l2, head);
            }

            while (tail.next.next != null)
            {
                tail = tail.next;
            }

            tail.next = null;

            return head;
        }

        private static ListNode NewMethod(ListNode l1, ListNode l2, ListNode head)
        {
            while (l1 != null && l2 != null)
            {
                if (l1.val > l2.val)
                {
                    head = Insert(head, l2.val);
                    if (l2 != null) l2 = l2.next;
                }
                else
                {
                    head = Insert(head, l1.val);
                    if (l1 != null) l1 = l1.next;
                }
            }

            if (l1 == null && l2 != null)
            {
                var temp = head;
                head = NewMethod1(temp.next, l2, head);
                return head;
            }
            else
            {
                var temp = head;
                return NewMethod2(l1, temp.next, head);
            }

            return head;
        }

        private static ListNode NewMethod2(ListNode l1, ListNode tempNext, ListNode head)
        {
            while (l1 != null)
            {
                if (tempNext != null || tempNext.next != null || tempNext.val > l1.val)
                {
                    head = Insert(head, l1.val);
                    l1 = l1.next;
                }
                tempNext = tempNext.next;

            }

            return head;
        }

        private static ListNode NewMethod1(ListNode tempNext, ListNode l2, ListNode head)
        {
            while (l2 != null)
            {
                if (tempNext.next == null ||tempNext.val > l2.val)
                {
                    head = Insert(head, l2.val);
                    l2 = l2.next;
                }

                tempNext = tempNext.next;

            }

            return head;
        }

        private static ListNode Insert(ListNode head, int val)
        {
            var tail = head;
            while (tail.next != null && tail.val < val)
            {
                tail = tail.next;
            }

            var node = new ListNode(val) {next = tail.next};
            tail.next = node;

            var temp = node.val;
            node.val = tail.val;
            tail.val = temp;

            return head;
        }


        //private static ListNode MergeTwoLists(ListNode l10, ListNode l12)
        //{
        //    ListNode l1 = l10;
        //    ListNode l2 = l12;
        //    ListNode head = new ListNode();
        //    ListNode tail = head;
        //    return ListNode(l1, l2, tail, head);
        //}

        //private static ListNode ListNode(ListNode l1, ListNode l2, ListNode tail, ListNode head)
        //{
        //    if (l1 == null && l2 == null) return null;
        //    if (l1 == null && l2 != null)
        //    {
        //        tail.next = l2;
        //    }
        //    else if (l1 != null && l2 == null)
        //    {
        //        tail.next = l1;
        //    }
        //    else
        //    {
        //        while (l1 != null && l2 != null)
        //        {
        //            if (l1.val > l2.val)
        //            {
        //                var node = new ListNode(l2.val);
        //                node.next = new ListNode(l1.val);
        //                tail.next = node;
        //            }
        //            else
        //            {
        //                var node = new ListNode(l1.val);
        //                node.next = new ListNode(l2.val);
        //                tail.next = node;
        //            }

        //            if (l1 != null) l1 = l1.next;
        //            if (l2 != null) l2 = l2.next;
        //            tail = tail.next.next;
        //        }

        //        if (l1 == null && l2 != null)
        //        {
        //            var temp = head;
        //           return ListNode(temp.next, l2,tail,head);
        //        }
        //        else
        //        {
        //            var temp = head;
        //            return ListNode(l1, temp.next, tail,head);
        //        }
        //    }

        //    return head.next;
        //}

        //public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        //{
        //    ListNode l3 = null;
        //    while (l1.next != null || l2.next != null)
        //    {
        //        if (l1.val > l2.val)
        //        {
        //            var temp = l3;
        //            l3 = ListNode(l1, l2, temp);
        //        }
        //        else
        //        {
        //            var temp = l3;
        //            l3 = ListNode(l2, l1, temp);
        //        }

        //        l1 = l1.next;
        //        l2 = l2.next;
        //    }

        //    return l3;
        //}

        //private static ListNode ListNode(ListNode l1, ListNode l2, ListNode l3)
        //{
        //    var temp = l3;
        //    if (temp != null)
        //    {
        //        while (temp != null)
        //        {
        //            temp = temp.next;
        //        }
        //    }

        //    var listnode = new ListNode(l2.val);
        //    var listnode1 = new ListNode(l1.val);
        //    listnode.next = listnode1;
        //    if (temp == null)
        //    {
        //        temp = listnode;
        //    }
        //    else
        //    {
        //        temp.next = listnode;
        //    }

        //    return temp;
        //}
    }
}