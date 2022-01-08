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

        static void Main(string[] args) {

            int arrayLength = 100000;

            int[] initialArray = new int[arrayLength];

            Task1.FillRandom(initialArray, arrayLength);
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

        #endregion


        #region task2: 
        #endregion


        #region task3: 
        #endregion

    }
}
