using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernComputerTechnologies {
    class Task2 {
        /// <summary>
        /// Слияние двух отсортированных массивов в один за fstArray.Length + sndArray.Length итерацию
        /// </summary>
        /// <param name="resultArray">массив слияния</param>
        /// <param name="fstArray">первый массив</param>
        /// <param name="sndArray">второй массив</param>
        internal static void ArrayMerge(int[] resultArray, int[] fstArray, int[] sndArray) {

            int i = 0;
            int j = 0;

            for (int k = 0; k < resultArray.Length; k++) {
                resultArray[k] =
                    i >= fstArray.Length ? sndArray[j++] :
                    j >= sndArray.Length ? fstArray[i++] :
                    fstArray[i] > sndArray[j] ? sndArray[j++] : fstArray[i++];
            }
        }
    }
}
