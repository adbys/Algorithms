using System;
using System.Collections.Generic;

namespace max_subarray
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> {100, 113, 110, 85, 105, 102, 86, 63, 81, 101, 94, 106, 101, 79, 94, 90, 97};
            var maxSubarray = CalculateMaximumSubarray(list);
            var tuple = FindMaximumSubArray(maxSubarray, 0, maxSubarray.Count - 1);
        }

        public static List<int> CalculateMaximumSubarray(List<int> list)
        {
            var maximumSubarray = new List<int>();

            for(var index = 1; index < list.Count; index++)
            {
                maximumSubarray.Add(list[index] -  list[index-1]);
            }

            return maximumSubarray;
        }

        public static Tuple<int, int, int> FindMaximumSubArray(List<int> list, int begin, int end) 
        {
            if(begin == end)
                return new Tuple<int, int, int>(list[begin], begin, end);
            else
            {
                var mid = (begin + end) / 2;
                var leftSum = FindMaximumSubArray(list, begin, mid);
                var rightSum = FindMaximumSubArray(list, mid + 1, end);
                var crossSum = FindMaximumSubArrayCrossingSubArray(list, begin, mid, end);
                
                if(leftSum.Item1 >= rightSum.Item1 && leftSum.Item1 >= crossSum.Item1)
                    return leftSum;
                else if(rightSum.Item1 >= leftSum.Item1 && rightSum.Item1 >= crossSum.Item1)
                    return rightSum;
                else
                    return crossSum;
            }            
        }

        public static Tuple<int, int, int> FindMaximumSubArrayCrossingSubArray(List<int> list, int begin, int mid, int end)
        {

            var leftSum = Int32.MinValue;
            var maxLeft = Int32.MinValue;
            var sum = 0;
            for(var index = mid; index >= 0; index--)
            {
                sum = sum + list[index];
                if(sum > leftSum)
                {
                    leftSum = sum;
                    maxLeft = index;
                }
            }

            var rightSum = Int32.MinValue;
            var maxRight = Int32.MinValue;
            sum = 0;
            for(var index = mid + 1; index <= end; index++)
            {
                sum = sum + list[index];
                if(sum > rightSum)
                {
                    rightSum = sum;
                    maxRight = index;
                }
            }

            return new Tuple<int, int, int>(leftSum + rightSum, maxLeft, maxRight);
        }
    }
}
