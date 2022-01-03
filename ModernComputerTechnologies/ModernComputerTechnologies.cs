using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernComputerTechnologies {
    class ModernComputerTechnologies {

        #region task1: 

        static void Main(string[] args) {

            int arrayLength = 100000;

            int[] initialArray = new int[arrayLength];

            Task1.FillRandom(initialArray, arrayLength);
            Console.WriteLine(string.Format("Array lenght = {0}{1}", arrayLength, Environment.NewLine));
            //Console.WriteLine(string.Format("Unsorted array:{0}{1}{0}", Environment.NewLine, string.Join(" ,", initialArray.ToArray())));

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
