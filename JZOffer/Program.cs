using System;

namespace JZOffer
{
    class Program
    {
        static void Main(string[] args)
        {
            JZ4 j = new JZ4();
            TreeNode.PreorderTraversal(j.reConstructBinaryTree(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 }));
            //TreeNode.PreorderTraversal(j.reConstructBinaryTree(new int[] { 1, 2, 3}, new int[] { 2, 1, 3 }));

        }
    }
}
