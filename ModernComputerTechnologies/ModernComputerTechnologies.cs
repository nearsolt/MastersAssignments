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

            int arrayLength = 10000;

            int[] initialArray = new int[arrayLength];

            Task1.FillRandom(initialArray, arrayLength);
            Console.WriteLine($"Array lenght = {arrayLength}\n");
            //Console.WriteLine($"Unsorted array:\n{string.Join(" ,", initialArray.ToArray())}\n");

            Task1.SortResult((int[])initialArray.Clone(), Task1.SortType.BubbleSort);
            Task1.SortResult((int[])initialArray.Clone(), Task1.SortType.InsertSort);
            Task1.SortResult((int[])initialArray.Clone(), Task1.SortType.QuickSort);
            
            
            /*Stopwatch tmp = new Stopwatch();
            int[] tmp2 = (int[])initialArray.Clone();
            tmp.Start();
            Array.Sort(tmp2);
            tmp.Stop();
            tmp2[0] = 0;*/

            Console.ReadKey();
        }

        #endregion


        #region task2: 
        #endregion


        #region task3: 
        #endregion

    }
}
