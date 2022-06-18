using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveletAnalysis {
    class Program {
        static void Main(string[] args) {
            double[] initialArray = new double[] { 6, 12, 15, 15, 14, 12, 120, 116 };
            int numberN = initialArray.Length;

            if (numberN == 1) {
                Console.WriteLine($"Количество элементов массива {nameof(initialArray)} равно 1, введите корректные данные");
                Console.ReadKey();
                return;
            }
            if (!Helper.IsPowerOfTwo(numberN)) {
                Console.WriteLine($"Количество элементов массива {nameof(initialArray)} равно {numberN}, что не является степенью двойки, введите корректные данные");
                Console.ReadKey();
                return;
            }
            int powerOfTwo = Convert.ToInt32(Math.Log(numberN, 2));

            Console.WriteLine($"Входные значения ({nameof(initialArray)}):\n{string.Join(", ", initialArray.ToArray())}.\n");

            double[] orderedFHWTArray = Helper.OrderedFHWT((double[])initialArray.Clone(), powerOfTwo);
            Console.WriteLine($"Значения, полученные после БПХ ({nameof(orderedFHWTArray)}):\n{string.Join(", ", orderedFHWTArray.ToArray())}.\n");

            double[] orderedFIHWTArray = Helper.OrderedFIHWT((double[])orderedFHWTArray.Clone(), powerOfTwo);
            Console.WriteLine($"Значения, полученные после обратного БПХ ({nameof(orderedFIHWTArray)}):\n{string.Join(", ", orderedFIHWTArray.ToArray())}.\n");

            Console.ReadLine();
        }
    }
}
