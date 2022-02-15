using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHarmonicAnalysis {
    class BinaryHarmonicAnalysis {

        #region task 1: Walsh Main
        static void Main(string[] args) {

            int powerOfTwo = 3;
            double start = 1, end = 33;

            if (powerOfTwo < 0) {
                Console.WriteLine($"Степень числа не может быть отрицательной: {nameof(powerOfTwo)} = {powerOfTwo}, введите корректные данные");
                Console.ReadKey();
                return;
            }

            int partitionsNumber = Convert.ToInt32(Math.Pow(2, powerOfTwo));

            int[,] walshMatrix = new int[partitionsNumber, partitionsNumber];

            Helpers.CalcWalshMatrix(walshMatrix, powerOfTwo, partitionsNumber);
            Helpers.PrintWalshMatrix(walshMatrix, partitionsNumber);

            double[] coeff = Helpers.CalcCoeff(walshMatrix, partitionsNumber, start, end);

            Console.WriteLine($"\nКоэффициенты разложения имеют следующий вид:\n");
            for (int i = 0; i < partitionsNumber; i++) {
                Console.WriteLine($"coeff({i}) = {coeff[i]}");
            }
            Console.ReadKey();
        }

        #endregion
    }
}
