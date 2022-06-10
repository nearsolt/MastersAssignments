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
        /// <param name="coeff">коэффициент масштабирования</param>
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
            Complex[] DFTArray = new Complex[numN];
            for (int j = 0; j < numN; j++) {
                for (int k = 0; k < numN; k++) {
                    DFTArray[j] += CalcExp(j, k, numN, inverse) * array[k];
                }
                DFTArray[j] /= inverse ? 1 : numN;
            }
            return DFTArray;
        }

        /// <summary>
        /// Вычисление функции f в точке
        /// </summary>
        /// <param name="value">точка</param>
        /// <returns></returns>
        private static double CalcFuncValues(double value) {
            return Math.Pow(value, 3) - value + 2;
        }

        /// <summary>
        /// Заполнение массива значений X
        /// </summary>
        /// <param name="arrayOfValuesX">массив значений x</param>
        /// <param name="numN">размерность массива</param>
        /// <param name="startOfInterval">начальное значение</param>
        /// <param name="endOfInterval">конечное значение</param>
        internal static void FillArrayOfValuesX(double[] arrayOfValuesX, int numN, double startOfInterval, double endOfInterval) {
            double xAxisStep = (endOfInterval - startOfInterval) / numN;
            arrayOfValuesX[0] = startOfInterval;
            arrayOfValuesX[numN - 1] = endOfInterval;
            for (int j = 1; j < numN - 1; j++) {
                arrayOfValuesX[j] = arrayOfValuesX[j - 1] + xAxisStep;
            }
        }

        /// <summary>
        /// Заполнение массива функции
        /// </summary>
        /// <param name="arrayOfValuesX">массив значений x</param>
        /// <param name="arrayOfFuncValues">массив функции</param>
        /// <param name="numN">размерность массива</param>
        internal static void FillArrayOfFuncValues(double[] arrayOfValuesX, double[] arrayOfFuncValues, int numN) {
            for (int j = 0; j < numN; j++) {
                arrayOfFuncValues[j] = CalcFuncValues(arrayOfValuesX[j]);
            }
        }

        /// <summary>
        /// Обнуление некоторого процента минимальных значений массива
        /// </summary>
        /// <param name="array">массив</param>
        /// <param name="numN">размерность массива</param>
        /// <param name="numOfZeroed">количество элементов для обнуления</param>
        internal static void ZeroingPercentageOfMinimumArrayValues(Complex[] array, int numN, int numOfZeroed) {
            Tuple<Complex, int>[] tupleArray = new Tuple<Complex, int>[numN];
            for (int j = 0; j < numN; j++) {
                tupleArray[j] = new Tuple<Complex, int>(array[j], j);
            }
            tupleArray = ((Tuple<Complex, int>[])tupleArray.Clone()).OrderBy(c => c.Item1.Magnitude).ToArray();
            #region debug
            //foreach (Tuple<Complex, int> item in tupleArray) {
            //    Console.Write($"({item.Item1.Real}, {item.Item1.Imaginary}), ");
            //}
            //Console.WriteLine($" - sorted array coeff");
            #endregion
            for (int j = 0; j < numOfZeroed; j++) {
                tupleArray[j] = new Tuple<Complex, int>((Complex)0, tupleArray[j].Item2);
            }    
            #region debug
            //foreach (Tuple<Complex, int> item in tupleArray) {
            //    Console.Write($"({item.Item1.Real}, {item.Item1.Imaginary}), ");
            //}
            //Console.WriteLine($" - sorted array coeff with numOfZeroed");
            #endregion
            tupleArray = ((Tuple<Complex, int>[])tupleArray.Clone()).OrderBy(c => c.Item2).ToArray();
            for (int j = 0; j < numN; j++) {
                array[j] = tupleArray[j].Item1;
            }
            #region debug
            //foreach (Complex item in array) {
            //    Console.Write($"({item.Real}, {item.Imaginary}), ");
            //}
            //Console.WriteLine($" - array coeff");
            #endregion
        }
    }
}
