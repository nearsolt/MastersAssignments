﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAlgorithms {
    class Helpers {

        #region task 1: FHWT/FIHWT

        /// <summary>
        /// Проверка, является ли число степенью двойки (Decrement and Compare)
        /// </summary>
        /// <param name="num">вводимое число</param>
        /// <returns></returns>
        internal static bool IsPowerOfTwo(int num) {
            return (num != 0) && ((num & (num - 1)) == 0);
        }

        /// <summary>
        /// Быстрое преобразование Хаара (In Place)
        /// </summary>
        /// <param name="array">массив значений сигнала</param>
        /// <param name="powerOfTwo">степень двойки</param>
        /// <returns></returns>
        internal static double[] InPlaceFHWT(double[] array, int powerOfTwo) {

            int tmpLength = array.Length;
            int marker = 1;

            for (int k = 0; k < powerOfTwo; k++) {
                tmpLength /= 2;
                for (int j = 0; j < tmpLength; j++) {
                    (array[2 * marker * j], array[2 * marker * j + marker]) = 
                        ((array[2 * marker * j] + array[2 * marker * j + marker]) / 2.0, (array[2 * marker * j] - array[2 * marker * j + marker]) / 2.0);
                }
                marker *= 2;              
            }
            return array;
        }

        /// <summary>
        /// Быстрое обратное преобразование Хаара (In Place)
        /// </summary>
        /// <param name="array">массив значений сигнала</param>
        /// <param name="powerOfTwo">степень двойки</param>
        /// <returns></returns>
        internal static double[] InPlaceFIHWT(double[] array, int powerOfTwo) {

            int marker = array.Length / 2;
            int step = 1;

            for (int k = powerOfTwo; k > 0; k--) {
                for (int j = 0; j < step; j++) {
                    (array[2 * marker * j], array[2 * marker * j + marker]) = 
                        (array[2 * marker * j] + array[2 * marker * j + marker], array[2 * marker * j] - array[2 * marker * j + marker]);
                }
                marker /= 2;
                step *= 2;
            }
            return array;
        }



        #endregion
    }
}
