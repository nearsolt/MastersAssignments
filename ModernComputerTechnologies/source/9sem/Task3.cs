using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernComputerTechnologies {
    class Task3 {

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


            

            /* k - starting row index            m - ending row index            l - starting column index            n - ending column index            i - iterator            */

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
