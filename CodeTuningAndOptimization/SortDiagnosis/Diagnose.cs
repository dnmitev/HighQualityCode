namespace SortDiagnosis
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Diagnose
    {
        private const int ElementLimit = 10000;
        private static Random RandomGenerator = new Random();

        public static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();
            List<int> numbersCollection = GetRandomList(RandomGenerator.Next(20, 100));

            Console.WriteLine("Before sorting:");
            Print(numbersCollection);
            Console.WriteLine();

            stopwatch.Start();
            List<int> selectionSorted = SelectionSort(numbersCollection);
            Print(selectionSorted);
            stopwatch.Stop();
            Console.WriteLine("Selection sort time elapsed: {0}\n", stopwatch.Elapsed);

            stopwatch.Restart();
            List<int> quickSorted = QuickSort(numbersCollection);
            Print(quickSorted);
            stopwatch.Stop();
            Console.WriteLine("Quick sort time elapsed: {0}\n", stopwatch.Elapsed);

            stopwatch.Restart();
            List<int> mergeSorted = MergeSort(numbersCollection);
            Print(mergeSorted);
            stopwatch.Stop();
            Console.WriteLine("Merge sort time elapsed: {0}\n", stopwatch.Elapsed);
        }

        private static List<int> GetRandomList(int elementCount)
        {
            List<int> result = new List<int>(elementCount);

            for (int i = 0; i < elementCount; i++)
            {
                result.Add(RandomGenerator.Next(-ElementLimit, ElementLimit));
            }

            return result;
        }

        private static void Print(List<int> numbers)
        {
            Console.WriteLine(string.Join(" | ", numbers));
        }

        private static List<int> SelectionSort(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                for (int j = i; j < numbers.Count; j++)
                {
                    if (numbers[j] < numbers[i])
                    {
                        int oldValue = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = oldValue;
                    }
                }
            }

            return numbers;
        }

        private static List<int> QuickSort(List<int> numbers) // method to quick sort the lists
        {
            // if a list consists of a single value it is sorted
            if (numbers.Count <= 1)
            {
                return numbers;
            }

            // Pivot choice, the middle element
            int pivot = numbers[numbers.Count / 2];

            // define new list in order to store the less and the bigger values than the pivot
            List<int> less = new List<int>();
            List<int> greater = new List<int>();

            // go through the list and check values to the pivot
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i != (numbers.Count / 2))
                {
                    if (numbers[i] < pivot)
                    {
                        less.Add(numbers[i]);
                    }
                    else
                    {
                        greater.Add(numbers[i]);
                    }
                }
            }

            // return recursivly using the "QuickSort" through the greater and the less lists
            return ConcatenateLists(QuickSort(less), pivot, QuickSort(greater));
        }

        private static List<int> ConcatenateLists(List<int> less, int pivot, List<int> greater)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < less.Count; i++)
            {
                result.Add(less[i]);
            }

            result.Add(pivot);

            for (int i = 0; i < greater.Count; i++)
            {
                result.Add(greater[i]);
            }

            return result;
        }

        private static List<int> MergeSort(List<int> numbers) // method to merge sort each list
        {
            // when a list of a single value is reached, its considered sorted
            if (numbers.Count <= 1)
            {
                return numbers;
            }

            // find the middle of the total count of numbers 
            int middle = numbers.Count / 2;

            // generate new list in order to store the values of the non-merged arrays
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            // store values in the left list 
            for (int i = 0; i < middle; i++)
            {
                left.Add(numbers[i]);
            }

            //store values in the right list
            for (int i = middle; i < numbers.Count; i++)
            {
                right.Add(numbers[i]);
            }

            // recursivly call the "MergeSort" method until the numbers' count has reached 1
            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        private static void AppendListWhileMerge(List<int> merging, List<int> merged) //method to append lists after merging
        {
            merged.Add(merging[0]);
            merging.RemoveAt(0);
        }

        private static List<int> Merge(List<int> left, List<int> right) // method to merge the current list
        {
            // generate new list to store the merged lists
            List<int> merged = new List<int>();

            // compare the values of the list and merge them into a single list called merged
            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left[0] <= right[0])
                    {
                        AppendListWhileMerge(left, merged);
                    }
                    else
                    {
                        AppendListWhileMerge(right, merged);
                    }
                }
                else if (left.Count > 0)
                {
                    AppendListWhileMerge(left, merged);
                }
                else if (right.Count > 0)
                {
                    AppendListWhileMerge(right, merged);
                }
            }

            return merged;
        }
    }
}
