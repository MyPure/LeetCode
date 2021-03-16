using System;
using System.Collections.Generic;
using System.Text;

namespace JZOffer
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x)
        {
            val = x;
        }

        public static void PreorderTraversal(TreeNode root)
        {
            if(root is null)
            {
                return;
            }
            else
            {
                Console.Write(root.val + " ");
                PreorderTraversal(root.left);
                PreorderTraversal(root.right);
            }
        }
    }
}
