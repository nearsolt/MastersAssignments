using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernComputerTechnologies {
    class Helpers {

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


    }
}
