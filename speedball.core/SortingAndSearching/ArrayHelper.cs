using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace speedball.core.SortingAndSearching
{
    public static class ArrayHelper
    {
        public static void MergeSortedArrays(int[] a, int[] b, int lastA, int lastB)
        {
            int indexA = lastA - 1; // index of last element in array b
            int indexB = lastB - 1; // index of last element in array a
            int indexMerged = lastB + lastA - 1; // end of merged array

            // merge a and b, starting from the last element in each
            while (indexA >= 0 && indexB >= 0)
            {
                // end of a is > than end of b
                if (a[indexA] > b[indexB])
                {
                    a[indexMerged] = a[indexA]; // copy element
                    indexMerged--; // move indicies
                    indexA--;
                }
                else
                {
                    a[indexMerged] = b[indexB]; // copy element
                    indexMerged--; // move indicies
                    indexB--;
                }
            }

            // copy remaining elements from b into place
            while (indexB >= 0)
            {
                a[indexMerged] = b[indexB];
                indexMerged--;
                indexB--;
            }
        }

        public static void SortByAnagrams(string[] array)
        {
            var hash = new Dictionary<string, LinkedList<string>>();

            // group wods by anagram
            foreach(var s in array)
            {
                var key = SortChars(s);
                if (!hash.ContainsKey(key)) hash.Add(key, new LinkedList<string>());
                LinkedList<string> anagrams = hash[key];
                anagrams.AddLast(s);
            }

            // convert hash table back to array
            int index = 0;
            foreach (var key in hash.Keys)
            {
                var list = hash[key];
                foreach(var t in list)
                {
                    array[index] = t;
                    index++;
                }
            }
        }

        private static string SortChars(string s)
        {
            var content = s.ToCharArray();
            Array.Sort(content);
            return content.ToString();  // could be new string(content)
        }

        public static int JankySearch(int[] a, int left, int right, int x)
        {
            int mid = (left + right) / 2;
            if (x == a[mid]) return mid;  // found element

            if (right < left) return -1;

            // either the left or right half must be normally ordered. find out which side is normally ordered,
            // then used the normally ordered half to figure out which side to search to find x.
            if (a[left] < a[mid])  // left is normally ordered
            {
                if (x >= a[left] && x <= a[mid])
                {
                    return JankySearch(a, left, mid - 1, x);  // search left
                }
                    
                return JankySearch(a, mid + 1, right, x);  // search right
            }

            if (a[mid] < a[left])  // right is normally ordered
            {
                if (x >= a[mid] && x <= a[right])
                {
                    return JankySearch(a, mid + 1, right, x);  // search right
                }

                return JankySearch(a, left, mid - 1, x);  // search left
            }

            if (a[left] == a[mid])  // left half is all repeats
            {
                if (a[mid] != a[right])  // if right is diff., search it
                {
                    return JankySearch(a, mid + 1, right, x);  // search right
                }

                // else, we have to search both halves
                int result = JankySearch(a, left, mid - 1, x);  // search left
                if (result == -1)
                {
                    return JankySearch(a, mid + 1, right, x);  // search right
                }

                return result;
            }

            return -1;
        }

        public static int SpecialBinarySearch(string[] strings, string target, int first, int last)
        {
            // move mid to the middle
            int mid = (last + first) / 2;

            // if mid is empty, find closest non-empty string
            if (strings[mid] == string.Empty)
            {
                int left = mid = 1;
                int right = mid + 1;

                while(true)
                {
                    if (left < first && right > last) return -1;

                    if (right <= last && strings[right] != string.Empty)
                    {
                        mid = right;
                        break;
                    }

                    if (left >= first && strings[left] != string.Empty)
                    {
                        mid = left;
                        break;
                    }

                    right++;
                    left--;
                }
            }

            // check for target string, and recurse if necessary
            if (target == strings[mid]) return mid;  // found it!
            if (strings[mid].CompareTo(target) < 0) return SpecialBinarySearch(strings, target, mid + 1, last);  // search right

            return SpecialBinarySearch(strings, target, first, mid - 1);  // search left
        }

        public static int SpecialBinarySearch(string[] strings, string target)
        {
            if (strings == null || target == null || target == "") return -1;

            return SpecialBinarySearch(strings, target, 0, strings.Length - 1);
        }
    }
}
