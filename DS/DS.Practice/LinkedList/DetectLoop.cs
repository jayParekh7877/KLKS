using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Practice.LinkedList
{
    public class DetectLoop
    {
        //static void Main(string[] args)
        //{
        //    Node head = null;
        //    head = Push(10, head);
        //    head = Push(20, head);
        //    head = Push(30, head);
        //    head = Push(40, head);

        //    DisplayNode(head);
        //    Console.WriteLine(DetectLoopData(head) ? "loop found" : "No loop found");
        //    Console.ReadLine();
        //}

        public static Node Push(int data, Node head)
        {
            if (head == null) head = new Node(data);
            var temp = head;
            while (temp.Next != null) temp = temp.Next;
            temp.Next = new Node(data);
            return head;
        }

        public static void DisplayNode(Node head)
        {
            if (head == null) Console.WriteLine("No Data to be display");
            var temp = head;
            while (temp != null)
            {
                Console.WriteLine("Data :=>" + temp.Data);
                temp = temp.Next;
            }
        }

        public static bool DetectLoopData(Node head)
        {
            Node first = head;
            Node second = head;
            while (first != null)
            {
                first = first.Next;

                if (first != null)
                {
                    first = first.Next;
                    second = second.Next;
                }

                if (first == second)
                {
                    return true;
                }
            }

            return false;
        }

        public static Node NewNode(int data)
        {
            var temp = new Node(data) {Data = data, Next = null};
            return temp;
        }

        public static void makeLoop(Node head, int x)
        {
            if (x == 0)
                return;
            Node curr = head;
            Node last = head;

            int currentPosition = 1;
            while (currentPosition < x)
            {
                curr = curr.Next;
                currentPosition++;
            }

            while (last.Next != null)
                last = last.Next;
            last.Next = curr;
        }

        public static bool detectLoop(Node head)
        {
            Node hare = head.Next;
            Node tortoise = head;
            while (hare != tortoise)
            {
                if (hare?.Next == null) return false;
                hare = hare.Next.Next;
                tortoise = tortoise.Next;
            }

            return true;
        }

        public static int length(Node head)
        {
            int ret = 0;
            while (head != null)
            {
                ret += 1;
                head = head.Next;
            }

            return ret;
        }

        //public static void Main(String[] args)
        //{
        //    //Scanner sc = new Scanner(System.in);
        //    int t =Convert.ToInt32(Console.ReadLine());

        //    while (t-- > 0)
        //    {
        //        int n = Convert.ToInt32(Console.ReadLine());

        //        int num = Convert.ToInt32(Console.ReadLine());
        //        Node head = NewNode(num);
        //        Node tail = head;

        //        for (int i = 0; i < n - 1; i++)
        //        {
        //            num = Convert.ToInt32(Console.ReadLine());
        //            tail.Next = NewNode(num);
        //            tail = tail.Next;
        //        }

        //        int pos = Convert.ToInt32(Console.ReadLine());
                
        //        makeLoop(head, pos);

        //        solver x = new solver();
        //        x.removeLoop(head);

        //        if (detectLoop(head) || length(head) != n)
        //            Console.WriteLine("0");
        //        else
        //            Console.WriteLine("1");

        //        Console.ReadLine();
        //    }
        //}

    }

    public class Node
    {
        public int Data;
        public Node Next;

        public Node(int data)
        {
            Data = data;
            Next = null;
        }


    }

   public class solver
    {
        public int removeLoop(Node head)
        {
            // code here
            // remove the loop without losing any nodes
            Node fast = head;
            Node slow = head;
            while (slow.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;

                if (fast == slow)
                {
                    Node h1 = head;
                    Node h2 = fast;

                    while (true)
                    {
                        h2 = fast;
                        while (h2.Next != h2 && h2.Next != h1)
                        {
                            h2 = h2.Next;
                        }
                        if (h2.Next == h1) break;
                        h1 = h1.Next;
                    }
                    h2.Next = null;
                    return 1;
                }
            }
            return 0;
        }

        public static bool IsLoopAvailable(Node head)
        {
            Node fast = head;
            Node slow = head;
            while (slow.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;

                if (fast == slow)
                {
                    return true;
                }
            }

            return false;
        }
    }
}