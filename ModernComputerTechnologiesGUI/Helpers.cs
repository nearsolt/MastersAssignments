using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        #endregion
    }
}
