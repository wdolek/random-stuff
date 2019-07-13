using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

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

            fixed (int* a = A)
            {
                while (i < j)
                {
                    // use pointer to get to index: a[n] == *(a + n)
                    if (*(a + i) % 2 == 0)
                    {
                        ++i;
                    }

                    if (*(a + i) % 2 != 0)
                    {
                        SwapPtrs((a + i), (a + j));
                        --j;
                    }
                }
            }

            return A;
        }

        public int[] SortArrayByParityRefs(int[] A)
        {
            if (A == null || A.Length == 0)
            {
                return Array.Empty<int>();
            }

            var i = 0;
            var j = A.Length - 1;

            ref var first = ref A[0];

            while (i < j)
            {
                if (Unsafe.Add(ref first, i) % 2 == 0)
                {
                    ++i;
                }

                if (Unsafe.Add(ref first, i) % 2 != 0)
                {
                    SwapRefs(
                        ref Unsafe.Add(ref first, i),
                        ref Unsafe.Add(ref first, j));

                    --j;
                }
            }

            return A;
        }

        public int[] SortArrayByParityRefSpan(int[] A)
        {
            if (A == null || A.Length == 0)
            {
                return Array.Empty<int>();
            }

            var i = 0;
            var j = A.Length - 1;

            // https://ndportmann.com/system-runtime-compilerservices-unsafe/
            var span = A.AsSpan();
            ref var first = ref MemoryMarshal.GetReference(span);

            while (i < j)
            {
                if (Unsafe.Add(ref first, i) % 2 == 0)
                {
                    ++i;
                }

                if (Unsafe.Add(ref first, i) % 2 != 0)
                {
                    SwapRefs(
                        ref Unsafe.Add(ref first, i),
                        ref Unsafe.Add(ref first, j));

                    --j;
                }
            }

            return A;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static unsafe void SwapPtrs(int* a, int* b)
        {
            var tmp = *a;
            *a = *b;
            *b = tmp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SwapRefs(ref int a, ref int b)
        {
            var tmp = a;
            a = b;
            b = tmp;
        }
    }
}
