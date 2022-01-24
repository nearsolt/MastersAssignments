using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;

namespace HarmonicAnalysis {
    class DFF {


        /// <summary> 
        /// Коэффициенты 
        /// </summary> 
        public List<Complex> koeffs;

        /// <summary> 
        /// Количество точек, которые закодированы в данном ДПФ 
        /// </summary> 
        public double K;

        public DFF() {
            koeffs = new List<Complex>();
        }

        /// <summary> 
        /// Выполнить дискретное преобразование Фурье 
        /// </summary> 
        /// <param name="points">Точки контура</param> 
        /// <param name="count">Количество коэффициентов</param> 
        public void dpf(List<Point> points, int count) {
            koeffs.Clear();
            K = points.Count;

            //Цикл вычисления коэффициентов 
            for (int u = 0; u < count; u++) {
                //цикл суммы 
                Complex summa = new Complex();
                for (int k = 0; k < K; k++) {
                    Complex S = new Complex(points[k].X, points[k].Y);
                    double koeff = -2 * Math.PI * u * k / K;
                    Complex e = new Complex(Math.Cos(koeff), Math.Sin(koeff));
                    summa += (S * e);
                }
                koeffs.Add(summa / K);
            }
        }

        /// <summary> 
        /// Обратное преобразование Фурье 
        /// </summary> 
        /// <returns>Точки</returns> 
        public List<Complex> undpf() {
            List<Complex> res = new List<Complex>();
            for (int k = 0; k < K; k++) {
                Complex summa = new Complex();
                for (int u = 0; u < koeffs.Count; u++) {
                    double koeff = 2 * Math.PI * u * k / K;
                    Complex e = new Complex(Math.Cos(koeff), Math.Sin(koeff));
                    summa += (koeffs[u] * e);
                }
                res.Add(summa);
            }
            return res;
        }
        /*
        static void Main(string[] args) {
            var points = new List<Point>() { new Point(10, 0), new Point(2, 4), new Point(3, -3) };
            var f = new DFF();
            f.dpf(points, points.Count);
            var points2 = f.undpf();
            foreach (var p in points2)
                Console.WriteLine("{0:n1}, {1:n1}", p.Real, p.Imaginary);
            Console.ReadLine();
        }
        */

    }
}