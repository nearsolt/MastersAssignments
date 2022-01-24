using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernComputerTechnologies.tests {
    class Tests {

        #region  Old Implementation
        
        /// <summary>
        /// Алгоритм обхода змейкой, заполнение из матрицы в массив неоптимальное решение алгоритма
        /// </summary>
        /// <param name="matrix">матрица</param>
        /// <param name="array">массив</param>
        internal static void SnakeAlgorithmMatrixToArray(int[,] matrix, int[] array) {

            int matrixLengthOx_1 = matrix.GetLength(0);
            int matrixLengthOx_2 = matrix.GetLength(1);

            // index - стартовый индекс массива
            int index = 0;
            //маркеры для строк и столбцов
            int row = 0;
            int col = 0;

            // флаг true - увеличение значения для строки, false - для столбца
            bool row_inc = false;

            int min = Math.Min(matrixLengthOx_1, matrixLengthOx_2);
            for (int len = 1; len <= min; len++) {
                for (int i = 0; i < len; i++) {
                    array[index++] = matrix[row, col];
                    //Console.Write($"{matrix[row, col]} ");

                    if (i + 1 == len)
                        break;

                    if (row_inc) {
                        row++;
                        col--;
                    } else {
                        row--;
                        col++;
                    }
                }

                if (len == min)
                    break;

                if (row_inc) {
                    row++;
                    row_inc = false;
                } else {
                    col++;
                    row_inc = true;
                }
            }

            if (row == 0) {
                if (col == matrixLengthOx_2 - 1)
                    row++;
                else
                    col++;
                row_inc = true;
            } else {
                if (row == matrixLengthOx_1 - 1)
                    col++;
                else
                    row++;
                row_inc = false;
            }

            int max = Math.Max(matrixLengthOx_1, matrixLengthOx_2) - 1;
            for (int len, diag = max; diag > 0; diag--) {

                if (diag > min)
                    len = min;
                else
                    len = diag;

                for (int i = 0; i < len; i++) {
                    array[index++] = matrix[row, col];
                    //Console.Write($"{matrix[row, col]} ");

                    if (i + 1 == len)
                        break;

                    if (row_inc) {
                        row++;
                        col--;
                    } else {
                        col++;
                        row--;
                    }
                }

                if (row == 0 || col == matrixLengthOx_2 - 1) {
                    if (col == matrixLengthOx_2 - 1)
                        row++;
                    else
                        col++;

                    row_inc = true;
                } else if (col == 0 || row == matrixLengthOx_1 - 1) {
                    if (row == matrixLengthOx_1 - 1)
                        col++;
                    else
                        row++;

                    row_inc = false;
                }
            }
        }


        #endregion
    }

}
