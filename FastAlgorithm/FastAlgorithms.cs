using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAlgorithms {
    class FastAlgorithms {
        static void Main(string[] args) {

            #region task 1: Fast Haar Wavelet Transform/Fast Inverse Haar Wavelet Transform Main

            //double[] initialArray = new double[] { 10.6, 5.8, 24.5, 6.5, 4.7, 13.7, 1.6, 9.6 };
            //double[] initialArray = new double[] { 7, 3, 4, 10 };
            double[] initialArray = new double[] { 6, 12, 15, 15, 14, 12, 120, 116 };
            int partitionsNumber = initialArray.Length;

            if (partitionsNumber == 1) {
                Console.WriteLine($"Количество элементов массива {nameof(initialArray)} равно 1, введите корректные данные");
                Console.ReadKey();
                return;
            }
            if (!Helpers.IsPowerOfTwo(partitionsNumber)) {
                Console.WriteLine($"Количество элементов массива {nameof(initialArray)} равно {partitionsNumber}, что не является степенью двойки, введите корректные данные");
                Console.ReadKey();
                return;
            }
            int powerOfTwo = Convert.ToInt32(Math.Log(partitionsNumber, 2));
            
            Console.WriteLine($"Входные значения ({nameof(initialArray)}):\n{string.Join(", ", initialArray.ToArray())}.\n");

            double[] inPlaceFHWTArray = Helpers.InPlaceFHWT((double[])initialArray.Clone(), powerOfTwo);
            Console.WriteLine($"Значения, полученные после БПХ ({nameof(inPlaceFHWTArray)}):\n{string.Join(", ", inPlaceFHWTArray.ToArray())}.\n");

            double[] inPlaceFIHWTArray = Helpers.InPlaceFIHWT((double[])inPlaceFHWTArray.Clone(), powerOfTwo);
            Console.WriteLine($"Значения, полученные после обратного БПХ ({nameof(inPlaceFIHWTArray)}):\n{string.Join(", ", inPlaceFIHWTArray.ToArray())}.\n");

            double[] orderedFHWTArray = Helpers.OrderedFHWT((double[])initialArray.Clone(), powerOfTwo);
            Console.WriteLine($"Значения, полученные после БПХ ({nameof(orderedFHWTArray)}):\n{string.Join(", ", orderedFHWTArray.ToArray())}.\n");

            double[] orderedFIHWTArray = Helpers.OrderedFIHWT((double[])orderedFHWTArray.Clone(), powerOfTwo);
            Console.WriteLine($"Значения, полученные после обратного БПХ ({nameof(orderedFIHWTArray)}):\n{string.Join(", ", orderedFIHWTArray.ToArray())}.\n");

            #endregion

            Console.ReadLine();


        }
    }
}
