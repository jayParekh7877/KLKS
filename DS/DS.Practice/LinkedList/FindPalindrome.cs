//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DS.Practice.LinkedList
//{
//    public class FindPalindrome
//    {
//        public static void main(String args[])
//        {
//            Scanner sc = new Scanner(System.in);
//            int t = sc.nextInt();

//            while (t > 0)
//            {
//                int n = sc.nextInt();
//                //int k = sc.nextInt();
//                Is_LinkedList_Palindrom llist = new Is_LinkedList_Palindrom();
//                //int n=Integer.parseInt(br.readLine());
//                int a1 = sc.nextInt();
//                Node head = new Node(a1);
//                Node tail = head;
//                for (int i = 1; i < n; i++)
//                {
//                    int a = sc.nextInt();
//                    tail.next = new Node(a);
//                    tail = tail.next;
//                }

//                Palindrome g = new Palindrome();
//                if (g.isPalindrome(head) == true)
//                    System.out.println(1);

//                else
//                System.out.println(0);
//                t--;
//            }

//        }
//    }

//    public class Node
//    {
//        int data;
//        Node next;

//        Node(int d)
//        {
//            data = d;
//            next = null;
//        }
//    }

//    public class Is_LinkedList_Palindrom
//    {
//        Node head;
//        Node tail;

//        /* Function to print linked list */
//        void printList(Node head)
//        {
//            Node temp = head;
//            while (temp != null)
//            {
//                System.out.print(temp.data + " ");
//                temp = temp.next;
//            }
//            System.out.println();
//        }


//        /* Inserts a new Node at front of the list. */
//        public void addToTheLast(Node node)
//        {

//            if (head == null)
//            {
//                head = node;
//                tail = node;
//            }
//            else
//            {
//                tail.next = node;
//                tail = node;
//            }
//        }
//    }



//    // } Driver Code Ends


//    /* Structure of class Node is
//    class Node
//    {
//        int data;
//        Node next;

//        Node(int d)
//        {
//            data = d;
//            next = null;
//        }
//    }*/

//    class Palindrome
//    {
//        // Function to check if linked list is palindrome
//        bool isPalindrome(Node head)
//        {
//            //Your code here
//            Node temp = head;
//            int count = 1;
//            while (temp.next != null)
//            {
//                count++;
//            }
//            int middleCount = count / 2;

//            temp = head;
//            Node middle = head;
//            int tempMiddleCount = middleCount;
//            while (tempMiddleCount != 0)
//            {
//                middle = middle.next;
//            }

//            Node tempMiddle = middle;


//            for (int i = 1; i <= middleCount; i++)
//            {
//                int tempCount = middleCount - i;
//                while (tempCount != 0)
//                {
//                    tempMiddle = tempMiddle.next;
//                }
//                if (temp != tempMiddle)
//                { return false; }
//                temp = temp.next;
//                tempMiddle = middle;
//            }
//            return true;
//        }
//    }





//}