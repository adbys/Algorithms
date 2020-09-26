using System;
using System.Collections.Generic;

namespace merge_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> {10, 9, 8, 7, 6, 5, 4, 3, 2, 1};
            var list1 = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var list2 = new List<int> {100, 9998, 81, 702, 61, 5, 4015, 301, 2, 11};
            var list3 = new List<int> {1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
            MergeSort<int>(list, 0, list.Count-1);
            MergeSort<int>(list1, 0, list.Count-1);
            MergeSort<int>(list2, 0, list.Count-1);
            MergeSort<int>(list3, 0, list.Count-1); 
        }

        public static void MergeSort<T>(List<T> list, int begin, int end) where T : IComparable<T>
        {
            if(end > begin)
            {
                var mid = (end - begin) / 2 + begin;
                MergeSort(list, begin, mid);
                MergeSort(list, mid + 1, end);
                Merge(list, begin, mid, end);
            }
        }

        public static void Merge<T>(List<T> list, int begin, int mid, int end) where T : System.IComparable<T>
        {
            var leftArrayLen = mid - begin + 1;
            var rightArrayLen = end - (mid + 1) + 1;
            var leftArray = new T[leftArrayLen];
            var rightArray = new T[rightArrayLen];

            int i = 0;
            for(var index = begin; index <= mid; index++)
            {
                leftArray[i] = list[index];
                i++;
            }

            int j = 0;
            for(var index = mid + 1; index <= end; index ++)
            {
                rightArray[j] = list[index];
                j++;
            }

            i = 0;
            j = 0;

            for(var index = begin; index <= end; index++)
            {
                if (i < leftArrayLen && j < rightArrayLen){
                    if(rightArray[j].CompareTo(leftArray[i]) < 0)
                    {
                        list[index] = rightArray[j];
                        j++;
                        continue;
                    }
                    else
                    {
                        list[index] = leftArray[i];
                        i++;
                        continue;
                    }
                }
                else if(i < leftArrayLen)
                {
                    list[index] = leftArray[i];
                    i++;
                }
                else if(j < rightArrayLen)
                {
                    list[index] = rightArray[j];
                    j++;
                }
            }
        }
    }
}
