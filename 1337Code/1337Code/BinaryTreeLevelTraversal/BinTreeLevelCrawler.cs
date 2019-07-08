using System.Collections.Generic;

namespace _1337Code.BinaryTreeLevelTraversal
{
    public sealed class BinTreeLevelCrawler
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            if (root == null)
            {
                return new List<IList<int>>(0);
            }

            var result = new List<IList<int>>();

            var queue = new Queue<(TreeNode Node, int Level)>();
            queue.Enqueue((root, 0));

            while (queue.Count > 0)
            {
                var (current, level) = queue.Dequeue();

                // NB! we are always one item behind: list size 0 == level 0,
                //     we need to add new entry (list) so we can push stuff into it, so level 0 -> list[0] (list size = 1)
                if (result.Count == level)
                {
                    // TODO: consider pre-allocating list with its max capacity - we know max number of entries per level (2^level)
                    //       ... yet, if tree is not balanced, we will waste precious bytes of memory, so...
                    result.Add(new List<int>());
                }

                result[level].Add(current.val);

                if (current.left != null)
                {
                    queue.Enqueue((current.left, level + 1));
                }

                if (current.right != null)
                {
                    queue.Enqueue((current.right, level + 1));
                }
            }

            return result;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}
