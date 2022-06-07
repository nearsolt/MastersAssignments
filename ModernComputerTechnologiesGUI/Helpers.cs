using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernComputerTechnologiesGUI {
    class Helpers {

        #region Initial Data

        /// <summary>
        /// Получение значения функции в точке
        /// </summary>
        /// <param name="value">точка</param>
        /// <returns></returns>
        internal static double FuncValues(double value) {
            return Math.Sin(value)+1;              
        }


        internal static Tuple<List<double>, List<double>> Calc(int n) {
            //int n = 5;
            List<double> x = new List<double>();
            List<double> f = new List<double>();

            for (int i = 0; i < n; i++) {
                x.Add(i);
                f.Add(Helpers.FuncValues(i));
            }
            return new Tuple<List<double>, List<double>>(x,f);
        }

        #endregion
    }
}
