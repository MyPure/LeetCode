using System;
using System.Collections.Generic;
using System.Text;

namespace JZOffer
{
    class PrintListFromTailToHead_3
    {

        // 返回从尾到头的列表值序列
        public List<int> printListFromTailToHead(ListNode listNode)
        {
            Stack<int> s = new Stack<int>();
            while(listNode != null)
            {
                s.Push(listNode.val);
                listNode = listNode.next;
            }
            List<int> result = new List<int>(s.ToArray());
            result.Reverse();
            return result;
        }
    }
    class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
        }
    }
}