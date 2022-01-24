using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernComputerTechnologies {
    class Task3 {

        /// <summary>
        /// Алгоритм обхода змейкой, заполнение из матрицы в массив
        /// </summary>
        /// <param name="matrix">матрица</param>
        /// <param name="array">массив</param>
        internal static void SnakeAlgorithmMatrixToArray(int[,] matrix, int[] array) {

            int matrixLengthOx_1 = matrix.GetLength(0);
            int matrixLengthOx_2 = matrix.GetLength(1);
            int arrayLength = array.Length;

            // index - стартовый индекс массива
            int index = 0;
            //маркеры для строк и столбцов
            int row = 0;
            int col = 0;

            array[index++] = matrix[row, col];

            while (index < arrayLength) {
                if (col < matrixLengthOx_2 - 1) {
                    col++;
                } else {
                    row++;
                }

                while (row < matrixLengthOx_1 && col >= 0) {
                    array[index++] = matrix[row, col];
                    row++;
                    col--;
                }
                row--;
                col++;

                if (row < matrixLengthOx_1 - 1) {
                    row++;
                } else {
                    col++;
                }

                while (row >= 0 && col < matrixLengthOx_2) {
                    array[index++] = matrix[row, col];
                    row--;
                    col++;
                }
                row++;
                col--;
            }
        }

        /// <summary>
        /// Алгоритм обхода змейкой, заполнение из массива в матрицу
        /// </summary>
        /// <param name="matrix">матрица</param>
        /// <param name="array">массив</param>
        internal static void SnakeAlgorithmArrayToMaxrix(int[,] matrix, int[] array) {

            int matrixLengthOx_1 = matrix.GetLength(0);
            int matrixLengthOx_2 = matrix.GetLength(1);
            int arrayLength = array.Length;

            //маркеры для строк и столбцов
            int row = 0;
            int col = 0;
            // шаги по строкам, столбцам
            int stepRow = 0;
            int stepCol = 1;
            matrix[0, 0] = array[0];

            for (int i = 1; i < arrayLength; i++) {
                row += stepRow;
                col += stepCol;
                matrix[row, col] = array[i];

                // варианты направлений
                if (col == 0 && stepRow == 1 && stepCol == -1 && row != matrixLengthOx_1 - 1) {
                    stepRow = 1;
                    stepCol = 0;
                    continue;
                }
                if (row == 0 && stepRow == -1 && stepCol == 1 && col != matrixLengthOx_2 - 1) {
                    stepRow = 0;
                    stepCol = 1;
                    continue;
                }
                if (col == matrixLengthOx_2 - 1 && stepRow == -1 && stepCol == 1) {
                    stepRow = 1;
                    stepCol = 0;
                    continue;
                }
                if (row == matrixLengthOx_1 - 1 && stepRow == 1 && stepCol == -1) {
                    stepRow = 0;
                    stepCol = 1;
                    continue;
                }

                if ((row == matrixLengthOx_1 - 1 && stepRow == 0) || (col == 0 && stepCol == 0)) {
                    stepRow = -1;
                    stepCol = 1;
                    continue;
                }
                if ((col == matrixLengthOx_2 - 1 && stepCol == 0) || (row == 0 && stepRow == 0)) {
                    stepRow = 1;
                    stepCol = -1;
                    continue;
                }
            }
        }

        /// <summary>
        /// Алгоритм обхода по спирали, заполнение из матрицы в массив
        /// </summary>
        /// <param name="matrix">матрица</param>
        /// <param name="array">массив</param>
        internal static void SpiralAlgorithmMaxrixToArray(int[,] matrix, int[] array) {

            // top, bottom - стартовый и конечный индексы строк матрицы
            int top = 0;
            int bottom = matrix.GetLength(0) - 1;
            // left, right - стартовый и конечный индексы столбцов матрицы
            int left = 0;
            int right = matrix.GetLength(1) - 1;
            // index - стартовый индекс массива
            int index = 0;

            while (top <= bottom && left <= right) {

                for (int i = left; i <= right; i++) {
                    array[index++] = matrix[top, i];
                }
                top++;

                for (int i = top; i <= bottom; i++) {
                    array[index++] = matrix[i, right];
                }
                right--;

                if (top <= bottom) {
                    for (int i = right; i >= left; i--) {
                        array[index++] = matrix[bottom, i];
                    }
                    bottom--;
                }

                if (left <= right) {
                    for (int i = bottom; i >= top; i--) {
                        array[index++] = matrix[i, left];
                    }
                    left++;
                }
            }
        }

        /// <summary>
        /// Алгоритм обхода по спирали, заполнение из массива в матрицу
        /// </summary>
        /// <param name="matrix">матрица</param>
        /// <param name="array">массив</param>
        internal static void SpiralAlgorithmArrayToMaxrix(int[,] matrix, int[] array) {

            // top, bottom - стартовый и конечный индексы строк матрицы
            int top = 0;
            int bottom = matrix.GetLength(0) - 1;
            // left, right - стартовый и конечный индексы столбцов матрицы
            int left = 0;
            int right = matrix.GetLength(1) - 1;
            // index - стартовый индекс массива
            int index = 0;

            while (true) {

                if (left > right) {
                    break;
                }
                for (int i = left; i <= right; i++) {
                    matrix[top, i] = array[index++];
                }
                top++;

                if (top > bottom) {
                    break;
                }
                for (int i = top; i <= bottom; i++) {
                    matrix[i, right] = array[index++];
                }
                right--;

                if (left > right) {
                    break;
                }
                for (int i = right; i >= left; i--) {
                    matrix[bottom, i] = array[index++];
                }
                bottom--;

                if (top > bottom) {
                    break;
                }
                for (int i = bottom; i >= top; i--) {
                    matrix[i, left] = array[index++];
                }
                left++;
            }
        }
    }
}
