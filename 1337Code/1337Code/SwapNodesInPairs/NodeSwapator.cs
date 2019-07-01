using System.Collections.Generic;
using System.Linq;

namespace _1337Code.SwapNodesInPairs
{
    // https://leetcode.com/problems/swap-nodes-in-pairs/
    public sealed class NodeSwapator
    {
        public ListNode SwapPairs(ListNode head)
        {
            if (head is null || head.next is null)
            {
                return head;
            }

            var values = AsEnumerable(head).ToArray();

            // make sure we won't get out of range
            var last = values.Length % 2 == 0
                ? values.Length
                : values.Length - 1;

            // swap adjecent values
            for (var i = 0; i < last; i += 2)
            {
                var temp = values[i];
                values[i] = values[i + 1];
                values[i + 1] = temp;
            }

            // convert back to linked list
            return AsLinkedList(values);
        }

        public ListNode SwapPairsRecursion(ListNode head)
        {
            // base case
            if (head is null || head.next is null)
            {
                return head;
            }

            var first = head;
            var second = first.next;

            // 0: (1) -> (2) -> (3) -> (4)
            //     ^- HEAD
            //
            // make `first` point to `third`
            // 1: (1)    (2) -> (3) -> (4)
            //     +-------------^
            //
            // make `second` point to `first`
            // 2: (1)    (2)    (3) -> (4)
            //     +-------------^
            //     ^------+
            //
            // 3: (2) -> (1) -> (3) -> (4)
            //     ^- HEAD
            first.next = second.next;
            second.next = first;

            // call recursively
            // NB! `first` is now second; use its next node for swapping within recursion
            first.next = SwapPairsRecursion(first.next);

            // `second` is new head
            return second;
        }

        public ListNode SwapPairsInLoop(ListNode head)
        {
            if (head is null || head.next is null)
            {
                return head;
            }

            // keep first entry
            var point = head;

            // move head to next (second node will become head)
            head = head.next;

            // perform swapping
            ListNode previous = null;
            while (point != null)
            {
                var first = point;
                var second = first.next;

                // there's no adjecent node any more - nothing to swap
                if (second is null)
                {
                    break;
                }

                // swap: (1) -> (3), (2) -> (1)
                first.next = second.next;
                second.next = first;

                // make sure that second node from previous pair is now pointing to `second` (which is first now)
                if (previous != null)
                {
                    previous.next = second;
                }

                // move to beginning of next pair
                // NB! `first` is now second
                point = first.next;

                // keep last node of pair
                previous = first;
            }

            return head;
        }

        private static IEnumerable<int> AsEnumerable(ListNode head)
        {
            var point = head;
            while (point != null)
            {
                yield return point.val;
                point = point.next;
            }
        }

        private static ListNode AsLinkedList(int[] nums)
        {
            var head = new ListNode(0);
            var point = head;
            foreach (var num in nums)
            {
                point.next = new ListNode(num);
                point = point.next;
            }

            return head.next;
        }

        public sealed class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
