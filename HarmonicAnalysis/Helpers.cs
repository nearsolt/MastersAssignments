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

        #region task 1: alternative

        internal static Complex[] FFTAl(Complex[] array) {
            int partitionsNumber = array.Length;
            int powerOfTwo = 0;
            if (IsPowerOfTwo(partitionsNumber)) {
                powerOfTwo = Convert.ToInt32(Math.Log(partitionsNumber, 2));
                Console.WriteLine($"{nameof(partitionsNumber)} = {partitionsNumber}, {nameof(powerOfTwo)} = {powerOfTwo}");
            }
            Complex[] tmp = new Complex[partitionsNumber];
            for (int k = 0; k < powerOfTwo; k++) {
                for (int i = 0; i < Convert.ToInt32(Math.Pow(2, k)); i++) {
                    for (int j = 0; j < Convert.ToInt32(Math.Pow(2, powerOfTwo - k - 1)); j++) {
                        tmp[Convert.ToInt32(Math.Pow(2.0, k)) * 2 * j + i] =
                            (array[Convert.ToInt32(Math.Pow(2.0, k)) * j + i] + array[Convert.ToInt32(Math.Pow(2.0, k)) * (j + Convert.ToInt32(Math.Pow(2.0, powerOfTwo - k - 1))) + i]) / Math.Sqrt(2.0);

                        tmp[Convert.ToInt32(Math.Pow(2.0, k)) * (2 * j + 1) + i] = CalcExp(k, j, powerOfTwo) *
                            (array[Convert.ToInt32(Math.Pow(2.0, k)) * j + i] - array[Convert.ToInt32(Math.Pow(2.0, k)) * (j + Convert.ToInt32(Math.Pow(2.0, powerOfTwo - k - 1))) + i]) / Math.Sqrt(2.0);

                    }
                }
            }
            return tmp;
        }


        static Complex CalcExp(int k, int j, int N) {
            double arg = -2.0 * Math.PI * j / Convert.ToInt32(Math.Pow(2.0, N - k));
            return new Complex(Math.Cos(arg), Math.Sin(arg));
        }

        internal static Complex[] IFFTAl(Complex[] array) {
            int partitionsNumber = array.Length;
            int powerOfTwo = 0;
            if (IsPowerOfTwo(partitionsNumber)) {
                powerOfTwo = Convert.ToInt32(Math.Log(partitionsNumber, 2));
                Console.WriteLine($"{nameof(partitionsNumber)} = {partitionsNumber}, {nameof(powerOfTwo)} = {powerOfTwo}");
            }
            Complex[] tmp = new Complex[partitionsNumber];
            for (int k = 0; k < powerOfTwo; k++) {
                for (int i = 0; i < Convert.ToInt32(Math.Pow(2, k)); i++) {
                    for (int j = 0; j < Convert.ToInt32(Math.Pow(2, powerOfTwo - k - 1)); j++) {
                        tmp[Convert.ToInt32(Math.Pow(2.0, k)) * 2 * j + i] =
                            (array[Convert.ToInt32(Math.Pow(2.0, k)) * j + i] + array[Convert.ToInt32(Math.Pow(2.0, k)) * (j + Convert.ToInt32(Math.Pow(2.0, powerOfTwo - k - 1))) + i]) / Math.Sqrt(2.0);

                        tmp[Convert.ToInt32(Math.Pow(2.0, k)) * (2 * j + 1) + i] = ICalcExp(k, j, powerOfTwo) *
                            (array[Convert.ToInt32(Math.Pow(2.0, k)) * j + i] - array[Convert.ToInt32(Math.Pow(2.0, k)) * (j + Convert.ToInt32(Math.Pow(2.0, powerOfTwo - k - 1))) + i]) / Math.Sqrt(2.0);

                    }
                }
            }
            return tmp;
        }


        static Complex ICalcExp(int k, int j, int N) {
            double arg = 2.0 * Math.PI * j / Convert.ToInt32(Math.Pow(2.0, N - k));
            return new Complex(Math.Cos(arg), Math.Sin(arg));
        }


        #endregion
    }
}
