using System;
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

            int marker = 1;
            int condExpression = array.Length;

            for (int k = 0; k < powerOfTwo; k++) {
                condExpression /= 2;
                for (int j = 0; j < condExpression; j++) {
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
            int condExpression = 1;

            for (int k = 0; k < powerOfTwo; k++) {
                for (int j = 0; j < condExpression; j++) {
                    (array[2 * marker * j], array[2 * marker * j + marker]) =
                        (array[2 * marker * j] + array[2 * marker * j + marker], array[2 * marker * j] - array[2 * marker * j + marker]);
                }
                marker /= 2;
                condExpression *= 2;
            }
            return array;
        }

        /// <summary>
        /// Быстрое преобразование Хаара (Ordered)
        /// </summary>
        /// <param name="array">массив значений сигнала</param>
        /// <param name="powerOfTwo">степень двойки</param>
        /// <returns></returns>
        internal static double[] OrderedFHWT(double[] array, int powerOfTwo) {

            int condExpression = array.Length;
            double[] tmpDiffArray = new double[condExpression / 2];

            for (int k = 0; k < powerOfTwo; k++) {
                condExpression /= 2;
                for (int j = 0; j < condExpression; j++) {
                    tmpDiffArray[j] = (array[2 * j] - array[2 * j + 1]) / 2.0;
                    array[j] = (array[2 * j] + array[2 * j + 1]) / 2.0;
                }
                for (int j = 0; j < condExpression; j++) {
                    array[j + condExpression] = tmpDiffArray[j];
                }
            }
            return array;
        }

        /// <summary>
        /// Быстрое обратное преобразование Хаара (Ordered)
        /// </summary>
        /// <param name="array">массив значений сигнала</param>
        /// <param name="powerOfTwo">степень двойки</param>
        /// <returns></returns>
        internal static double[] OrderedFIHWT(double[] array, int powerOfTwo) {

            double[] tmpDiffArray = new double[array.Length / 2];
            int condExpression = 1;

            for (int k = 0; k < powerOfTwo; k++) {
                for (int j = 0; j < condExpression; j++) {
                    tmpDiffArray[j] = array[j + condExpression];
                }
                for (int j = condExpression - 1; j >= 0; j--) {
                    array[2 * j + 1] = array[j] - tmpDiffArray[j];
                    array[2 * j] = array[j] + tmpDiffArray[j];
                }
                condExpression *= 2;
            }
            return array;
        }


        #endregion
    }
}
