using System;
using System.Collections.Generic;
using System.Linq;
using _1337Code.SwapNodesInPairs;
using Xunit;
using static _1337Code.SwapNodesInPairs.NodeSwapator;

namespace _1337Code.Tests.SwapNodesInPairs
{
    public sealed class NodeSwapatorShould
    {
        [Theory]
        [MemberData(nameof(GenerateTestData))]
        public void SwapAdjecentNodes(ListNode node, IEnumerable<int> expected)
        {
            var swapator = new NodeSwapator();
            var result = swapator.SwapPairs(node);

            Assert.True(expected.SequenceEqual(AsEnumerable(result)));
        }

        [Theory]
        [MemberData(nameof(GenerateTestData))]
        public void SwapAdjecentNodesRecursively(ListNode node, IEnumerable<int> expected)
        {
            var swapator = new NodeSwapator();
            var result = swapator.SwapPairsRecursion(node);

            Assert.True(expected.SequenceEqual(AsEnumerable(result)));
        }

        [Theory]
        [MemberData(nameof(GenerateTestData))]
        public void SwapAdjecentNodesInLoop(ListNode node, IEnumerable<int> expected)
        {
            var swapator = new NodeSwapator();
            var result = swapator.SwapPairsInLoop(node);

            Assert.True(expected.SequenceEqual(AsEnumerable(result)));
        }

        public static IEnumerable<object[]> GenerateTestData()
        {
            yield return new object[] { AsLinkedList(1, 2, 3, 4), new[] { 2, 1, 4, 3 } };
            yield return new object[] { AsLinkedList(1), new[] { 1 } };
            yield return new object[] { AsLinkedList(1, 2), new[] { 2, 1 } };
            yield return new object[] { AsLinkedList(1, 2, 3), new[] { 2, 1, 3 } };
            yield return new object[] { AsLinkedList(1, 2, 3, 4, 5, 6, 7, 8, 9), new[] { 2, 1, 4, 3, 6, 5, 8, 7, 9 } };
            yield return new object[] { null, new int[0] };
        }

        private static ListNode AsLinkedList(params int[] nums)
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

        private static IEnumerable<int> AsEnumerable(ListNode head)
        {
            var point = head;
            while (point != null)
            {
                yield return point.val;
                point = point.next;
            }
        }
    }
}
