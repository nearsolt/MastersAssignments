using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace HarmonicAnalysis {
    class HarmonicAnalysis {

        #region task 1: FFT/IFFT Main
        static void Main(string[] args) {

            Complex[] initialArray = new Complex[] { new Complex(10, 0), new Complex(2, 4), new Complex(3, -3), new Complex(7, -2),
                                                    new Complex(4, -1), new Complex(6, 2), new Complex(3, -9), new Complex(-5, 8) };

            if (!Helpers.IsPowerOfTwo(initialArray.Length)) {
                Console.WriteLine($"Количество элементов массива {nameof(initialArray)} равно {initialArray.Length}, что не является степенью двойки, введите корректные данные");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Входные значения ({nameof(initialArray)}):\n{string.Join(" ,", initialArray.ToArray())}\n");

            Complex[] FFTArray = Helpers.FFT((Complex[])initialArray.Clone());
            Console.WriteLine($"Значения, полученные после БПФ ({nameof(FFTArray)}):\n{string.Join(" ,", FFTArray.ToArray())}\n");

            Complex[] IFFTArray = Helpers.FFT((Complex[])FFTArray.Clone(), true);
            Console.WriteLine($"Значения, полученные после обратного БПФ ({nameof(IFFTArray)}):\n{string.Join(" ,", IFFTArray.ToArray())}\n");

            Console.ReadLine();
        }
        #endregion
    }
}
