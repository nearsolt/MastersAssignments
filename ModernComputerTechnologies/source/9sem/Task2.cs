using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernComputerTechnologies {
    class Task2 {
        /// <summary>
        /// Слияние двух отсортированных массивов в один за fstArrayLength + sndArrayLength итерацию
        /// </summary>
        /// <param name="resultArray">массив слияния</param>
        /// <param name="fstArrayLength">размерность первого массива</param>
        /// <param name="sndArrayLength">размерность второго массива</param>
        internal static void ArrayMerge(int[] resultArray, int fstArrayLength, int sndArrayLength) {

            int[] fstArray = new int[fstArrayLength];
            int[] sndArray = new int[sndArrayLength];

            Helpers.FillRandom(fstArray, fstArrayLength);
            Array.Sort(fstArray);
            //Console.WriteLine($"Sorted array:\n{string.Join(" ,", fstArray.ToArray())}\n");

            Helpers.FillRandom(sndArray, sndArrayLength);
            Array.Sort(sndArray);
            //Console.WriteLine($"Sorted array:\n{string.Join(" ,", sndArray.ToArray())}\n");

            int i = 0;
            int j = 0;

            for (int k = 0; k < resultArray.Length; k++) {
                resultArray[k] =
                    i >= fstArrayLength ? sndArray[j++] :
                    j >= sndArrayLength ? fstArray[i++] :
                    fstArray[i] > sndArray[j] ? sndArray[j++] : fstArray[i++];
            }
            //Console.WriteLine($"resultArray:\n{string.Join(" ,", resultArray.ToArray())}\n");
        }
    }
}
