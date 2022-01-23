using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace HarmonicAnalysis {
    class Helpers {

        #region task 1: FFT/IFFT

        /// <summary>
        /// Проверка, является ли число степенью двойки (Decrement and Compare)
        /// </summary>
        /// <param name="num">вводимое число</param>
        /// <returns></returns>
        internal static bool IsPowerOfTwo(int num) {
            return (num != 0) && ((num & (num - 1)) == 0);
        }

        /// <summary>
        /// Вычисление  e^( -i*2*PI*j / 2^(N-k)) при прямом, e^( i*2*PI*j / 2^(N-k)) при обратном
        /// </summary>
        /// <param name="k">индекс k</param>
        /// <param name="j">индекс j</param>
        /// <param name="N">степерь размерности массива значений по основанию 2</param>
        /// <param name="inverse">флаг: false - прямое преобразование, true - обратное</param>
        /// <returns></returns>
        static Complex CalcExp(int k, int j, int N, bool inverse = false) {
            double arg = Math.PI * j / Convert.ToInt32(Math.Pow(2, N - k - 1)) * (inverse ? 1 : -1);
            return new Complex(Math.Cos(arg), Math.Sin(arg));
        }

        /// <summary>
        /// Быстрое преобразование Фурье (прямое, если inverse = false; обратное, если inverse = true)
        /// </summary>
        /// <param name="array">массив значений сигнала</param>
        /// <param name="inverse">флаг: false - прямое преобразование, true - обратное</param>
        /// <returns></returns>
        internal static Complex[] FFT(Complex[] array, bool inverse = false) {
            int partitionsNumber = array.Length;
            int powerOfTwo = 0;
            if (IsPowerOfTwo(partitionsNumber)) {
                powerOfTwo = Convert.ToInt32(Math.Log(partitionsNumber, 2));
            }
            Complex[] resultArray = new Complex[partitionsNumber];
            for (int k = 0; k < powerOfTwo; k++) {
                for (int i = 0; i < Convert.ToInt32(Math.Pow(2, k)); i++) {
                    for (int j = 0; j < Convert.ToInt32(Math.Pow(2, powerOfTwo - k - 1)); j++) {
                        resultArray[Convert.ToInt32(Math.Pow(2, k)) * 2 * j + i] =
                            (array[Convert.ToInt32(Math.Pow(2, k)) * j + i] + array[Convert.ToInt32(Math.Pow(2, k)) * (j + Convert.ToInt32(Math.Pow(2, powerOfTwo - k - 1))) + i]) / Math.Sqrt(2);

                        resultArray[Convert.ToInt32(Math.Pow(2, k)) * (2 * j + 1) + i] = CalcExp(k, j, powerOfTwo, inverse) *
                            (array[Convert.ToInt32(Math.Pow(2, k)) * j + i] - array[Convert.ToInt32(Math.Pow(2, k)) * (j + Convert.ToInt32(Math.Pow(2, powerOfTwo - k - 1))) + i]) / Math.Sqrt(2);
                    }
                }
            }
            return resultArray;
        }

        #endregion
    }
}
