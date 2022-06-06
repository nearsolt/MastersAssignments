using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernComputerTechnologiesGUI {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //int n = 5;
            //List<double> x = new List<double>();
            //List<double> f = new List<double>();

            //for(int i = 0; i <= n; i++) {
            //    x.Add(i);
            //    f.Add(Helpers.FuncValues(i));
            //}
            //Console.WriteLine($"x: {string.Join(", ", x.ToList())}\n f: {string.Join(", ", f.ToList())}");
            //Console.ReadLine();
        }
    }
}
