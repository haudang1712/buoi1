using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace buoi1_PTTKTT
{
    class Program
    {
        

        public static void Main()
        {
        Console.InputEncoding = UnicodeEncoding.Unicode;
        Console.OutputEncoding = UnicodeEncoding.Unicode;

        Console.WriteLine("Chọn bài toán:");
        Console.WriteLine("1. Tính tổng các phần tử trong mảng có n số nguyên.");
        Console.WriteLine("2. Sắp xếp MergeSort.");
        Console.WriteLine("3. Sắp xếp QuickSort.");
        Console.WriteLine("4. Tìm kiếm nhị phân.");
        Console.WriteLine("5. Selection Sort.");
        Console.WriteLine("Chọn 1 số đi brooo.");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                SumArray();
                break;
            case 2:
                MergeSortArray();
                break;
            case 3:
                QuickSortArray();
                break;
            case 4:
                BinarySearchArray();
                break;
            case 5:
                int[] arr = { 64, 25, 12, 22, 11 };
                sort(arr);
                Console.WriteLine("Sorted array");
                printArray(arr);
                Console.ReadKey();
                break;
            default:
                Console.WriteLine("Lựa chọn không hợp lệ.");
                break;
        }
    }
        // Bài 1: Tính tổng các phần tử trong mảng
        static void SumArray()
        {
            Console.WriteLine("Nhập số lượng phần tử trong mảng:");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];

            Console.WriteLine("Nhập các phần tử của mảng:");
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            int sum = 0;
            foreach (int num in array)
            {
                sum += num;
            }

            Console.WriteLine("Tổng các phần tử trong mảng là: " + sum);
            Console.ReadKey();
        }

        // Bài 2: Sắp xếp MergeSort
        static void MergeSortArray()
        {
            Console.WriteLine("Nhập số lượng phần tử trong mảng:");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];

            Console.WriteLine("Nhập các phần tử của mảng:");
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            MergeSort(array, 0, array.Length - 1);

            Console.WriteLine("Mảng sau khi sắp xếp MergeSort:");
            foreach (int num in array)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
            Console.ReadKey();

        }

        static void MergeSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;
                MergeSort(array, left, middle);
                MergeSort(array, middle + 1, right);
                Merge(array, left, middle, right);
            }
        }

        static void Merge(int[] array, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            int[] L = new int[n1];
            int[] R = new int[n2];

            for (int i = 0; i < n1; ++i)
                L[i] = array[left + i];
            for (int j = 0; j < n2; ++j)
                R[j] = array[middle + 1 + j];

            int k = left;
            int i1 = 0, j1 = 0;
            while (i1 < n1 && j1 < n2)
            {
                if (L[i1] <= R[j1])
                {
                    array[k] = L[i1];
                    i1++;
                }
                else
                {
                    array[k] = R[j1];
                    j1++;
                }
                k++;
            }

            while (i1 < n1)
            {
                array[k] = L[i1];
                i1++;
                k++;
            }

            while (j1 < n2)
            {
                array[k] = R[j1];
                j1++;
                k++;
            }
        }

        // Bài 3: Sắp xếp QuickSort
        static void QuickSortArray()
        {
            Console.WriteLine("Nhập số lượng phần tử trong mảng:");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];

            Console.WriteLine("Nhập các phần tử của mảng:");
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            QuickSort(array, 0, array.Length - 1);

            Console.WriteLine("Mảng sau khi sắp xếp QuickSort:");
            foreach (int num in array)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
            Console.ReadKey();

        }

        static void QuickSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(array, low, high);

                QuickSort(array, low, pi - 1);
                QuickSort(array, pi + 1, high);
            }
        }

        static int Partition(int[] array, int low, int high)
        {
            int pivot = array[high];
            int i = (low - 1);

            for (int j = low; j < high; j++)
            {
                if (array[j] < pivot)
                {
                    i++;

                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

            int temp1 = array[i + 1];
            array[i + 1] = array[high];
            array[high] = temp1;

            return i + 1;
        }

        // Bài 4: Tìm kiếm nhị phân
        static void BinarySearchArray()
        {
            Console.WriteLine("Nhập số lượng phần tử trong mảng:");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];

            Console.WriteLine("Nhập các phần tử của mảng:");
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(array);

            Console.WriteLine("Nhập số cần tìm:");
            int key = int.Parse(Console.ReadLine());

            int result = BinarySearch(array, key);

            if (result == -1)
            {
                Console.WriteLine("Không tìm thấy phần tử trong mảng.");
            }
            else
            {
                Console.WriteLine("Phần tử được tìm thấy tại vị trí: " + result);
            }
            Console.ReadKey();

        }

        static int BinarySearch(int[] array, int key)
        {
            int left = 0, right = array.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (array[mid] == key)
                {
                    return mid;
                }

                if (array[mid] < key)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1;
        }
// bài 5: selection sort 
    static void sort(int[] arr)
    {
        int n = arr.Length;

        for (int i = 0; i < n - 1; i++)
        {
            int min_idx = i;
            for (int j = i + 1; j < n; j++)
                if (arr[j] < arr[min_idx])
                    min_idx = j;


            int temp = arr[min_idx];
            arr[min_idx] = arr[i];
            arr[i] = temp;
        }
    }

    static void printArray(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n; ++i)
            Console.Write(arr[i] + " ");
        Console.WriteLine();
    }
    }
}

        