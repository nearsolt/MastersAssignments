using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace HarmonicAnalysis.source {
    class FFTOldImplementation {
        #region task 1: FFT/IFFT OldImplementation

        /// <summary>
        /// Вычисление поворачивающего модуля e^(-i*2*PI*k/N) при прямом, e^(i*2*PI*k/N) при обратном
        /// </summary>
        /// <param name="k">индекс в цикле суммы</param>
        /// <param name="N">размерность массива</param>
        /// <param name="inverse">флаг: false - прямое преобразование, true - обратное</param>
        /// <returns></returns>
        static Complex W(int k, int N, bool inverse = false) {
            if (k % N == 0) {
                return 1;
            }
            double arg = 2 * Math.PI * k / N * (inverse ? 1 : -1);
            return new Complex(Math.Cos(arg), Math.Sin(arg));
        }

        /// <summary>
        /// Быстрое преобразование Фурье (прямое, если inverse = false; обратное, если inverse = true)
        /// </summary>
        /// <param name="x">массив значений сигнала</param>
        /// <param name="N">размерность массива, должно быть степенью 2</param>
        /// <param name="inverse">флаг: false - прямое преобразование, true - обратное</param>
        /// <returns>массив со значениями спектра сигнала</returns>
        internal static Complex[] FFT(Complex[] x, int N, bool inverse = false) {
            Complex[] X;

            if (N == 2) {
                X = new Complex[2];
                X[0] = x[0] + x[1];
                X[1] = x[0] - x[1];
            } else {
                Complex[] x_even = new Complex[N / 2];
                Complex[] x_odd = new Complex[N / 2];
                for (int i = 0; i < N / 2; i++) {
                    x_even[i] = x[2 * i];
                    x_odd[i] = x[2 * i + 1];
                }
                Complex[] X_even = FFT(x_even, N / 2, inverse);
                Complex[] X_odd = FFT(x_odd, N / 2, inverse);
                X = new Complex[N];
                for (int i = 0; i < N / 2; i++) {
                    X[i] = (X_even[i] + W(i, N, inverse) * X_odd[i]) * (inverse ? 2.0 / N : 1);
                    X[i + N / 2] = (X_even[i] - W(i, N, inverse) * X_odd[i]) * (inverse ? 2.0 / N : 1);
                }
            }
            return X;
        }

        /// <summary>
        /// Центровка массива значений полученных в FFT (спектральная составляющая при нулевой частоте будет в центре массива)
        /// </summary>
        /// <param name="X">массив значений, полученный в FFT</param>
        /// <returns></returns>
        internal static Complex[] NFFT(Complex[] X) {
            int N = X.Length;
            Complex[] X_n = new Complex[N];
            for (int i = 0; i < N / 2; i++) {
                X_n[i] = X[N / 2 + i];
                X_n[N / 2 + i] = X[i];
            }
            return X_n;
        }

        /// <summary>
        /// Проверка, является ли число степенью двойки (Decrement and Compare)
        /// </summary>
        /// <param name="num">вводимое число</param>
        /// <returns></returns>
        internal static bool IsPowerOfTwo(int num) {
            return (num != 0) && ((num & (num - 1)) == 0);
        }

        #endregion
    }
}
