using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace speedball.core.RecursionAndDynamicProgramming
{
    public static class MagicIndexFinder
    {
        public static int MagicSlow(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == i) return i;
            }

            return -1;
        }

        private static int MagicFast(int[] array, int start, int end)
        {
            if (end < start || start < 0 || end >= array.Length) return -1;

            int mid = (start + end) / 2;
            if (array[mid] == mid) return mid;
            if (array[mid] > mid) return MagicFast(array, start, mid - 1);
            return MagicFast(array, mid + 1, end);
        }

        public static int MagicFast(int[] array)
        {
            return MagicFast(array, 0, array.Length - 1);
        }

        private static int SpecialMagicFast(int[] array, int start, int end)
        {
            if (end < start || start < 0 || end >= array.Length) return -1;

            int midIndex = (start + end) / 2;
            int midValue = array[midIndex];
            if (midValue == midIndex) return midIndex;

            // search left
            int leftIndex = Math.Min(midIndex - 1, midValue);
            int left = SpecialMagicFast(array, start, leftIndex);
            if (left >= 0) return left;

            // search right
            int rightIndex = Math.Max(midIndex + 1, midValue);
            int right = SpecialMagicFast(array, rightIndex, end);

            return right;
        }

        public static int SpecialMagicFast(int[] array)
        {
            return SpecialMagicFast(array, 0, array.Length - 1);
        }
    }
}
