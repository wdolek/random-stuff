using System.Collections.Generic;
using System.Linq;
using _1337Code.MergeSortedLists;
using Xunit;

namespace _1337Code.Tests.MergeSortedLists
{
    public sealed class LinkedListSortatorShould
    {
        [Theory]
        [MemberData(nameof(GenerateInput))]
        public void MergeAllGivenLists(ListNode[] lists, int[] expectedSequence)
        {
            var sortator = new LinkedListSortator();
            var result = sortator.MergeKLists(lists);

            Assert.True(expectedSequence.SequenceEqual(ConvertToEnumerable(result)));
        }

        [Theory]
        [MemberData(nameof(GenerateEmptyInput))]
        public void ReturnNullOnEmptyInput(ListNode[] lists)
        {
            var sortator = new LinkedListSortator();
            var result = sortator.MergeKLists(lists);

            Assert.Null(result);
        }

        public static IEnumerable<object[]> GenerateInput()
        {
            yield return new object[]
            {
                new[]
                {
                    ConvertToLinkedList(1, 4, 5),
                    ConvertToLinkedList(1, 3, 4),
                    ConvertToLinkedList(2, 6),
                },
                new[] { 1, 1, 2, 3, 4, 4, 5, 6 }
            };

            yield return new object[]
            {
                new[]
                {
                    ConvertToLinkedList(3),
                    ConvertToLinkedList(2),
                    ConvertToLinkedList(1),
                },
                new[] { 1, 2, 3 }
            };

            yield return new object[]
            {
                new[]
                {
                    ConvertToLinkedList(10, 11, 12, 13, 14, 15),
                    ConvertToLinkedList(2, 4, 6, 8, 10, 12),
                    ConvertToLinkedList(3, 5, 7),
                },
                new[] { 2, 3, 4, 5, 6, 7, 8, 10, 10, 11, 12, 12, 13, 14, 15 }
            };
        }

        public static IEnumerable<object[]> GenerateEmptyInput()
        {
            yield return new object[] { null };
            yield return new object[] { new ListNode[0] };
        }

        private static ListNode ConvertToLinkedList(params int[] nums) =>
            ConvertToLinkedList((IEnumerable<int>)nums);

        private static ListNode ConvertToLinkedList(IEnumerable<int> nums)
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

        private static IEnumerable<int> ConvertToEnumerable(ListNode list)
        {
            while (list != null)
            {
                yield return list.val;
                list = list.next;
            }
        }
    }
}
