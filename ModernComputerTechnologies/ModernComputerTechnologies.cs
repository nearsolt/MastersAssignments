using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ModernComputerTechnologies {
    class ModernComputerTechnologies {

        #region task1: 
#if false
        static void Main(string[] args) {

            int arrayLength = 100000;

            int[] initialArray = new int[arrayLength];

            Helpers.FillRandom(initialArray, arrayLength);
            Console.WriteLine($"Array lenght = {arrayLength}\n");
            //Console.WriteLine($"Unsorted array:\n{string.Join(" ,", initialArray.ToArray())}\n");

        #region Old Implementation
            //Task1.SortResult((int[])initialArray.Clone(), Task1.SortType.BubbleSort);
            //Task1.SortResult((int[])initialArray.Clone(), Task1.SortType.InsertSort);
            //Task1.SortResult((int[])initialArray.Clone(), Task1.SortType.QuickSort);
        #endregion

            Thread threadBubbleSort = new Thread(Task1.ThreadBubbleSort);
            threadBubbleSort.Start(initialArray.Clone());
            Thread threadInsertSort = new Thread(Task1.ThreadInsertSort);
            threadInsertSort.Start(initialArray.Clone());
            Thread threadQuickSort = new Thread(Task1.ThreadQuickSort);
            threadQuickSort.Start(initialArray.Clone());

            Console.ReadKey();
        }
#endif
        #endregion


        #region task2: 
#if false
        static void Main(string[] args) {

            int fstArrayLength = 5;
            int sndArrayLength = 6;

            int[] resultArray = new int[fstArrayLength + sndArrayLength];
            int[] fstArray = new int[fstArrayLength];
            int[] sndArray = new int[sndArrayLength];

            Helpers.FillRandom(fstArray, fstArrayLength);
            Array.Sort(fstArray);
            //Console.WriteLine($"Sorted {nameof(fstArray)}:\n{string.Join(" ,", fstArray.ToArray())}\n");

            Helpers.FillRandom(sndArray, sndArrayLength);
            Array.Sort(sndArray);
            //Console.WriteLine($"Sorted {nameof(sndArray)}:\n{string.Join(" ,", sndArray.ToArray())}\n");

            Task2.ArrayMerge(resultArray, fstArray, sndArray);
            //Console.WriteLine($"{nameof(resultArray)}:\n{string.Join(" ,", resultArray.ToArray())}\n");

            Console.ReadKey();
        }
#endif
        #endregion


        #region task3: 
#if true
        static void Main(string[] args) {

            
            Console.ReadKey();
        }
#endif
        #endregion

    }
}
