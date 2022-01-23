using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernComputerTechnologies {
    class Helpers {

        /// <summary>
        /// Рандомное заполение массива, диапазон от 0 до arrayLength * 25
        /// </summary>
        /// <param name="array">массив</param>
        /// <param name="arrayLength">длина массива</param>
        internal static void FillRandom(int[] array, int arrayLength) {
            Random randNum = new Random();
            int maxValue = arrayLength * 25;
            for (int i = 0; i < arrayLength; i++) {
                array[i] = randNum.Next(0, maxValue);
            }
        }

        /// <summary>
        /// Рандомное заполение массива, диапазон от 0 до arrayLength * 2
        /// </summary>
        /// <param name="array">массив</param>
        internal static void FillRandom_x2(int[] array) {
            Random randNum = new Random();
            int maxValue = array.Length * 2;
            for (int i = 0; i < array.Length; i++) {
                array[i] = randNum.Next(0, maxValue);
            }
        }

        /// <summary>
        /// Заполнение массива последовательностью чисел i=0, array.Length - 1
        /// </summary>
        /// <param name="array">массив</param>
        internal static void FillArrayWithSequence(int[] array) {
            for (int i = 0; i < array.Length; i++) {
                array[i] = i;
            }
        }

        /// <summary>
        /// Вывод массива в консоль
        /// </summary>
        /// <param name="array">массив</param>
        internal static void PrintArray(int[] array) {
            for (int i = 0; i < array.Length; i++) {
                Console.Write($"{array[i]}  ");
            }
        }

        /// <summary>
        /// Вывод матрицы в консоль
        /// </summary>
        /// <param name="matrix">матрица</param>
        internal static void PrintMatrix(int[,] matrix) {
            for (int i = 0; i < matrix.GetLength(0); i++, Console.WriteLine("")) {
                for (int j = 0; j < matrix.GetLength(1); j++) {
                    Console.Write($"{matrix[i, j]}\t");
                }
            }
        }

    }
}
