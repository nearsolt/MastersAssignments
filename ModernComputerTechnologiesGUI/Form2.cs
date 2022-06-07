using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ModernComputerTechnologiesGUI {
    public partial class Form2 : Form {
        public Form2() {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        private int numberN;
        private double[] arrayOfValuesX;
        private double[] arrayOfFunctions;

        private void button1_Click(object sender, EventArgs e) {
            CreateGraphOfFunctionOriginalF(sender, e);
        }


        private void button2_Click(object sender, EventArgs e) {
            //informationStringLabel.Text = $"ArrayX lenght: {arrayOfValuesX.Length}\n ArrayX: {string.Join(", ", arrayOfValuesX)}";
        }


        private void button3_Click(object sender, EventArgs e) {
            this.chart1.Series[0].Points.Clear();
            this.chart1.Series[1].Points.Clear();
        }


        #region
        /// <summary>
        /// Построение графика f(x) до обнуления коэффициентов c
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateGraphOfFunctionOriginalF(object sender, EventArgs e) {
            this.chart1.Series[0].Points.Clear();
            try {
                numberN = Convert.ToInt32(numericUpDown1.Value);
                arrayOfValuesX = new double[numberN + 1];
                arrayOfFunctions = new double[numberN + 1];

                Helpers.CalcArrayOfValuesX(arrayOfValuesX, numberN);
                Helpers.CalcArrayOfFunctions(arrayOfValuesX, arrayOfFunctions, numberN);

                for (int j = 0; j < numberN + 1; j++) {
                    this.chart1.Series[0].Points.AddXY(arrayOfValuesX[j], arrayOfFunctions[j]);
                }
            } catch (Exception ex) {
                informationStringLabel.Text = $"Error: {ex.Message}.";
            }
        }

        /// <summary>
        /// Построение графика f(x) после обнуления коэффициентов c
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateGraphOfFunctionModifiedF(object sender, EventArgs e) {
            this.chart1.Series[1].Points.Clear();
            try {
                numberN = Convert.ToInt32(numericUpDown1.Value);
                arrayOfValuesX = new double[numberN + 1];
                arrayOfFunctions = new double[numberN + 1];

                Helpers.CalcArrayOfValuesX(arrayOfValuesX, numberN);
                Helpers.CalcArrayOfFunctions(arrayOfValuesX, arrayOfFunctions, numberN);

                //for (int j = 0; j < numberN + 1; j++) {
                //    this.chart1.Series[0].Points.AddXY(arrayOfValuesX[j], arrayOfFunctions[j]);
                //}
            } catch (Exception ex) {
                informationStringLabel.Text = $"Error: {ex.Message}.";
            }
        }

        #endregion

    }
}
