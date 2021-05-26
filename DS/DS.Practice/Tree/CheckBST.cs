using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Practice.Tree
{
    public class CheckBst
    {
        public class Node
        {
            public int data;
            public Node left, right;
        };

        static Boolean isBST(Node root, Node l, Node r)
        {
            if (root == null)
                return true;

            if (l != null && root.data <= l.data)
                return false;

            if (r != null && root.data >= r.data)
                return false;

            return isBST(root.left, l, root) && isBST(root.right, root, r);
        }

        static Node newNode(int data)
        {
            Node node = new Node();
            node.data = data;
            node.left = node.right = null;
            return (node);
        }

        //Driver code
        //public static void Main(String[] args)
        //{
        //    Node root = newNode(3);
        //    root.left = newNode(2);
        //    root.right = newNode(5);
        //    root.left.left = newNode(1);
        //    root.left.right = newNode(4);

        //    var temp = SearchBst(root, 5);
        //    Console.ReadLine();

        //    //if (isBST(root, null, null))
        //    //    Console.Write("Is BST");
        //    //else
        //    //    Console.Write("Not a BST");
        //}

        public static Node SearchBst(Node root, int val)
        {
            if (root == null)
                return null;

            if (root.data == val)
                return root;

            if (root.data < val)
            {
                var temp1 = SearchBst(root.right, val);
                return temp1;
            }

            else if (root.data > val)
            {
                var temp2 = SearchBst(root.left, val);
                return temp2;
            }

            return root;
        }

        //public TreeNode IncreasingBST(TreeNode root)
        //{
        //    var vals = new List<int>();
        //    inorder(root, vals);

        //    TreeNode ans = new TreeNode(0);
        //    TreeNode curr = ans;

        //    for (int i = 0; i < vals.Count; i++)
        //    {
        //        curr.right = new TreeNode(vals[i]);
        //        curr = curr.right;
        //    }

        //    return ans.Right;


        //    return root;
        //}
    }
}