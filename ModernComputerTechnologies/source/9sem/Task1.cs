using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ModernComputerTechnologies {
    class Task1 {

        #region Helpers

        /// <summary>
        /// Функция потока для сортировки пузырьком
        /// </summary>
        /// <param name="array">массив</param>
        internal static void ThreadBubbleSort(object array) {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Task1.BubbleSort((int[])array);
            stopWatch.Stop();
            //Console.WriteLine($"Sorted array <{BubbleSort}>: {string.Join(" ,", array.ToArray())}");
            Console.WriteLine($"Sorted array <BubbleSort>: time = {stopWatch.Elapsed.Minutes}m:{stopWatch.Elapsed.Seconds}s:{stopWatch.Elapsed.Milliseconds}ms\t default time = {stopWatch.Elapsed}");
        }

        /// <summary>
        /// Функция потока для сортировки вставками
        /// </summary>
        /// <param name="array">массив</param>
        internal static void ThreadInsertSort(object array) {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Task1.InsertSort((int[])array);
            stopWatch.Stop();
            //Console.WriteLine($"Sorted array <{InsertSort}>: {string.Join(" ,", array.ToArray())}");
            Console.WriteLine($"Sorted array <InsertSort>: time = {stopWatch.Elapsed.Minutes}m:{stopWatch.Elapsed.Seconds}s:{stopWatch.Elapsed.Milliseconds}ms\t default time = {stopWatch.Elapsed}");
        }

        /// <summary>
        /// Функция потока для быстрой сортировки
        /// </summary>
        /// <param name="array">массив</param>
        internal static void ThreadQuickSort(object array) {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Task1.QuickSort((int[])array);
            stopWatch.Stop();
            //Console.WriteLine($"Sorted array <{QuickSort}>: {string.Join(" ,", array.ToArray())}");
            Console.WriteLine($"Sorted array <QuickSort>: time = {stopWatch.Elapsed.Minutes}m:{stopWatch.Elapsed.Seconds}s:{stopWatch.Elapsed.Milliseconds}ms\t default time = {stopWatch.Elapsed}");
        }


        /// <summary>
        /// Рандомное заполение массива, диапазон от 0 до arrayLength * 25
        /// </summary>
        /// <param name="array">массив</param>
        /// <param name="arrayLength">длина массива</param>
        internal static void FillRandom(int[] array, int arrayLength) {
            Random randNum = new Random();
            int maxValue = arrayLength * 25;
            for (int i = 0; i < arrayLength; i++) {
                array[i] = randNum.Next(0, maxValue);
            }
        }

        #endregion

        #region BubbleSort, InsertSort, QuickSort

        /// <summary>
        /// Сортировка пузырьком
        /// </summary>
        /// <param name="array">массив</param>
        internal static void BubbleSort(int[] array) {
            int arrayLength = array.Length;
            for (int i = 0; i < arrayLength - 1; i++) {
                for (int j = 0; j < arrayLength - i - 1; j++) {
                    if (array[j] > array[j + 1]) {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
        }

        /// <summary>
        /// Сортировка вставками
        /// </summary>
        /// <param name="array">массив</param>
        internal static void InsertSort(int[] array) {
            int arrayLength = array.Length;
            for (int i = 1; i < arrayLength; i++) {
                for (int j = i; j > 0 && array[j - 1] > array[j]; j--) {
                    (array[j - 1], array[j]) = (array[j], array[j - 1]);
                }
            }
        }

        /// <summary>
        /// Быстрая сортировка
        /// </summary>
        /// <param name="array">массив</param>
        internal static void QuickSort(int[] array) {
            QuickSort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Быстрая сортировка
        /// </summary>
        /// <param name="array">массив</param>
        /// <param name="indexLow">первый индекс</param>
        /// <param name="indexHigh">последний индекс</param>
        static void QuickSort(int[] array, int indexLow, int indexHigh) {
            int pivotIndex = FindPivot(array, indexLow, indexHigh);
            if (pivotIndex != -1) {
                int pivot = array[pivotIndex];
                int k = Partition(array, indexLow, indexHigh, pivot);
                QuickSort(array, indexLow, k - 1);
                QuickSort(array, k, indexHigh);
            }
        }

        /// <summary>
        /// Поиск опорного элемента
        /// </summary>
        /// <param name="array">массив</param>
        /// <param name="indexLow">первый индекс</param>
        /// <param name="indexHigh">последний индекс</param>
        /// <returns></returns>
        static int FindPivot(int[] array, int indexLow, int indexHigh) {
            int firstKey = array[indexLow];
            for (int k = indexLow + 1; k <= indexHigh; k++) {
                if (array[k] > firstKey) {
                    return k;
                }
                if (array[k] < firstKey) {
                    return indexLow;
                }
            }
            return -1;
        }

        /// <summary>
        /// Разбиение массива на две части по опорному элементу
        /// </summary>
        /// <param name="array">массив</param>
        /// <param name="indexLow">первый индекс</param>
        /// <param name="indexHigh">последний индекс</param>
        /// <param name="pivot">опорный элемент</param>
        /// <returns></returns>
        static int Partition(int[] array, int indexLow, int indexHigh, int pivot) {
            int left = indexLow;
            int right = indexHigh;
            do {
                while (array[left] < pivot) {
                    left++;
                }
                while (array[right] >= pivot) {
                    right--;
                }                 
                if (left < right) {
                    (array[left], array[right]) = (array[right], array[left]);
                }
            } while (left <= right);
            return left;
        }


        #endregion


        #region Old Implementation

        /// <summary>
        /// Виды сортировок
        /// </summary>
        internal enum SortType {
            BubbleSort = 0,
            InsertSort = 1,
            QuickSort = 2
        }

        /// <summary>
        /// Результаты выполнения сортировок
        /// </summary>
        /// <param name="array">массив</param>
        /// <param name="sortType">вид сортировки</param>
        internal static void SortResult(int[] array, SortType sortType) {
            Stopwatch stopWatch = new Stopwatch();
            switch (sortType) {
                case SortType.BubbleSort:
                    stopWatch.Start();
                    BubbleSort(array);
                    stopWatch.Stop();
                    break;
                case SortType.InsertSort:
                    stopWatch.Start();
                    InsertSort(array);
                    stopWatch.Stop();
                    break;
                case SortType.QuickSort:
                    stopWatch.Start();
                    QuickSort(array);
                    stopWatch.Stop();
                    break;
                default:
                    return;
            }
            Console.WriteLine($"Sorted array <{sortType}>: time = {stopWatch.Elapsed.Minutes}m:{stopWatch.Elapsed.Seconds}s:{stopWatch.Elapsed.Milliseconds}ms\t default time = {stopWatch.Elapsed}");
            //Console.WriteLine($"Sorted array <{sortType}>: {string.Join(" ,", array.ToArray())}");
        }
        #endregion
    }
}
