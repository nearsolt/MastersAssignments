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

            Helpers.FillRandom(initialArray, arrayLength, 25);
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

            Helpers.FillRandom(fstArray, fstArrayLength, 25);
            Array.Sort(fstArray);
            Console.WriteLine($"Sorted {nameof(fstArray)}:\n{string.Join(" ,", fstArray.ToArray())}\n");

            Helpers.FillRandom(sndArray, sndArrayLength, 25);
            Array.Sort(sndArray);
            Console.WriteLine($"Sorted {nameof(sndArray)}:\n{string.Join(" ,", sndArray.ToArray())}\n");

            Task2.ArrayMerge(resultArray, fstArray, sndArray);
            Console.WriteLine($"{nameof(resultArray)}:\n{string.Join(" ,", resultArray.ToArray())}\n");

            Console.ReadKey();
        }
#endif
        #endregion


        #region task3: 
#if true
        static void Main(string[] args) {

            int matrixLengthOx_1 = 3;
            int matrixLengthOx_2 = 4;
            int arrayLength = matrixLengthOx_1 * matrixLengthOx_2;

            int[,] matrix = new int[matrixLengthOx_1, matrixLengthOx_2];
            int[] array = new int[arrayLength];
            int[] resultArray = new int[arrayLength];

            Helpers.FillRandom(array, arrayLength, 2);
            Console.WriteLine($"\n{nameof(array)}: ");
            Helpers.PrintArray(array);


#if true
            Task3.SnakeAlgorithmArrayToMaxrix(matrix, array);
#else
            Task3.SpiralAlgorithmArrayToMaxrix(matrix, array);
#endif
            Console.WriteLine($"\n\n{nameof(matrix)}: ");
            Helpers.PrintMatrix(matrix);
#if true
            Task3.SnakeAlgorithmMatrixToArray(matrix, resultArray);
#else
            Task3.SpiralAlgorithmMaxrixToArray(matrix, resultArray);
#endif
            Console.WriteLine($"\n{nameof(resultArray)}: ");
            Helpers.PrintArray(resultArray);

            Console.ReadKey();
        }
#endif
        #endregion

    }
}
