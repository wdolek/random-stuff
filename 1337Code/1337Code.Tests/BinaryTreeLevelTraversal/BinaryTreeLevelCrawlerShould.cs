using System;
using System.Collections.Generic;
using System.Linq;
using _1337Code.BinaryTreeLevelTraversal;
using Xunit;
using static _1337Code.BinaryTreeLevelTraversal.BinTreeLevelCrawler;

namespace _1337Code.Tests.BinaryTreeLevelTraversal
{
    // https://leetcode.com/problems/binary-tree-level-order-traversal/
    public sealed class BinaryTreeLevelCrawlerShould
    {
        [Theory]
        [MemberData(nameof(GenerateTestData))]
        public void ReturnCorrectValuesPerLevel(TreeNode root, IList<IList<int>> expected)
        {
            var crawler = new BinTreeLevelCrawler();
            var result = crawler.LevelOrder(root);

            Assert.True(expected.SequenceEqual(result, new InnerListComparer()));
        }

        public static IEnumerable<object[]> GenerateTestData()
        {
            var root = new TreeNode(3)
            {
                left = new TreeNode(9),
                right = new TreeNode(20)
                {
                    left = new TreeNode(15),
                    right = new TreeNode(7),
                }
            };

            yield return new object[]
            {
                root,
                new List<IList<int>>
                {
                    new List<int> { 3 },
                    new List<int> { 9, 20 },
                    new List<int> { 15, 7 },
                }
            };

            yield return new object[] { (TreeNode)null, new List<IList<int>>(0) };
        }

        private class InnerListComparer : IEqualityComparer<IList<int>>
        {
            public bool Equals(IList<int> x, IList<int> y) => x.SequenceEqual(y);

            // return `1` for any input to enforce calling of `Equals`... much clever, so hacky
            public int GetHashCode(IList<int> obj) => 1;
        }
    }
}
