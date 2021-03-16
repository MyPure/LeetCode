using System;
using System.Collections.Generic;
using System.Text;

namespace JZOffer
{
    class JZ4
    {
        public TreeNode reConstructBinaryTree(int[] pre, int[] tin)
        {
            if (pre.Length == 0) return null;
            TreeNode root = new TreeNode(pre[0]);
            TreeNode left;
            TreeNode right;
            ChildSearch(out left, out right, 0, 0, tin.Length - 1, pre, tin);
            root.left = left;
            root.right = right;
            return root;
        }

        private void ChildSearch(out TreeNode leftNode, out TreeNode rightNode, int preIndex, int tinL, int tinR, int[] pre, int[] tin)
        {
            leftNode = null;
            rightNode = null;
            if (tinL > tinR)
            {
                return;
            }
            int tinIndex = -1;

            for (int i = tinL; i <= tinR; i++)
            {
                if (tin[i] == pre[preIndex])
                {
                    tinIndex = i;
                    break;
                }
            }

            TreeNode left;
            TreeNode right;

            if (tinIndex - 1 >= tinL)
            {            
                leftNode = new TreeNode(pre[preIndex + 1]);
                ChildSearch(out left, out right, preIndex + 1, tinL, tinIndex - 1, pre, tin);
                leftNode.left = left;
                leftNode.right = right;
            }

            if(tinIndex + 1 <= tinR)
            {
                rightNode = new TreeNode(pre[preIndex + tinIndex - tinL + 1]);
                ChildSearch(out left, out right, preIndex + tinIndex - tinL + 1, tinIndex + 1, tinR, pre, tin);
                rightNode.left = left;
                rightNode.right = right;
            }           
        }
    }
}
