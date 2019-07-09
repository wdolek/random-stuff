using System;
using System.Linq;

namespace _1337Code.SortArrayByParity
{
    // https://leetcode.com/problems/sort-array-by-parity/
    public sealed class ParityArraySortator
    {
        public int[] SortArrayByParity(int[] A)
        {
            if (A == null || A.Length == 0)
            {
                return Array.Empty<int>();
            }

            // simplistic solution with LINQ
            var even = A.Where(i => i % 2 == 0);
            var odd = A.Where(i => i % 2 != 0);

            return even.Concat(odd).ToArray();
        }

        public int[] SortArrayByParityInPlace(int[] A)
        {
            if (A == null || A.Length == 0)
            {
                return Array.Empty<int>();
            }

            var i = 0;
            var j = A.Length - 1;
            while (i < j)
            {
                if (A[i] % 2 == 0)
                {
                    ++i;
                }

                if (A[i] % 2 != 0)
                {
                    var tmp = A[i];
                    A[i] = A[j];
                    A[j] = tmp;

                    --j;
                }
            }

            return A;
        }

        public unsafe int[] SortArrayByParityUnsafe(int[] A)
        {
            if (A == null || A.Length == 0)
            {
                return Array.Empty<int>();
            }

            var i = 0;
            var j = A.Length - 1;

            // fix input array in memory
            fixed (int* a = A)
            {
                while (i < j)
                {
                    if (a[i] % 2 == 0)
                    {
                        ++i;
                    }

                    if (a[i] % 2 != 0)
                    {
                        SwapPtrs(&a[i], &a[j]);
                        --j;
                    }
                }
            }

            return A;
        }

        private static unsafe void SwapPtrs(int* a, int* b)
        {
            var tmp = *a;
            *a = *b;
            *b = tmp;
        }
    }
}
