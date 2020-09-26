using System;
using System.Collections.Generic;

namespace quick_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> {10, 9, 8, 7, 6, 5, 4, 3, 2, 1};
            var list1 = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var list2 = new List<int> {100, 9998, 81, 702, 61, 5, 4015, 301, 2, 11};
            var list3 = new List<int> {1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
            QuickSort<int>(list, 0, list.Count-1);
            QuickSort<int>(list1, 0, list.Count-1);
            QuickSort<int>(list2, 0, list.Count-1);
            QuickSort<int>(list3, 0, list.Count-1);
        }

        public static void QuickSort<T> (List<T> list, int begin, int end) where T : IComparable<T>
        {
            if(begin < end) 
            {  
                var pivot = PlacePivot(list, begin, end);
                QuickSort(list, begin, pivot-1);
                QuickSort(list, pivot+1, end);
            }
        }

        public static int PlacePivot<T> (List<T> list, int begin, int end) where T : IComparable<T>
        {
            var pivot = begin;
            var i = begin;
            var j = end;
            
            while(i < j){
                while(i < end && list[i].CompareTo(list[pivot]) <= 0)
                {
                    i++;
                }

                while(j > 0 && list[j].CompareTo(list[pivot]) > 0)
                {
                    j--;
                }

                if(i < j)
                {
                    var temp = list[j];
                    list[j] = list[i];
                    list[i] = temp;
                }
            }

            for(var index = begin + 1; index <= j; index++)
            {
                var temp = list[index];
                list[index] = list[index-1];
                list[index-1] = temp;
            }

            return j;
        }
    }
}
