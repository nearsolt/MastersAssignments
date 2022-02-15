using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHarmonicAnalysis {
    class Helpers {

        #region task 1: Walsh

        #region Initial Data

        /// <summary>
        /// Получение значения функции в точке
        /// </summary>
        /// <param name="value">точка</param>
        /// <returns></returns>
        static double FuncValues(double value) {
            return Math.Pow(value, 2.0) + value * 0.2 - 3.5;
        }

        #endregion

        /// <summary>
        /// Получение значений массива на delta_j^n,(lambda_j^n = f(delta)) j=0,2^n-1
        /// </summary>
        /// <param name="partitionsNumber">количество разбиений интервала</param>
        /// <param name="start">начало интервала</param>
        /// <param name="end">конец интервала</param>
        /// <returns></returns>
        static double[] DeltaValues(int partitionsNumber, double start, double end) {
            double step = (end - start) / partitionsNumber;
            double[] intervalSplit = new double[partitionsNumber + 1];
            double[] funcValues = new double[partitionsNumber];

            intervalSplit[0] = start;
            intervalSplit[partitionsNumber] = end;

            for (int i = 1; i < partitionsNumber; i++) {
                intervalSplit[i] = intervalSplit[0] + i * step;
            }

            for (int i = 0; i < partitionsNumber; i++) {
                funcValues[i] = FuncValues((intervalSplit[i] + intervalSplit[i + 1]) * 0.5);
            }

            return funcValues;
        }

        /// <summary>
        /// Вычисление матрицы Уолша в представлении Пэли
        /// </summary>
        /// <param name="walshMatrix">матрица Уолша</param>
        /// <param name="powerOfTwo">степерь размерности по основанию 2</param>
        /// <param name="partitionsNumber">размерность матрицы Уолша</param>
        internal static void CalcWalshMatrix(int[,] walshMatrix, int powerOfTwo, int partitionsNumber) {
            int[] w_0_Vector = Enumerable.Repeat(1, partitionsNumber).ToArray();

            int[,] rMatrix = new int[powerOfTwo, partitionsNumber];

            for (int i = 0; i < powerOfTwo; i++) {
                for (int j = 0; j < partitionsNumber; j++) {
                    rMatrix[i, j] = Convert.ToInt32(Math.Pow(-1, j / Convert.ToInt32(Math.Pow(2, powerOfTwo - i - 1))));
                }
            }

            if (powerOfTwo > 0) {
                for (int j = 0; j < partitionsNumber; j++) {
                    walshMatrix[0, j] = w_0_Vector[j];
                }
                for (int k = 1; k <= powerOfTwo; k++) {
                    for (int i = Convert.ToInt32(Math.Pow(2, k - 1)); i < Convert.ToInt32(Math.Pow(2, k)); i++) {
                        for (int j = 0; j < partitionsNumber; j++) {
                            walshMatrix[i, j] = walshMatrix[i - Convert.ToInt32(Math.Pow(2, k - 1)), j] * rMatrix[k - 1, j];
                        }
                    }
                }
            } else {
                walshMatrix[0, 0] = w_0_Vector[0];
            }
        }

        /// <summary>
        /// Вывод матрицы Уолша
        /// </summary>
        /// <param name="walshMatrix">матрица Уолша</param>
        /// <param name="partitionsNumber">размерность матрицы Уолша</param>
        internal static void PrintWalshMatrix(int[,] walshMatrix, int partitionsNumber) {
            Console.WriteLine($"Матрица Уолша, Mat:{partitionsNumber}x{partitionsNumber}, имеет вид:\n");
            for (int i = 0; i < partitionsNumber; i++, Console.WriteLine("")) {
                for (int j = 0; j < partitionsNumber; j++, Console.Write("\t")) {
                    Console.Write(walshMatrix[i, j].ToString());
                }
            }
        }

        /// <summary>
        /// Вычисление коэффициентов разложения
        /// </summary>
        /// <param name="walshMatrix">матрица Уолша</param>
        /// <param name="partitionsNumber">размерность матрицы Уолша</param>
        /// <param name="start">начало интервала</param>
        /// <param name="end">конец интервала</param>
        /// <returns></returns>
        internal static double[] CalcCoeff(int[,] walshMatrix, int partitionsNumber, double start, double end) {
            double[] coeff = new double[partitionsNumber];
            double[] deltaValues = DeltaValues(partitionsNumber, start, end);
            for (int i = 0; i < partitionsNumber; i++) {
                for (int j = 0; j < partitionsNumber; j++) {
                    coeff[i] += deltaValues[j] * walshMatrix[i, j] * 1.0;
                }
                coeff[i] /= partitionsNumber;
            }
            return coeff;
        }

        #endregion
    }
}

