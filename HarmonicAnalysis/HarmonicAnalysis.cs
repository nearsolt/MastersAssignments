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
                Console.WriteLine(string.Format("Количество элементов массива {0} равно {1}, что не является степенью двойки, введите корректные данные",
                                                nameof(initialArray), initialArray.Length));
                Console.ReadKey();
                return;
            }
            Console.WriteLine(string.Format("Входные значения ({0}): {1}{2}{1}",
                                                nameof(initialArray), Environment.NewLine, string.Join(" ,", initialArray.ToArray())));


            Complex[] FFTArray = Helpers.FFT((Complex[])initialArray.Clone(), initialArray.Length);
            Console.WriteLine(string.Format("Значения, полученные после быстрого преобразования Фурье ({0}): {1}{2}{1}",
                                                nameof(FFTArray), Environment.NewLine, string.Join(" ,", FFTArray.ToArray())));

            /*Complex[] IFFTArray = Helpers.FFT(FFTArray, FFTArray.Length, true);
            Console.WriteLine(string.Format("Значения, полученные после обратного быстрого преобразования Фурье ({0}): {1}{2}{1}",
                                                nameof(IFFTArray), Environment.NewLine, string.Join(" ,", IFFTArray.ToArray())));
            */


            Complex[] FFTAlArray = Helpers.FFTAl((Complex[])initialArray.Clone());

            Console.WriteLine(string.Format("Значения, полученные после быстрого преобразования Фурье ({0}): {1}{2}{1}",
                                               nameof(FFTAlArray), Environment.NewLine, string.Join(" ,", FFTAlArray.ToArray())));


            Complex[] IFFTAlArray = Helpers.IFFTAl((Complex[])FFTAlArray.Clone());

            Console.WriteLine(string.Format("Значения, полученные после обратного быстрого преобразования Фурье ({0}): {1}{2}{1}",
                                                nameof(IFFTAlArray), Environment.NewLine, string.Join(" ,", IFFTAlArray.ToArray())));

            Console.ReadLine();
        }
        #endregion
    }
}
