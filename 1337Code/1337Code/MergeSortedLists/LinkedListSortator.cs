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

            // do "stitching" between two linked lists
            while (left != null && right != null)
            {
                // find smaller value,
                // -> set lower value to be next after current point
                // -> move node to its next linked node
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

                // -> move current point to its next
                point = point.next;
            }

            // there are some nodes left
            point.next = left ?? right;

            // skip "0" node
            return head.next;
        }
    }
}
