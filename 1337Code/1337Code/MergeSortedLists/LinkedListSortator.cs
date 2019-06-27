using System.Collections.Generic;

namespace _1337Code.MergeSortedLists
{
    // https://leetcode.com/problems/merge-k-sorted-lists/
    public sealed class LinkedListSortator
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
            {
                return null;
            }

            var listQueue = new Queue<ListNode>(lists);
            var merged = listQueue.Dequeue();
            while (listQueue.Count > 0)
            {
                merged = MergeLists(merged, listQueue.Dequeue());
            }

            return merged;
        }

        private ListNode MergeLists(ListNode left, ListNode right)
        {
            // initial state:
            // -------------
            //
            // [ 1 -> 3 -> 5 ]
            //   ^- left
            //
            // [ 2 -> 4 ]
            //   ^- right
            //
            // [ 0 ]
            //   ^- head, point
            //
            // after first iteration:
            // ---------------------
            //
            // [ 1 -> 3 -> 5 ]
            //        ^- left
            //
            // [ 2 -> 4 ]
            //   ^- right
            //
            // [ 0 -> 1 ]
            //   ^- head
            //        ^- point

            var head = new ListNode(0);
            var point = head;

            while (left != null && right != null)
            {
                // find smaller value,
                // move pointer on node which contained smaller value
                if (left.val < right.val)
                {
                    point.next = left;
                    left = left.next;
                }
                else
                {
                    point.next = right;
                    right = right.next;
                }

                // effectively setting `next` on either `left` or `right`
                point = point.next;
            }

            // there are some nodes left
            point.next = left ?? right;

            // skip "0" node
            return head.next;
        }
    }
}
