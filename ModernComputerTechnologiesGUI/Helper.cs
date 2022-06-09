using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ModernComputerTechnologiesGUI {
    class Helper {

        /// <summary>
        /// Random-генерация отсортированного по Re массива комплексных чисел, диапазон Re и Im от 0 до coeff
        /// </summary>
        /// <param name="numN">размерность массива</param>
        /// <param name="coeff">коэффициент</param>
        internal static Complex[] GenerateSortedComplexNumArray(int numN, int coeff) {
            Complex[] sortedArrayOfComplexNum = new Complex[numN];
            Random random = new Random();
            for (int j = 0; j < numN; j++) {
                sortedArrayOfComplexNum[j] = 
                    new Complex(Math.Round(random.NextDouble() * coeff, 2, MidpointRounding.AwayFromZero), Math.Round(random.NextDouble() * coeff, 2, MidpointRounding.AwayFromZero));
            }
            return sortedArrayOfComplexNum.OrderBy(c => c.Real).ToArray();
        }


        /// <summary>
        /// Вычисление  e^(-2*pi*i/N * j*k) при прямом, e^(2*pi*i/N * j*k) при обратном
        /// </summary>
        /// <param name="j">индекс j</param>
        /// <param name="k">индекс k</param>
        /// <param name="N">размерность массива</param>
        /// <param name="inverse">флаг: false - прямое преобразование, true - обратное</param>
        /// <returns></returns>
        private static Complex CalcExp(int j, int k, int N, bool inverse = false) {
            double arg = 2 * Math.PI * j * k / N * (inverse ? 1 : -1);
            return new Complex(Math.Cos(arg), Math.Sin(arg));
        }
        /// <summary>
        /// Дискретное преобразование Фурье: 
        /// при прямом      c_j = 1/N \sum_{k=0}^{N-1} e^(-2*pi*i/N * j*k) * f_k
        /// при обратном    f_k = \sum_{j=0}^{N-1} e^(2*pi*i/N * j*k) * c_j
        /// </summary>
        /// <param name="array">массив</param>
        /// <param name="numN">размерность массива</param>
        /// <param name="inverse">флаг: false - прямое преобразование, true - обратное</param>
        /// <returns></returns>
        internal static Complex[] DFT(Complex[] array, int numN, bool inverse = false) {

            Complex[] FTArray = new Complex[numN];
            for (int j = 0; j < numN; j++) {
                for (int k = 0; k < numN; k++) {
                    FTArray[j] += CalcExp(j, k, numN, inverse) * array[k];
                }
                FTArray[j] /= inverse ? 1 : numN;
            }
            return FTArray;
        }

        /// <summary>
        /// Инициализация функции f
        /// </summary>
        /// <param name="value">точка</param>
        /// <returns></returns>
        private static double FuncValues(double value) {
            //return Math.Sin(value);
            return Math.Pow(value,3)-3*value;
        }

        /// <summary>
        /// Заполнение массива значений X
        /// </summary>
        /// <param name="arrayOfValuesX">массив значений x</param>
        /// <param name="numN">размерность массива</param>
        /// <param name="startOfInterval">начальное значение</param>
        /// <param name="endOfInterval">конечное значение</param>
        internal static void CalcArrayOfValuesX(double[] arrayOfValuesX, int numN, double startOfInterval, double endOfInterval) {
            double xAxisStep = (endOfInterval - startOfInterval) / numN;
            arrayOfValuesX[0] = startOfInterval;
            arrayOfValuesX[numN-1] = endOfInterval;

            for (int j = 1; j < numN-1; j++) {
                arrayOfValuesX[j] = arrayOfValuesX[0] + j * xAxisStep;
            }
        }
        /// <summary>
        /// Заполнение массива функции
        /// </summary>
        /// <param name="arrayOfValuesX">массив значений x</param>
        /// <param name="arrayOfFunctions">массив функции</param>
        /// <param name="numN">размерность массива</param>
        internal static void CalcArrayOfFuncValues(double[] arrayOfValuesX, double[] arrayOfFunctions, int numN) {
            for (int j = 0; j < numN; j++) {
                arrayOfFunctions[j] = FuncValues(arrayOfValuesX[j]);
            }
        }

        
        
        
        
        #region Junk

        ///// <summary>
        ///// Построение матрицы А, элементы которой e^(2*pi*i*/N * j*k), система дискретных экспоненциальных функций (ДЭФ)
        ///// </summary>
        ///// <param name="matrixA">матрица A</param>
        ///// <param name="n">число разбиений N</param>
        // static void BuildMatrixA(Complex[,] matrixA, int numN) {

        //    for (int j = 0; j < numN; j++) {
        //        for (int k = 0; k < numN; k++) {
        //           // double arg = 2 * Math.PI * j * k / numN * ;
        //            //matrixA[j, k] = new Complex(Math.Cos(arg), Math.Sin(arg));
        //        }
        //    }
        //}

        ////// Начало интервала
        ////private static double intervalStart = 5;
        ////// Конец интервала
        ////private static double intervalEnd = 10;

        

        
        //#endregion

        //#region 

        

        // static void CalcCoeffC(Complex[] arrayOfCoeffC, Complex[,] matrixA, Complex[] arrayOfFunctions, int n) {

        //    for (int j = 0; j < n + 1; j++) {
        //        for (int k = 0; k < n + 1; k++) {

        //            //arrayOfCoeffC[j] += arrayOfFunctions[k] * matrixA[j, k];
        //            bool inverse = false;
        //            double arg = 2 * Math.PI * j * k / n * (inverse ? 1 : -1);
        //            Complex qw = new Complex(Math.Cos(arg), Math.Sin(arg));
        //            arrayOfCoeffC[j] += arrayOfFunctions[k] * qw;
        //        }
        //        arrayOfCoeffC[j] /= Math.Sqrt(n);
        //    }
        //}

        //internal static double[] Multiplication(Complex[] arrayOfCoeffC, Complex[,] matrixA, int n) {
        //    Complex[] moF = new Complex[n + 1];
        //    double[] moFReal = new double[n + 1];
        //    for (int j = 0; j < n + 1; j++) {
        //        for (int k = 0; k < n + 1; k++) {
        //            bool inverse = true;
        //            double arg = 2 * Math.PI * j * k / n * (inverse ? 1 : -1);
        //            Complex qw = new Complex(Math.Cos(arg), Math.Sin(arg));
        //            moF[j] += arrayOfCoeffC[k] * qw;
        //            //moF[j] += arrayOfCoeffC[k] * qq;
        //        }
        //        moF[j] /= Math.Sqrt(n);
        //        moFReal[j] = moF[j].Real;
        //    }

        //    return moFReal;
        //}

        #endregion
    }
}
