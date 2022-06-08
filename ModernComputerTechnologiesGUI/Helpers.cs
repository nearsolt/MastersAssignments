using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ModernComputerTechnologiesGUI {
    class Helpers {

        #region Initial data and filling arrays of values
        // Начало интервала
        private static double intervalStart = 5;
        // Конец интервала
        private static double intervalEnd = 10;

        /// <summary>
        /// Получение значения функции в точке
        /// </summary>
        /// <param name="value">точка</param>
        /// <returns></returns>
        private static double FuncValues(double value) {
            return Math.Sin(value);
        }

        /// <summary>
        /// Заполнение массива значений X
        /// </summary>
        /// <param name="arrayOfValuesX">массив значений X</param>
        /// <param name="n">число разбиений N</param>
        internal static void CalcArrayOfValuesX(double[] arrayOfValuesX, int n) {
            double xAxisStep = (intervalEnd - intervalStart) / n;
            arrayOfValuesX[0] = intervalStart;
            arrayOfValuesX[n] = intervalEnd;

            for (int j = 1; j < n; j++) {
                arrayOfValuesX[j] = arrayOfValuesX[0] + j * xAxisStep;
            }
        }
        /// <summary>
        /// Заполнение массива функции
        /// </summary>
        /// <param name="arrayOfValuesX">массив значений X</param>
        /// <param name="arrayOfFunctions">массив функции</param>
        /// <param name="n">число разбиений N</param>
        internal static void CalcArrayOfFunctions(double[] arrayOfValuesX, double[] arrayOfFunctions, int n) {
            for (int j = 0; j < n + 1; j++) {
                arrayOfFunctions[j] = FuncValues(arrayOfValuesX[j]);
            }
        }
        #endregion

        #region 

        /// <summary>
        /// Построение матрицы А, элементы которой e^(2*pi*i*j*k/N), система дискретных экспоненциальных функций (ДЭФ)
        /// </summary>
        /// <param name="matrixA">матрица A</param>
        /// <param name="n">число разбиений N</param>
        internal static void BuildMatrixA(Complex[,] matrixA, int n) {

            for (int j = 0; j < n + 1; j++) {
                for (int k = 0; k < n + 1; k++) {
                    double arg = 2 * Math.PI * j * k / n;
                    matrixA[j, k] = new Complex(Math.Cos(arg), Math.Sin(arg));
                }
            }
        }

        internal static void CalcCoeffC(Complex[] arrayOfCoeffC, Complex[,] matrixA, Complex[] arrayOfFunctions, int n){

            for (int j = 0; j < n + 1; j++) {
                for (int k = 0; k < n + 1; k++) {

                    //arrayOfCoeffC[j] += arrayOfFunctions[k] * matrixA[j, k];
                    bool inverse = false;
                    double arg = 2 * Math.PI * j * k / n * (inverse ? 1 : -1);
                    Complex qw = new Complex(Math.Cos(arg), Math.Sin(arg));
                    arrayOfCoeffC[j] += arrayOfFunctions[k] * qw;
                }
                arrayOfCoeffC[j] /= Math.Sqrt(n);
            }
        }

        internal static double[] Multiplication(Complex[] arrayOfCoeffC, Complex[,] matrixA,  int n) {
            Complex[] moF = new Complex[n + 1];
            double[] moFReal = new double[n + 1];
            for (int j = 0; j < n + 1; j++) {
                for (int k = 0; k < n + 1; k++) {
                    bool inverse = true;
                    double arg = 2 * Math.PI * j * k / n * (inverse ? 1 : -1);
                    Complex qw = new Complex(Math.Cos(arg), Math.Sin(arg));
                    moF[j] += arrayOfCoeffC[k] * qw;
                    //moF[j] += arrayOfCoeffC[k] * qq;
                }
                moF[j] /= Math.Sqrt(n);
                moFReal[j] = moF[j].Real;
            }

            return moFReal;
        }

        #endregion
    }
}
